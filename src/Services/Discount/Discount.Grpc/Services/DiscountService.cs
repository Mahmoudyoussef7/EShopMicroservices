using Discount.Grpc.Data;
using Discount.Grpc.Models;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Services;

public class DiscountService(DiscountContext _dbContext, ILogger<DiscountService> _logger)
    : DiscountProtoService.DiscountProtoServiceBase
{
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = await _dbContext.Coupons.FirstOrDefaultAsync(c => c.ProductName == request.ProductName)
                        ?? new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Desc" };
        _logger.LogInformation($"Discount is retrieved for ProductName : {coupon.ProductName}, Amount : {coupon.Amount}");
        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }
    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<Coupon>()
                     ?? throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid Discount Request"));
        await _dbContext.Coupons.AddAsync(coupon);
        await _dbContext.SaveChangesAsync();

        _logger.LogInformation($"Discount is successfully created. ProductName : {coupon.ProductName}");

        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }
    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<Coupon>()
                     ?? throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid Discount Request"));
        _dbContext.Coupons.Update(coupon);
        await _dbContext.SaveChangesAsync();

        _logger.LogInformation($"Discount is successfully updated. ProductName : {coupon.ProductName}");

        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }
    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var coupon = await _dbContext.Coupons.FirstOrDefaultAsync(c => c.ProductName == request.ProductName)
        ?? throw new RpcException(new Status(StatusCode.NotFound, $"Discount with ProductName={request.ProductName} is not found."));

        _dbContext.Coupons.Remove(coupon);
        await _dbContext.SaveChangesAsync();

        _logger.LogInformation($"Discount is successfully deleted. ProductName : {coupon.ProductName}");
        return new DeleteDiscountResponse { Success=true};
    }
}
