using API_Livraria;
using LivrariaApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Serviços
builder.Services.AddSingleton<LivroService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS - apenas uma vez
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorFrontend", policy =>
    {
        policy.WithOrigins("https://applivrariablazorweb.onrender.com")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Middleware
app.UseSwagger();
app.UseSwaggerUI();

// Use CORS com a política correta
app.UseCors("AllowBlazorFrontend");

app.MapControllers();
app.Run();
