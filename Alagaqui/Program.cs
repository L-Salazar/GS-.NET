using Alagaqui.Application.Interfaces;
using Alagaqui.Application.Services;
using Alagaqui.Domain.Interfaces;
using Alagaqui.Infrastructure.Data.AppData;
using Alagaqui.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados Oracle
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("Oracle"));
});

// Repositórios
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<ILocalizacaoRepository, LocalizacaoRepository>();
builder.Services.AddTransient<IAlertaRepository, AlertaRepository>();
builder.Services.AddTransient<ITipoAlertaRepository, TipoAlertaRepository>();
builder.Services.AddTransient<IOcorrenciaRepository, OcorrenciaRepository>();

// Serviços de Aplicação
builder.Services.AddTransient<IUsuarioApplicationService, UsuarioApplicationService>();
builder.Services.AddTransient<ILocalizacaoApplicationService, LocalizacaoApplicationService>();
builder.Services.AddTransient<IAlertaApplicationService, AlertaApplicationService>();
builder.Services.AddTransient<ITipoAlertaApplicationService, TipoAlertaApplicationService>();
builder.Services.AddTransient<IOcorrenciaApplicationService, OcorrenciaApplicationService>();

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Alagaqui",
        Version = "v1",
        Description = "API para Monitoramento Colaborativo de Inundações Urbanas"
    });
    c.EnableAnnotations();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c =>
    {
        c.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi2_0;
    });
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
