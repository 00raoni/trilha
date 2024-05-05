using AutoMapper;
using Moq;
using trilha_net.Domain.Arguments.ViewModels;
using trilha_net.Domain.Interfaces.Repositories;
using trilha_net.Domain.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace trilha_net.Tests.Services
{
    public class UsuarioServiceTests
    {
        private readonly UsuarioService _usuarioService;
        private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;

        public UsuarioServiceTests()
        {
            _usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            _mapperMock = new Mock<IMapper>();
            _usuarioService = new UsuarioService(_usuarioRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public void MustReturnTrueValidatingCPF()
        {
            // Arrange
            var cpf = "00000000353";

            // Act
            var response = _usuarioService.ValidarCPF(cpf);

            // Assert
            Assert.True(response);            
        }
        [Fact]
        public void MustReturnFalseValidatingCPF()
        {
            // Arrange
            var cpf = "00000000995";

            // Act
            var response = _usuarioService.ValidarCPF(cpf);

            // Assert
            Assert.False(response);
        }
    }
}
