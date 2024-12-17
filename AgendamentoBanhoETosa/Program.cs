using AgendamentoBanhoETosa.Data;
using AgendamentoBanhoETosa.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurações básicas do Swagger e Controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(); // Adiciona suporte a controllers

// Configuração do AppDbContext com suporte ao PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("AivenDB")));

// Registro de Serviços
builder.Services.AddScoped<IClienteServ, ClienteServ>();
builder.Services.AddScoped<IAnimalServ, AnimalServ>();
builder.Services.AddScoped<IAgendamentoServ, AgendamentoServ>();
builder.Services.AddScoped<IServicoServ, ServicoServ>();

var app = builder.Build();

// Configuração do ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configurações adicionais do middleware
app.UseHttpsRedirection();
app.MapControllers(); // Mapeia automaticamente todos os controllers

// Inicia a aplicação
app.Run();
