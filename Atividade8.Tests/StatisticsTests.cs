using System;
using System.Collections.Generic; 
using Atividade08; 
using Xunit; 

namespace Atividade08.Tests
{
    public class StatisticsTests 
    {
        // Testa se o método CalculateAverage retorna a média correta para uma lista válida de números
        [Fact]
        public void CalculateAverage_ValidNumbers_ReturnsCorrectAverage()
        {
            // Arrange: Cria uma instância da classe Statistics e uma lista de números válidos
            var statistics = new Statistics();
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            // Act: Chama o método CalculateAverage para calcular a média
            var average = statistics.CalculateAverage(numbers);

            // Assert: Verifica se a média calculada está correta
            Assert.Equal(3.0, average);
        }

        // Testa se uma exceção é lançada quando a lista de números está vazia
        [Fact]
        public void CalculateAverage_EmptyList_ThrowsArgumentException()
        {
            // Arrange: Cria uma instância da classe Statistics e uma lista vazia
            var statistics = new Statistics();
            var numbers = new List<int>();

            // Act & Assert: Verifica se uma exceção do tipo ArgumentException é lançada quando a lista está vazia
            var exception = Assert.Throws<ArgumentException>(() => statistics.CalculateAverage(numbers));
            Assert.Equal("The list of numbers cannot be empty", exception.Message); // Verifica a mensagem da exceção
        }

        // Testa se uma exceção é lançada quando a lista de números é nula
        [Fact]
        public void CalculateAverage_NullList_ThrowsArgumentException()
        {
            // Arrange: Cria uma instância da classe Statistics e define a lista como nula
            var statistics = new Statistics();
            List<int> numbers = null;

            // Act & Assert: Verifica se uma exceção do tipo ArgumentException é lançada quando a lista é nula
            var exception = Assert.Throws<ArgumentException>(() => statistics.CalculateAverage(numbers));
            Assert.Equal("The list of numbers cannot be empty", exception.Message); // Verifica a mensagem da exceção
        }
    }
}
