var builder = WebApplication.CreateBuilder(args);

// Add Services to the Container
builder.Services.AddCarter();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database") ?? throw new Exception("Invalid database connection"));
}).UseLightweightSessions();


var app = builder.Build();

// Configure the HTTP request pipline
app.MapCarter();
app.Run();
