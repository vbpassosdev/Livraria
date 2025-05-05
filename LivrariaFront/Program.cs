using LivrariaFront.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o arquivo de configuração
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Configurações para a URL da API
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

// Adiciona o HttpClient com a configuração do API
builder.Services.AddHttpClient("LivrariaApi", (sp, client) =>
{
    var settings = sp.GetRequiredService<IOptions<ApiSettings>>().Value;
    Console.WriteLine($"Base URL: {settings.BaseUrl}");
    client.BaseAddress = new Uri(settings.BaseUrl);
});

// Adiciona o serviço LivrariaService
builder.Services.AddScoped<LivrariaService>();

builder.Services.AddRazorPages();
builder.Services.AddHttpClient(); // Confirma que o HttpClient está sendo registrado no serviço

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.Run();
