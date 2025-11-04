using Xunit;
using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace SchoolManagement.Tests.Endpoints;

public class StudentEndpointsTest
{
    public class StudentEndpointsTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public StudentEndpointsTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllStudents_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/students"); // ajusta la ruta
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var data = await response.Content.ReadFromJsonAsync<IEnumerable<object>>();
            data.Should().NotBeNull();
        }

        [Fact]
        public async Task CreateStudent_ReturnsCreatedOrNoContent()
        {
            var newStudent = new { Name = "Integration", LastName = "Test", Email = "i@test.com" };
            var resp = await _client.PostAsJsonAsync("/api/students", newStudent);
            resp.StatusCode.Should().BeOneOf(HttpStatusCode.Created, HttpStatusCode.NoContent, HttpStatusCode.OK);
        }
    }
}