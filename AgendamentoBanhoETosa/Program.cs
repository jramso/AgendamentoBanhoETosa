using AgendamentoBanhoETosa.Data;
using AgendamentoBanhoETosa.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura��o de servi�os
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(); // Adiciona suporte a controllers

// Configura o AppDbContext com suporte ao PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ApiDatabase")));

// Registro de servi�os e inje��o de depend�ncia
builder.Services.AddScoped<IClienteServ, ClienteServ>();

var app = builder.Build();

// Configura��o do Swagger no ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configura��es adicionais
app.UseHttpsRedirection();
app.MapControllers(); // Mapeia automaticamente todos os controllers

// Inicia a aplica��o
app.Run();
