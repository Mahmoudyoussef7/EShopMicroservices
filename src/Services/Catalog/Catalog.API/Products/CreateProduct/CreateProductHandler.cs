namespace Catalog.API.Products.CreateProduct;


public record CreateProductCommand(string Name, string Description, string ImageFile, decimal Price, List<string> Category) : ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id);
internal class CreateProductCommandHandler(IDocumentSession session) : ICommadHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        // create Product entity from command object
        var product = new Product
        {
            Name = command.Name,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price,
            Category = command.Category,
        };
        // save to database
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);
        // return CreateProductResult result
        return new CreateProductResult(product.Id);
    }
}
