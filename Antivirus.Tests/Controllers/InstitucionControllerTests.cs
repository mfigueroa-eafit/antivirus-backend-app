using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Antivirus.Controllers;
using Antivirus.Services;
using Antivirus.Dtos;
using FluentAssertions;

namespace Antivirus.Tests
{
    public class InstitucionControllerTests
    {
        private readonly Mock<IInstitucionService> _serviceMock;
        private readonly InstitucionController _controller;

        public InstitucionControllerTests()
        {
            _serviceMock = new Mock<IInstitucionService>();
            _controller = new InstitucionController(_serviceMock.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOk_WhenDataExists()
        {
            // Arrange
            var instituciones = new List<InstitucionDto> { new InstitucionDto { Id = 1, Nombre = "Test Institucion" } };
            _serviceMock.Setup(s => s.GetAllAsync()).ReturnsAsync(instituciones);

            // Act
            var result = await _controller.GetAll();

            // Assert
            result.Should().BeOfType<OkObjectResult>().Which.Value.Should().BeEquivalentTo(instituciones);
        }

        [Fact]
        public async Task GetById_ShouldReturnOk_WhenInstitucionExists()
        {
            // Arrange
            var institucion = new InstitucionDto { Id = 1, Nombre = "Test Institucion" };
            _serviceMock.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(institucion);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            result.Should().BeOfType<OkObjectResult>().Which.Value.Should().BeEquivalentTo(institucion);
        }

        [Fact]
        public async Task GetById_ShouldReturnNotFound_WhenInstitucionDoesNotExist()
        {
            // Arrange
            _serviceMock.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(default(InstitucionDto));


            // Act
            var result = await _controller.GetById(1);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task Create_ShouldReturnCreatedAtAction_WhenValidInstitucion()
        {
            // Arrange
            var institucionDto = new InstitucionDto { Nombre = "Nueva Institución" };
            var createdInstitucion = new InstitucionDto { Id = 1, Nombre = "Nueva Institución" };

            _serviceMock.Setup(s => s.AddAsync(institucionDto)).ReturnsAsync(createdInstitucion);

            // Act
            var result = await _controller.Create(institucionDto);

            // Assert
            var createdResult = result.Should().BeOfType<CreatedAtActionResult>().Subject;
            createdResult.ActionName.Should().Be(nameof(InstitucionController.GetById));
            createdResult.Value.Should().BeEquivalentTo(createdInstitucion);
        }

        [Fact]
        public async Task Update_ShouldReturnOk_WhenUpdateIsSuccessful()
        {
            // Arrange
            var institucionDto = new InstitucionDto { Id = 1, Nombre = "Updated Institucion" };
            _serviceMock.Setup(s => s.UpdateAsync(1, institucionDto)).ReturnsAsync(institucionDto);

            // Act
            var result = await _controller.Update(1, institucionDto);

            // Assert
            result.Should().BeOfType<OkObjectResult>().Which.Value.Should().BeEquivalentTo(institucionDto);
        }

        [Fact]
        public async Task Update_ShouldReturnNotFound_WhenInstitucionDoesNotExist()
        {
            // Arrange
            var institucionDto = new InstitucionDto { Id = 1, Nombre = "Updated Institucion" };
            _serviceMock.Setup(s => s.UpdateAsync(1, institucionDto)).ReturnsAsync(default(InstitucionDto));


            // Act
            var result = await _controller.Update(1, institucionDto);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task Delete_ShouldReturnNoContent_WhenDeletionIsSuccessful()
        {
            // Arrange
            _serviceMock.Setup(s => s.DeleteAsync(1)).ReturnsAsync(true);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task Delete_ShouldReturnNotFound_WhenInstitucionDoesNotExist()
        {
            // Arrange
            _serviceMock.Setup(s => s.DeleteAsync(1)).ReturnsAsync(false);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }
    }
}
