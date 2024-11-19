using AgendamentoBanhoETosa.Data;
using AgendamentoBanhoETosa.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração de serviços
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(); // Adiciona suporte a controllers

// Configura o AppDbContext com suporte ao PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ApiDatabase")));

// Registro de serviços e injeção de dependência
builder.Services.AddScoped<IClienteServ, ClienteServ>();

var app = builder.Build();

// Configuração do Swagger no ambiente de desenvolvimento
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
