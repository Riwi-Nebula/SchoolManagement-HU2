using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Api.Controllers;
using SchoolManagement.Application.Interfaces;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Tests.Controllers;

public class StudentControllerTest
{
    [Fact]
    public async Task GetAll_ReturnsOkWithStudents()
    {
        var svcMock = new Mock<IStudentService>();
        svcMock.Setup(s => s.GetAllAsync()).ReturnsAsync(new List<Student>
        {
            new Student { Id = 1, Name = "A" }
        });

        var controller = new StudentController(svcMock.Object);
        var actionResult = await controller.GetAll();

        var okResult = actionResult as OkObjectResult;
        okResult.Should().NotBeNull();
        var list = okResult.Value as IEnumerable<Student>;
        list.Should().HaveCount(1);
    }

    [Fact]
    public async Task Delete_CallsServiceAndReturnsNoContent()
    {
        var svcMock = new Mock<IStudentService>();
        svcMock.Setup(s => s.DeleteAsync(It.IsAny<Student>())).Returns(Task.CompletedTask);

        var controller = new StudentController(svcMock.Object);
        var result = await controller.Delete(1);

        result.Should().BeOfType<NoContentResult>();
        svcMock.Verify(s => s.DeleteAsync(It.Is<Student>(st => st.Id == 1)), Times.Once);
    }
}