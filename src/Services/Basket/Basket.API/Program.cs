
var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;
// Add Services to the Container
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database") ?? throw new Exception("Invalid database connection"));
    opts.Schema.For<ShoppingCart>().Identity(e => e.UserName);
}).UseLightweightSessions();

builder.Services.AddScoped<IBasketRepository, BasketRepositry>();
builder.Services.Decorate<IBasketRepository, CachedBasketRepositry>();
builder.Services.AddStackExchangeRedisCache(opts =>
{
    opts.Configuration = builder.Configuration.GetConnectionString("Redis");
    //opts.InstanceName = "Basket";
});

builder.Services.AddExceptionHandler<CustomExceptionHandler>();


var app = builder.Build();

// Configure the HTTP request pipline
app.MapCarter();

app.UseExceptionHandler(opt => { });

app.Run();
