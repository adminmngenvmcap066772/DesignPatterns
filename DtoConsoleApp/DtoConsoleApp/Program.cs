// See https://aka.ms/new-console-template for more information
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Call the Person API
        using var client = new HttpClient();
        // Adjust the URL as needed if running on a different port
        var person = await client.GetFromJsonAsync<Person>("http://localhost:5026/api/person");
        if (person != null)
        {
            var personDto = new PersonDto
            {
                Id = person.Id,
                Name = person.Name
            };
            Console.WriteLine($"DTO: Id={personDto.Id}, Name={personDto.Name}");
        }
        else
        {
            Console.WriteLine("Failed to retrieve person from API.");
        }
    }
}
