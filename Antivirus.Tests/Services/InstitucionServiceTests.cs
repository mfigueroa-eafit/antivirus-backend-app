using Moq;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Antivirus.Services;
using Antivirus.Repositories;
using Antivirus.Dtos;
using Antivirus.Models;
using AutoMapper;
using FluentAssertions;

public class InstitucionServiceTests
{
    private readonly Mock<IInstitucionRepository> _mockRepo;
    private readonly Mock<IMapper> _mockMapper;
    private readonly InstitucionService _service;

    public InstitucionServiceTests()
    {
        _mockRepo = new Mock<IInstitucionRepository>();
        _mockMapper = new Mock<IMapper>();
        _service = new InstitucionService(_mockRepo.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetAllInstituciones_ShouldReturnListOfInstituciones()
    {
        // Arrange
        var instituciones = new List<Institucion> { new Institucion { Id = 1, Nombre = "Test",Ubicacion = "Some location", Url = "https://example.com"} };
        _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(instituciones);
        _mockMapper.Setup(m => m.Map<IEnumerable<InstitucionDto>>(instituciones)).Returns(new List<InstitucionDto>
        {
            new InstitucionDto { Id = 1, Nombre = "Test" }
        });

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        result.Should().HaveCount(1);
        result.Should().ContainSingle(i => i.Nombre == "Test");
    }
}
