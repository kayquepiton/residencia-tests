using System;
using Xunit;
using Atividade13;

namespace Atividade13.Tests
{
    public class FactorialCalculatorTests
    {
        // Testa se o método Calculate retorna o fatorial correto para um número positivo
        [Fact]
        public void Calculate_PositiveNumber_ReturnsCorrectFactorial()
        {
            // Arrange
            var calculator = new FactorialCalculator();

            // Act
            var result = calculator.Calculate(5);

            // Assert
            Assert.Equal(120, result); // 5! = 120
        }

        // Testa se o método Calculate retorna 1 para o número 0
        [Fact]
        public void Calculate_Zero_ReturnsOne()
        {
            // Arrange
            var calculator = new FactorialCalculator();

            // Act
            var result = calculator.Calculate(0);

            // Assert
            Assert.Equal(1, result); // 0! = 1
        }

        // Testa se o método Calculate retorna 1 para o número 1
        [Fact]
        public void Calculate_One_ReturnsOne()
        {
            // Arrange
            var calculator = new FactorialCalculator();

            // Act
            var result = calculator.Calculate(1);

            // Assert
            Assert.Equal(1, result); // 1! = 1
        }

        // Testa se o método Calculate lança uma exceção ao receber um número negativo
        [Fact]
        public void Calculate_NegativeNumber_ThrowsArgumentException()
        {
            // Arrange
            var calculator = new FactorialCalculator();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => calculator.Calculate(-1));
            Assert.Equal("Number must be non-negative", exception.Message);
        }
    }
}
