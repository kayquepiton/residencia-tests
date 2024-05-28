using System;
using Xunit;
using Atividade09;

namespace Atividade09.Tests
{
    public class ItemCollectionTests
    {
        // Testa se é possível adicionar um item à coleção
        [Fact]
        public void AddItem_ValidItem_AddsItemToCollection()
        {
            // Arrange
            var itemCollection = new ItemCollection(); // Cria uma instância de ItemCollection
            var item = new Item("Item 1"); // Cria um item válido

            // Act
            itemCollection.AddItem(item); // Adiciona o item à coleção

            // Assert
            Assert.Contains(item, itemCollection.GetItems()); // Verifica se o item foi adicionado à coleção
        }

        // Testa se uma exceção é lançada ao tentar adicionar um item nulo à coleção
        [Fact]
        public void AddItem_NullItem_ThrowsArgumentException()
        {
            // Arrange
            var itemCollection = new ItemCollection(); // Cria uma instância de ItemCollection

            // Act & Assert
            // Verifica se uma exceção do tipo ArgumentException é lançada ao tentar adicionar um item nulo
            var exception = Assert.Throws<ArgumentException>(() => itemCollection.AddItem(null));
            Assert.Equal("Item cannot be null", exception.Message); // Verifica a mensagem da exceção
        }

        // Testa se é possível remover um item da coleção
        [Fact]
        public void RemoveItem_ExistingItem_RemovesItemFromCollection()
        {
            // Arrange
            var itemCollection = new ItemCollection(); // Cria uma instância de ItemCollection
            var item = new Item("Item 1"); // Cria um item válido
            itemCollection.AddItem(item); // Adiciona o item à coleção

            // Act
            itemCollection.RemoveItem(item); // Remove o item da coleção

            // Assert
            Assert.DoesNotContain(item, itemCollection.GetItems()); // Verifica se o item foi removido da coleção
        }

        // Testa se uma exceção é lançada ao tentar remover um item que não está na coleção
        [Fact]
        public void RemoveItem_NonExistingItem_ThrowsArgumentException()
        {
            // Arrange
            var itemCollection = new ItemCollection(); // Cria uma instância de ItemCollection
            var item = new Item("Item 1"); // Cria um item válido

            // Act & Assert
            // Verifica se uma exceção do tipo ArgumentException é lançada ao tentar remover um item não existente
            var exception = Assert.Throws<ArgumentException>(() => itemCollection.RemoveItem(item));
            Assert.Equal("Item not found in the collection", exception.Message); // Verifica a mensagem da exceção
        }
    }
}
