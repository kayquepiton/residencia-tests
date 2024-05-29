using System;
using Moq;
using Xunit;
using Atividade10;

namespace Atividade10.Tests
{
    public class UserManagerTests
    {
        // Testa se o método FetchUserInfo retorna as informações corretas do usuário
        [Fact]
        public void FetchUserInfo_ValidUserId_ReturnsUserInfo()
        {
            // Arrange
            var mockUserService = new Mock<IUserService>(); // Cria um mock para a interface IUserService
            var userId = 1; // ID do usuário para o teste
            var expectedUser = new User("John Doe", "john.doe@example.com"); // Informações esperadas do usuário

            // Configura o mock para retornar o usuário esperado quando GetUserInfo for chamado com o userId
            mockUserService.Setup(service => service.GetUserInfo(userId)).Returns(expectedUser);

            var userManager = new UserManager(mockUserService.Object); // Cria uma instância de UserManager com o mock de IUserService

            // Act
            var actualUser = userManager.FetchUserInfo(userId); // Chama o método FetchUserInfo

            // Assert
            Assert.Equal(expectedUser.Name, actualUser.Name); // Verifica se o nome do usuário retornado é o esperado
            Assert.Equal(expectedUser.Email, actualUser.Email); // Verifica se o email do usuário retornado é o esperado
        }

        // Testa se o método FetchUserInfo lida corretamente com um ID de usuário inválido
        [Fact]
        public void FetchUserInfo_InvalidUserId_ReturnsNull()
        {
            // Arrange
            var mockUserService = new Mock<IUserService>(); // Cria um mock para a interface IUserService
            var userId = -1; // ID de usuário inválido para o teste

            // Configura o mock para retornar null quando GetUserInfo for chamado com o userId inválido
            mockUserService.Setup(service => service.GetUserInfo(userId)).Returns((User)null);

            var userManager = new UserManager(mockUserService.Object); // Cria uma instância de UserManager com o mock de IUserService

            // Act
            var actualUser = userManager.FetchUserInfo(userId); // Chama o método FetchUserInfo

            // Assert
            Assert.Null(actualUser); // Verifica se o resultado é null para um ID de usuário inválido
        }
    }
}
