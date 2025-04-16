using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Extensions;

internal class InitialData
{
    public static IEnumerable<Customer> Customers => new List<Customer>
    {
        Customer.Create(CustomerId.Of(new Guid("2e1afc3a-abfb-4df6-9e24-2faa5a1c3b3b")), "Mahmoud Youssef", "Mahmoud.youssef7447@gmail.com"),
        Customer.Create(CustomerId.Of(new Guid("3100b2ab-1638-430d-abce-e8f1bf00c05b")), "Maxx Jack", "MaxxJack@gmail.com")
    };

    public static List<Product> Products => new List<Product>
    {
        Product.Create(ProductId.Of(new Guid("f77889fa-cbb7-443f-9142-00732c8e0d47")), "IPhone X", 500),
        Product.Create(ProductId.Of(new Guid("58fe5e41-cd25-4ff1-baf9-792ded77d8ef")), "Samsung 10", 400),
        Product.Create(ProductId.Of(new Guid("f1ed33c7-dc34-4f9a-9159-c177057a4bbd")), "Huawei Plus", 650),
        Product.Create(ProductId.Of(new Guid("60098516-8433-47af-85ec-cb23261d7c7e")), "Xiaomi Mi", 450)
    };

    public static IEnumerable<Order> OrdersWithItems
    {
        get
        {
            var address1 = Address.Of("Mahmoud", "Youssef", "Mahmoud.youssef7447@gmail.com", "Block No:4", "Egypt", "Assiut", "38781");
            var address2 = Address.Of("Maxx", "Jack", "MaxxJack@gmail.com", "Broadway No:1", "England", "Nottingham", "08050");

            var payment1 = Payment.Of("Mahmoud Youssef", "5555555555554444", "12/28", "355", 1);
            var payment2 = Payment.Of("Maxx Jack", "8885555555554444", "06/30", "222", 2);

            var order1 = Order.Create(
                            OrderId.Of(Guid.NewGuid()),
                            CustomerId.Of(new Guid("2e1afc3a-abfb-4df6-9e24-2faa5a1c3b3b")),
                            OrderName.Of("ORD_1"),
                            shippingAddress: address1,
                            billingAddress: address1,
                            payment1);
            order1.Add(ProductId.Of(new Guid("f77889fa-cbb7-443f-9142-00732c8e0d47")), 2, 500);
            order1.Add(ProductId.Of(new Guid("58fe5e41-cd25-4ff1-baf9-792ded77d8ef")), 1, 400);

            var order2 = Order.Create(
                            OrderId.Of(Guid.NewGuid()),
                            CustomerId.Of(new Guid("3100b2ab-1638-430d-abce-e8f1bf00c05b")),
                            OrderName.Of("ORD_2"),
                            shippingAddress: address2,
                            billingAddress: address2,
                            payment2);
            order2.Add(ProductId.Of(new Guid("f1ed33c7-dc34-4f9a-9159-c177057a4bbd")), 1, 650);
            order2.Add(ProductId.Of(new Guid("60098516-8433-47af-85ec-cb23261d7c7e")), 2, 450);

            return new List<Order> { order1, order2 };
        }
    }

}