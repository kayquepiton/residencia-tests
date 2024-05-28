using System;
using Moq;
using Xunit;
using Atividade07;

namespace Atividade07.Tests
{
    public class UserServiceTests
    {
        // Testa se o método SaveUser chama corretamente o método SaveUser no banco de dados
        [Fact]
        public void SaveUser_ValidUser_CallsSaveUserOnDatabase()
        {
            // Arrange
            var mockDatabase = new Mock<IDatabase>(); // Cria um mock para a interface IDatabase
            var userService = new UserService(mockDatabase.Object); // Cria uma instância de UserService com o mock de IDatabase
            var user = new User("John Doe", "john.doe@example.com"); // Cria um usuário válido

            // Act: Chama o método SaveUser
            userService.SaveUser(user);

            // Assert: Verifica se o método SaveUser no mock de IDatabase foi chamado uma vez com qualquer usuário
            mockDatabase.Verify(db => db.SaveUser(It.IsAny<User>()), Times.Once);
        }

        // Testa se uma exceção é lançada quando o usuário não tem um nome
        [Fact]
        public void SaveUser_UserWithoutName_ThrowsArgumentException()
        {
            // Arrange
            var mockDatabase = new Mock<IDatabase>(); // Cria um mock para a interface IDatabase
            var userService = new UserService(mockDatabase.Object); // Cria uma instância de UserService com o mock de IDatabase
            var user = new User("", "john.doe@example.com"); // Cria um usuário sem nome

            // Act & Assert: Verifica se uma exceção do tipo ArgumentException é lançada
            var exception = Assert.Throws<ArgumentException>(() => userService.SaveUser(user));
            Assert.Equal("User must have a name and email", exception.Message); // Verifica a mensagem da exceção
            mockDatabase.Verify(db => db.SaveUser(It.IsAny<User>()), Times.Never); // Verifica se SaveUser não foi chamado
        }

        // Testa se uma exceção é lançada quando o usuário não tem um e-mail
        [Fact]
        public void SaveUser_UserWithoutEmail_ThrowsArgumentException()
        {
            // Arrange
            var mockDatabase = new Mock<IDatabase>(); // Cria um mock para a interface IDatabase
            var userService = new UserService(mockDatabase.Object); // Cria uma instância de UserService com o mock de IDatabase
            var user = new User("John Doe", ""); // Cria um usuário sem e-mail

            // Act & Assert: Verifica se uma exceção do tipo ArgumentException é lançada
            var exception = Assert.Throws<ArgumentException>(() => userService.SaveUser(user));
            Assert.Equal("User must have a name and email", exception.Message); // Verifica a mensagem da exceção
            mockDatabase.Verify(db => db.SaveUser(It.IsAny<User>()), Times.Never); // Verifica se SaveUser não foi chamado
        }
    }
}
