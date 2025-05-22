using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Antivirus.Services;
using System.Text;
using Antivirus.Models;
using Antivirus.Repositories;
using Antivirus.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;


var builder = WebApplication.CreateBuilder(args);

// Configurar autenticación JWT
var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? "");


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddAuthorization();

// Agregar configuración de Swagger con autenticación
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product API", Version = "v1" });

    // Configurar autenticación con JWT en Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Introduce el token JWT en el formato: Bearer {token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Registrar los servicios 
builder.Services.AddScoped<AuthService>();

// Institucion
builder.Services.AddScoped<IInstitucionRepository, InstitucionRepository>();
builder.Services.AddScoped<IInstitucionService, InstitucionService>();

// Oportunidades
builder.Services.AddScoped<IOportunidadRepository, OportunidadRepository>();
builder.Services.AddScoped<IOportunidadService, OportunidadService>();

// Tipos de Oportunidades
builder.Services.AddScoped<ITipoOportunidadRepository, TipoOportunidadRepository>();
builder.Services.AddScoped<ITipoOportunidadService, TipoOportunidadService>();

// Sectores
builder.Services.AddScoped<ISectorRepository, SectorRepository>();
builder.Services.AddScoped<ISectorService, SectorService>();


// Configurar EF Core con PostgreSQL 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Habilitar los CORS desde el frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // Permitir solo este frontend
                  .AllowAnyMethod() // Permitir cualquier método (GET, POST, etc.)
                  .AllowAnyHeader(); // Permitir cualquier header
        });
});


builder.Services.AddControllers();

// Registrar AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));


var app = builder.Build();

app.UseCors("AllowFrontend"); // Aplicar la política de CORS

app.UseAuthentication();
app.UseAuthorization();

// Habilitar Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API v1");
    c.RoutePrefix = string.Empty; // Hace que Swagger se cargue en la URL raíz
});


app.MapControllers();

app.Run();

public partial class Program { }
