using System;
using Moq;
using Xunit;
using Atividade14;

namespace Atividade14.Tests
{
    public class EventHandlerTests
    {
        // Testa se o método SendEmail é chamado corretamente ao lidar com um evento
        [Fact]
        public void HandleEvent_ValidEventMessage_CallsSendEmail()
        {
            // Arrange
            var mockEmailService = new Mock<IEmailService>(); // Cria um mock para a interface IEmailService
            var eventHandler = new EventHandler(mockEmailService.Object); // Cria uma instância de EventHandler com o mock de IEmailService
            var eventMessage = "An event has occurred"; // Mensagem do evento

            // Act
            eventHandler.HandleEvent(eventMessage); // Chama o método HandleEvent

            // Assert
            // Verifica se o método SendEmail no mock de IEmailService foi chamado com os parâmetros corretos
            mockEmailService.Verify(es => es.SendEmail(
                "test@example.com",
                "Event Occurred",
                eventMessage), Times.Once);
        }
    }
}
