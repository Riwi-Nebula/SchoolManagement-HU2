using FluentAssertions;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Tests;

public class SudentTest
{
    [Fact]
    public void Student_Defaults_ShouldHaveEmptyStringsAndIdZero()
    {
        // arrange & act
        var student = new Student();

        // assert
        student.Id.Should().Be(0);
        student.Name.Should().BeNullOrEmpty();      // inherited from Person (default "")
        student.LastName.Should().BeNullOrEmpty();  // inherited from Person (default "")
        student.Email.Should().BeNullOrEmpty();     // default ""
    }

    [Fact]
    public void Student_CanAssignProperties()
    {
        // arrange
        var student = new Student
        {
            Id = 42,
            Name = "Tony",
            LastName = "Stark",
            Email = "tony.stark@starkindustries.com"
        };

        // act & assert
        student.Id.Should().Be(42);
        student.Name.Should().Be("Tony");
        student.LastName.Should().Be("Stark");
        student.Email.Should().Be("tony.stark@starkindustries.com");
    }
}