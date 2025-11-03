using SchoolManagement.Application.Services;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Tests.Services;

public class StudentServiceTest
{
    [Fact]
    public async Task GetAllAsync_ReturnsStudents()
    {
        var repoMock = new Mock<IStudentRepository>();
        repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Student>
        {
            new Student { Id = 1, Name = "A" },
            new Student { Id = 2, Name = "B" }
        });

        var service = new StudentService(repoMock.Object);

        var result = await service.GetAllAsync();

        result.Should().HaveCount(2);
        repoMock.Verify(r => r.GetAllAsync(), Times.Once);
    }

    [Fact]
    public async Task AddAsync_CallsRepositoryAdd()
    {
        var repoMock = new Mock<IStudentRepository>();
        var service = new StudentService(repoMock.Object);
        var student = new Student { Id = 0, Name = "New" };

        await service.AddAsync(student);

        repoMock.Verify(r => r.AddAsync(student), Times.Once);
    }
}