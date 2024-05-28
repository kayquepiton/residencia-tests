using System;
using Xunit;
using Atividade6;
using Atividade06; // Certifique-se de que este namespace está correto

namespace Atividade6.Tests
{
    public class PointTests
    {
        // Testa se a distância de um ponto para ele mesmo é zero
        [Fact]
        public void DistanceTo_SamePoint_ReturnsZero()
        {
            // Arrange: cria um ponto na origem (0, 0)
            var point = new Point(0, 0);

            // Act: calcula a distância do ponto para ele mesmo
            var distance = point.DistanceTo(point);

            // Assert: verifica se a distância é zero
            Assert.Equal(0, distance);
        }

        // Testa a distância entre dois pontos diferentes
        [Fact]
        public void DistanceTo_DifferentPoints_ReturnsCorrectDistance()
        {
            // Arrange: cria dois pontos (0, 0) e (3, 4)
            var point1 = new Point(0, 0);
            var point2 = new Point(3, 4);

            // Act: calcula a distância entre point1 e point2
            var distance = point1.DistanceTo(point2);

            // Assert: verifica se a distância é 5 (usando o teorema de Pitágoras)
            Assert.Equal(5, distance);
        }

        // Testa se uma exceção é lançada quando o ponto passado é nulo
        [Fact]
        public void DistanceTo_NullPoint_ThrowsArgumentNullException()
        {
            // Arrange: cria um ponto na origem (0, 0)
            var point = new Point(0, 0);

            // Act & Assert: verifica se uma ArgumentNullException é lançada quando point.DistanceTo(null) é chamado
            Assert.Throws<ArgumentNullException>(() => point.DistanceTo(null));
        }

        // Usa vários conjuntos de dados para testar a distância entre pontos
        [Theory]
        [InlineData(0, 0, 0, 0, 0)]          // Distância de (0,0) para (0,0) deve ser 0
        [InlineData(0, 0, 3, 4, 5)]          // Distância de (0,0) para (3,4) deve ser 5
        [InlineData(1, 1, 4, 5, 5)]          // Distância de (1,1) para (4,5) deve ser 5
        [InlineData(-1, -1, -4, -5, 5)]      // Distância de (-1,-1) para (-4,-5) deve ser 5
        [InlineData(-1, 1, 1, -1, 2.828427)] // Distância de (-1,1) para (1,-1) deve ser aproximadamente 2.828427
        public void DistanceTo_VariousPoints_ReturnsExpectedDistance(
            double x1, double y1, double x2, double y2, double expectedDistance)
        {
            // Arrange: cria dois pontos com as coordenadas fornecidas
            var point1 = new Point(x1, y1);
            var point2 = new Point(x2, y2);

            // Act: calcula a distância entre point1 e point2
            var distance = point1.DistanceTo(point2);

            // Assert: verifica se a distância é a esperada com precisão de 6 casas decimais
            Assert.Equal(expectedDistance, distance, 6); // Precisão de 6 casas decimais
        }
    }
}
