using BusinessLayer;
using DataAccessLayer;

/// <summary>
/// The main entry point for the REST API application.
/// </summary>
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("Connection");
// Registers the database context with the provided connection string.
builder.Services.RegisterDbContext(connectionString);
// Registers repository services.
builder.Services.RegisterRepositories();
// Registers business logic services.
builder.Services.RegisterServices();

// Configures JSON serialization settings.
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
});

// Configures CORS policy for cross-origin requests.
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins(
        "http://localhost:5500",
        "http://127.0.0.1:5500",
        "https://catnipcattery.co.nz"
        )
        .AllowAnyMethod()
        .AllowAnyHeader();
}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
// Applies the configured CORS policy.
app.UseCors("corsapp");

app.Run();

