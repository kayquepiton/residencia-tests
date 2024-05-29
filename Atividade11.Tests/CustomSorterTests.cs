using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Atividade11;

namespace Atividade11.Tests
{
    public class CustomSorterTests
    {
        // Testa se o método SortDescending ordena corretamente uma lista de números em ordem decrescente
        [Fact]
        public void SortDescending_ValidList_SortsCorrectly()
        {
            // Arrange
            var sorter = new CustomSorter();
            var numbers = new List<int> { 5, 1, 4, 2, 3 }; // Lista de números não ordenados

            // Act
            var sortedNumbers = sorter.SortDescending(numbers); // Chama o método SortDescending

            // Assert
            var expected = new List<int> { 5, 4, 3, 2, 1 }; // Lista esperada após a ordenação
            Assert.Equal(expected, sortedNumbers); // Verifica se a lista ordenada está correta
        }

        // Testa se o método SortDescending retorna uma lista vazia quando a entrada é uma lista vazia
        [Fact]
        public void SortDescending_EmptyList_ReturnsEmptyList()
        {
            // Arrange
            var sorter = new CustomSorter();
            var numbers = new List<int>(); // Lista vazia

            // Act
            var sortedNumbers = sorter.SortDescending(numbers); // Chama o método SortDescending

            // Assert
            Assert.Empty(sortedNumbers); // Verifica se a lista retornada é vazia
        }

        // Testa se o método SortDescending retorna a mesma lista quando a entrada tem um único elemento
        [Fact]
        public void SortDescending_SingleElementList_ReturnsSameList()
        {
            // Arrange
            var sorter = new CustomSorter();
            var numbers = new List<int> { 42 }; // Lista com um único elemento

            // Act
            var sortedNumbers = sorter.SortDescending(numbers); // Chama o método SortDescending

            // Assert
            Assert.Single(sortedNumbers); // Verifica se a lista retornada contém um único elemento
            Assert.Equal(42, sortedNumbers[0]); // Verifica se o único elemento é igual ao esperado
        }

        // Testa se o método SortDescending lida corretamente com números duplicados na lista
        [Fact]
        public void SortDescending_ListWithDuplicates_SortsCorrectly()
        {
            // Arrange
            var sorter = new CustomSorter();
            var numbers = new List<int> { 3, 1, 3, 2, 1 }; // Lista com números duplicados

            // Act
            var sortedNumbers = sorter.SortDescending(numbers); // Chama o método SortDescending

            // Assert
            var expected = new List<int> { 3, 3, 2, 1, 1 }; // Lista esperada após a ordenação
            Assert.Equal(expected, sortedNumbers); // Verifica se a lista ordenada está correta
        }
    }
}
