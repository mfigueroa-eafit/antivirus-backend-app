using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using FluentAssertions;
using System.Net.Http.Json;
using Antivirus.Dtos;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Antivirus.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

public class InstitucionControllerTests : IClassFixture<TestProgram>
{
    private readonly HttpClient _client;
    private readonly IServiceScope _scope;
    private readonly ApplicationDbContext _dbContext;

    public InstitucionControllerTests(TestProgram factory)
    {
        _client = factory.CreateClient();
        _scope = factory.Services.CreateScope();
        _dbContext = _scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        SeedDatabase().Wait(); // Asegura que los datos de prueba están listos antes de ejecutar las pruebas
        AuthenticateClient().Wait(); // Obtiene el token y lo asigna a las solicitudes
    }

    private async Task AuthenticateClient()
    {
        var loginData = new { Email = "admin@test.com", Password = "password123" }; // Ajusta con credenciales válidas
        var loginResponse = await _client.PostAsJsonAsync("/login", loginData);

        loginResponse.EnsureSuccessStatusCode(); // Verifica que el login fue exitoso

        var authResult = await loginResponse.Content.ReadFromJsonAsync<String>();
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResult.Token);
    }

    private async Task SeedDatabase()
    {
        _dbContext.Instituciones.Add(new Institucion { Nombre = "Prueba 1", Ubicacion = "Ubicación 1", Url = "http://prueba.com" });
        _dbContext.Instituciones.Add(new Institucion { Nombre = "Prueba 2", Ubicacion = "Ubicación 2", Url = "http://prueba2.com" });
        await _dbContext.SaveChangesAsync();
    }

    [Fact]
    public async Task GetAllInstituciones_ShouldReturnSuccess()
    {
        var response = await _client.GetAsync("/api/institucion");
        response.EnsureSuccessStatusCode();
        var instituciones = await response.Content.ReadFromJsonAsync<List<InstitucionDto>>();
        instituciones.Should().NotBeNull();
        instituciones.Should().HaveCount(2);
    }

    [Fact]
    public async Task CreateInstitucion_ShouldReturnCreated()
    {
        var nuevaInstitucion = new InstitucionDto { Nombre = "Nueva", Ubicacion = "Ciudad", Url = "http://test.com" };
        var response = await _client.PostAsJsonAsync("/api/institucion", nuevaInstitucion);
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

        var instituciones = await _dbContext.Instituciones.ToListAsync();
        instituciones.Should().HaveCount(3);
    }
}

