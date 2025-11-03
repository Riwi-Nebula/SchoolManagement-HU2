using Moq;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using SchoolManagement.Application.Services;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Tests.Services;

public class CourseServiceTest
{
    [Fact]
    public async Task GetAllAsync_ShouldReturnAllCourses()
    {
        // Arrange
        var mockRepo = new Mock<ICourseRepository>();
        mockRepo.Setup(r => r.GetAllCoursesAsync()).ReturnsAsync(new List<Course>
        {
            new Course { Id = 1, Name = "Math" },
            new Course { Id = 2, Name = "Science" }
        });

        var service = new CourseService(mockRepo.Object);

        // Act
        var result = await service.GetAllCoursesAsync();

        // Assert
        result.Should().HaveCount(2);
        mockRepo.Verify(r => r.GetAllCoursesAsync(), Times.Once);
    }

    [Fact]
    public async Task AddAsync_ShouldCallRepositoryAdd()
    {
        var mockRepo = new Mock<ICourseRepository>();
        var service = new CourseService(mockRepo.Object);
        var course = new Course { Name = "Physics" };

        await service.AddCourseAsync(course);

        mockRepo.Verify(r => r.AddCourseAsync(It.Is<Course>(c => c.Name == "Physics")), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallRepositoryDelete()
    {
        var mockRepo = new Mock<ICourseRepository>();
        var service = new CourseService(mockRepo.Object);
        var course = new Course { Id = 1, Name = "History" };

        await service.DeleteCourseAsync(1);

        mockRepo.Verify(expression: r => r.DeleteCourseAsync(1));
    }
}