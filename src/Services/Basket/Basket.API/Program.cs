var builder = WebApplication.CreateBuilder(args);

// Add Services to the Container
builder.Services.AddCarter();

var app = builder.Build();

// Configure the HTTP request pipline

app.Run();
