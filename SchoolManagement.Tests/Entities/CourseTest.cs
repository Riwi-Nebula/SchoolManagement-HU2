using System.Collections.Generic;
using FluentAssertions;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Tests;

public class CourseTest
{
    [Fact]
    public void Course_Defaults_ShouldHaveIdZeroAndNullSections()
    {
        // arrange
        var course = new Course();

        // assert
        course.Id.Should().Be(0);
        // Name and Description are not initialized in code; depending on compiler settings they may be null.
        // If you prefer non-null behavior, consider inicializarlos en la entidad.
        course.Name.Should().BeNull();       
        course.Description.Should().BeNull();
        course.Sections.Should().BeNull();
    }

    [Fact]
    public void CreateCourse_ShouldSetPropertiesCorrectly()
    {
        var course = new Course
        {
            Id = 1,
            Name = "Mathematics",
            Description = "Basic algebra and geometry"
        };

        Assert.Equal(1, course.Id);
        Assert.Equal("Mathematics", course.Name);
        Assert.Equal("Basic algebra and geometry", course.Description);
    }
}