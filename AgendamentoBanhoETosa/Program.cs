using AgendamentoBanhoETosa.Data;
using AgendamentoBanhoETosa.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(); // Adiciona suporte a controllers

// AppDbContext com suporte ao PostgreSQL Ref:( https://www.connectionstrings.com/npgsql/)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ApiDatabase")));

//Cliente
builder.Services.AddScoped<IClienteServ, ClienteServ>();
//Pet
//Agendamento
//Serviço

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configurações adicionais
app.UseHttpsRedirection();
app.MapControllers(); // Mapeia automaticamente todos os controllers

// Inicia a aplicação
app.Run();
