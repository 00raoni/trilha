using AutoFixture;
using System.Net;
using System.Net.Http.Json;
using trilha_net.Domain.Arguments.ViewModels;
using trilha_net.Tests.Factories;

namespace trilha_net.Tests.Integrations.Controller
{
    [Collection("Database")]
    public class UsuarioControllerTest : IClassFixture<TrilhaFactory>
    {
        private readonly TrilhaFactory _factory;
        private readonly Fixture _fixture;
        public UsuarioControllerTest(TrilhaFactory factory)
        {
            _factory = factory;
            _fixture = new Fixture();
        }
        [Fact]
        public async Task CreateUsuario_ShouldReturn_BadRequest()
        {
            // Arrange
            var client = _factory.CreateClient();
            var usuario = new RequestUsuario()
            {
                Nome = "",
                Email = "maria12@gmail.com",
                Login = "maria",
                Senha = "12345",
                CPF = "00000000353",
                DataNascimento = DateTime.Parse("2005-01-01")
            };
            // Act
            var response = await client.PostAsJsonAsync("usuario", usuario);
            
            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task CreateUsuario_ShouldReturn_Ok()
        {
            // Arrange
            var client = _factory.CreateClient();
            var usuario = _fixture.Create<RequestUsuario>();
            usuario.CPF = "00000000353";
            // Act
            var response = await client.PostAsJsonAsync("usuario",usuario);
            // Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task UpdateUsuario_ShouldReturn_Ok()
        {
            // Arrange
            var client = _factory.CreateClient();
            var usuario = _fixture.Create<RequestUsuario>();
            usuario.CPF = "00000000353";

            var response = await client.PostAsJsonAsync("usuario", usuario);
            var id = await response.Content.ReadAsStringAsync();
            usuario.Nome = "novoNome";
            // Act
            response = await client.PutAsJsonAsync($"usuario/{id.Replace("\"","")}", usuario);
            
            // Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

    }
}