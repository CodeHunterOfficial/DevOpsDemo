using DevOpsDemo.Controllers;
using DevOpsDemo.Models;
using DevOpsDemo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsDemo.Test
{
    // ����������� ������ PostTestController ��� ������������ HomeController
    public class PostTestController
    {
        private PostRepository repository;

        // ����������� ������, ��������� ��������� ����������� PostRepository
        public PostTestController()
        {
            repository = new PostRepository();
        }

        // ����-���� ��� ��������, ��� ��������� ���������� ������ Index �������� �������� ���� ViewResult
        [Fact]
        public void Test_Index_View_Result()
        {
            // Arrange
            // ������� ��������� ����������� HomeController � �������� ��� ��������� ����������� PostRepository
            var controller = new HomeController(this.repository);

            // Act
            // �������� ����� Index ����������� HomeController
            var result = controller.Index();

            // Assert
            // ���������, ��� ��������� ���������� ������ Index �������� �������� ���� ViewResult
            Assert.IsType<ViewResult>(result);
        }

        // ����-���� ��� ��������, ��� ��������� ���������� ������ Index �� ����� null
        [Fact]
        public void Test_Index_Return_Result()
        {
            // Arrange
            // ������� ��������� ����������� HomeController � �������� ��� ��������� ����������� PostRepository
            var controller = new HomeController(this.repository);

            // Act
            // �������� ����� Index ����������� HomeController
            var result = controller.Index();

            // Assert
            // ���������, ��� ��������� ���������� ������ Index �� ����� null
            Assert.NotNull(result);
        }

        // ����-���� ��� ��������, ��� ��������� ���������� ������ Index �������� ��������� �������� ���� PostViewModel
        // � ��� ������ ������� ��������� ����� ������������ �������� �������, � ��� ����� PostId � Title.
        [Fact]
        public void Test_Index_GetPosts_MatchData()
        {
            // Arrange
            // ������� ��������� ����������� HomeController � �������� ��� ��������� ����������� PostRepository
            var controller = new HomeController(this.repository);

            // Act
            // �������� ����� Index ����������� HomeController
            var result = controller.Index();

            // Assert
            // ���������, ��� ��������� ���������� ������ Index �������� �������� ���� ViewResult
            var viewResult = Assert.IsType<ViewResult>(result);
            // �������� ������ ������������� �� ViewData �������
            var model = Assert.IsAssignableFrom<IEnumerable<PostViewModel>>(viewResult.ViewData.Model);
            // ���������, ��� ������ ������������� �������� ��� ��������
            Assert.Equal(3, model.Count());
            // ���������, ��� ������ ������� ��������� ����� �������� �������� PostId ������ 101
            Assert.Equal(101, model.ElementAt(0).PostId);
            // ���������, ��� ������ ������� ��������� ����� �������� �������� Title ������ "DevOps Demo Title1"
            Assert.Equal("DevOps Demo Title1", model.ElementAt(0).Title);
        }
    }
}
