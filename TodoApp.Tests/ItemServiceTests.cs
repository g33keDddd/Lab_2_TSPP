using System;
using TodoApp;
using Xunit;

namespace TodoApp.TodoApp.Tests
{
    public class ItemServiceTests
    {
        [Fact]
        public void Add_ValidTitle_ShouldAddItem()
        {
            var service = new ItemService();
            var item = service.Add("Test task");
            Assert.NotNull(item);
            Assert.Equal("Test task", item.Title);
        }

        [Fact]
        public void Add_EmptyTitle_ShouldThrowArgumentException()
        {
            var service = new ItemService();
            Assert.Throws<ArgumentException>(() => service.Add(""));
        }

        [Fact]
        public void Delete_ExistingItem_ShouldRemoveIt()
        {
            var service = new ItemService();
            var item = service.Add("To delete");
            service.Delete(item.Id);
            Assert.Empty(service.GetAll());
        }

        [Fact]
        public void Delete_NonExistingItem_ShouldThrowException()
        {
            var service = new ItemService();
            Assert.Throws<Exception>(() => service.Delete(999));
        }

        [Fact]
        public void Complete_ValidId_ShouldChangeStatus()
        {
            var service = new ItemService();
            var item = service.Add("Task");
            service.Complete(item.Id);
            Assert.True(service.GetById(item.Id).IsCompleted);
        }

        [Fact]
        public void Complete_InvalidId_ShouldThrowException()
        {
            var service = new ItemService();
            Assert.Throws<Exception>(() => service.Complete(999));
        }
    }
}