using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;

namespace SchoolManagement.Tests.Endpoints;

public class CourseEndpointsTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public CourseEndpointsTest(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetAllCourses_ShouldReturnOk()
    {
        var response = await _client.GetAsync("/api/courses"); // Ajusta la ruta si es diferente
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task PostCourse_ShouldReturnCreatedOrOk()
    {
        var newCourse = new { Name = "IntegrationTest", Description = "Testing course" };
        var response = await _client.PostAsJsonAsync("/api/courses", newCourse);

        response.StatusCode.Should().BeOneOf(HttpStatusCode.Created, HttpStatusCode.OK, HttpStatusCode.NoContent);
    }
}