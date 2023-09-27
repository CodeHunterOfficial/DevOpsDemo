using DevOpsDemo.Controllers;
using DevOpsDemo.Models;
using DevOpsDemo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsDemo.Test
{
    // Определение класса PostTestController для тестирования HomeController
    public class PostTestController
    {
        private PostRepository repository;

        // Конструктор класса, создающий экземпляр репозитория PostRepository
        public PostTestController()
        {
            repository = new PostRepository();
        }

        // Юнит-тест для проверки, что результат выполнения метода Index является объектом типа ViewResult
        [Fact]
        public void Test_Index_View_Result()
        {
            // Arrange
            // Создаем экземпляр контроллера HomeController и передаем ему экземпляр репозитория PostRepository
            var controller = new HomeController(this.repository);

            // Act
            // Вызываем метод Index контроллера HomeController
            var result = controller.Index();

            // Assert
            // Проверяем, что результат выполнения метода Index является объектом типа ViewResult
            Assert.IsType<ViewResult>(result);
        }

        // Юнит-тест для проверки, что результат выполнения метода Index не равен null
        [Fact]
        public void Test_Index_Return_Result()
        {
            // Arrange
            // Создаем экземпляр контроллера HomeController и передаем ему экземпляр репозитория PostRepository
            var controller = new HomeController(this.repository);

            // Act
            // Вызываем метод Index контроллера HomeController
            var result = controller.Index();

            // Assert
            // Проверяем, что результат выполнения метода Index не равен null
            Assert.NotNull(result);
        }

        // Юнит-тест для проверки, что результат выполнения метода Index содержит коллекцию объектов типа PostViewModel
        // и что каждый элемент коллекции имеет определенные значения свойств, в том числе PostId и Title.
        [Fact]
        public void Test_Index_GetPosts_MatchData()
        {
            // Arrange
            // Создаем экземпляр контроллера HomeController и передаем ему экземпляр репозитория PostRepository
            var controller = new HomeController(this.repository);

            // Act
            // Вызываем метод Index контроллера HomeController
            var result = controller.Index();

            // Assert
            // Проверяем, что результат выполнения метода Index является объектом типа ViewResult
            var viewResult = Assert.IsType<ViewResult>(result);
            // Получаем модель представления из ViewData объекта
            var model = Assert.IsAssignableFrom<IEnumerable<PostViewModel>>(viewResult.ViewData.Model);
            // Проверяем, что модель представления содержит три элемента
            Assert.Equal(3, model.Count());
            // Проверяем, что первый элемент коллекции имеет значение свойства PostId равное 101
            Assert.Equal(101, model.ElementAt(0).PostId);
            // Проверяем, что первый элемент коллекции имеет значение свойства Title равное "DevOps Demo Title1"
            Assert.Equal("DevOps Demo Title1", model.ElementAt(0).Title);
        }
    }
}
