using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Moq;

namespace Atividade15.Tests
{
    public class DetectTextImageTests
    {
        [Fact]
        public async Task DetectTextLabelAsync_Success()
        {
            // Arrange
            var mockRekognitionClient = new Mock<IRekognitionClientWrapper>();
            var textDetections = new List<TextDetection>
            {
                new TextDetection 
                { 
                    DetectedText = "Test", 
                    Confidence = 99.0f, 
                    Id = 0, 
                    ParentId = 0, // Definindo ParentId como 0 em vez de null
                    Type = TextTypes.LINE 
                }
            };
            var detectTextResponse = new DetectTextResponse { TextDetections = textDetections };
            mockRekognitionClient.Setup(x => x.DetectTextAsync(It.IsAny<DetectTextRequest>())).ReturnsAsync(detectTextResponse);

            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var sourceImage = Path.Combine(baseDirectory, "data", "img-example-for-aws-task.jpg");
            var resultFilePath = Path.Combine(baseDirectory, "data", "detected_text_results.txt");
            var detectTextImage = new DetectTextImage(sourceImage, mockRekognitionClient.Object);

            // Act
            await detectTextImage.DetectTextLabelAsync(resultFilePath);

            // Assert
            mockRekognitionClient.Verify(x => x.DetectTextAsync(It.IsAny<DetectTextRequest>()), Times.Once);
            var resultContent = File.ReadAllText(resultFilePath);
            Assert.Contains("Detected: Test", resultContent);
        }

        [Fact]
        public async Task DetectTextLabelAsync_ThrowsException()
        {
            // Arrange
            var mockRekognitionClient = new Mock<IRekognitionClientWrapper>();
            mockRekognitionClient.Setup(x => x.DetectTextAsync(It.IsAny<DetectTextRequest>())).ThrowsAsync(new Exception("AWS error"));

            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var sourceImage = Path.Combine(baseDirectory, "data", "img-example-for-aws-task.jpg");
            var detectTextImage = new DetectTextImage(sourceImage, mockRekognitionClient.Object);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => detectTextImage.DetectTextLabelAsync(Path.Combine(baseDirectory, "data", "detected_text_results.txt")));
            Assert.Contains("Erro durante a execução do teste de detecção de texto", exception.Message);
        }
    }
}
