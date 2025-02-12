using AgendamentoBanhoETosa.Data;
using AgendamentoBanhoETosa.Repository.Implementations;
using AgendamentoBanhoETosa.Repository.Interfaces;
using AgendamentoBanhoETosa.Services.Implementations;
using AgendamentoBanhoETosa.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurações básicas do Swagger e Controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(); // Adiciona suporte a controllers

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        policy =>
        {
            policy.WithOrigins("http://localhost:8080", "http://localhost:8081", "https://appvuebanhotosa.onrender.com") // Ajuste para a porta do seu frontend
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

// Configuração do AppDbContext com suporte ao PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("AivenDB")));

// Registro de Serviços
builder.Services.AddScoped<ITutorServ, TutorServ>();
builder.Services.AddScoped<IAnimalServ, AnimalServ>();
builder.Services.AddScoped<IAgendamentoServ, AgendamentoServ>();
builder.Services.AddScoped<IServicoServ, ServicoServ>();

// Registro de Repositórios
builder.Services.AddScoped<ITutorRepo, TutorRepo>();
builder.Services.AddScoped<IAnimalRepo, AnimalRepo>();
builder.Services.AddScoped<IAgendamentoRepo, AgendamentoRepo>();
builder.Services.AddScoped<IServicoRepo, ServicoRepo>();

var app = builder.Build();

// Configuração do ambiente de desenvolvimento
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

// Configurações adicionais do middleware
app.UseHttpsRedirection();

app.UseCors("AllowLocalhost");

app.UseAuthorization();
app.MapControllers(); // Mapeia automaticamente todos os controllers

// Inicia a aplicação
app.Run();
