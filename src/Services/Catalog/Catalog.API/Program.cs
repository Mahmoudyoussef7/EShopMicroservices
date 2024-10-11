var builder = WebApplication.CreateBuilder(args);

// Add Services to the Container

var app = builder.Build();

// Configure the HTTP request pipline

app.Run();
