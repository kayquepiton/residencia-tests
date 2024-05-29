using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Moq;
using Xunit;

namespace Atividade15.Tests
{
    public class DetectTextImageTests
    {
        // Testa se o método DetectTextLabelAsync chama corretamente o método DetectTextAsync do wrapper
        [Fact]
        public async Task DetectTextLabelAsync_ValidImage_CallsDetectTextAsync()
        {
            // Arrange
            var mockRekognitionClient = new Mock<IRekognitionClientWrapper>();
            var sourceImage = "path/to/mock-image.jpg";
            var resultFilePath = "path/to/mock-result.txt";
            var detectTextImage = new DetectTextImage(sourceImage, mockRekognitionClient.Object);

            // Mock response for DetectTextAsync
            var mockTextDetections = new List<TextDetection>
            {
                new TextDetection
                {
                    DetectedText = "Sample text",
                    Confidence = 99.0f,
                    Id = 1,
                    ParentId = 0,
                    Type = TextTypes.LINE
                }
            };
            var mockResponse = new DetectTextResponse { TextDetections = mockTextDetections };

            mockRekognitionClient
                .Setup(client => client.DetectTextAsync(It.IsAny<DetectTextRequest>()))
                .ReturnsAsync(mockResponse);

            // Act
            await detectTextImage.DetectTextLabelAsync(resultFilePath);

            // Assert
            // Verifica se o método DetectTextAsync foi chamado uma vez com qualquer DetectTextRequest
            mockRekognitionClient.Verify(client => client.DetectTextAsync(It.IsAny<DetectTextRequest>()), Times.Once);

            // Verifica se o resultado foi salvo no arquivo especificado
            var fileContents = await File.ReadAllTextAsync(resultFilePath);
            Assert.Contains("Sample text", fileContents);
            Assert.Contains("Confidence: 99", fileContents);
            Assert.Contains("Id: 1", fileContents);
            Assert.Contains("ParentId: 0", fileContents);
            Assert.Contains("Type: LINE", fileContents);
        }
    }
}
