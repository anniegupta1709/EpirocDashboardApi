using EpirocDashboardApi.Data;
using EpirocDashboardApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<MongoContext>();
builder.Services.AddHostedService<SimulationService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});


var app = builder.Build();

app.UseCors("AllowAll");


app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();

// REQUIRED for Render
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Run($"http://0.0.0.0:{port}");