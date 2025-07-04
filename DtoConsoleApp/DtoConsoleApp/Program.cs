// This program demonstrates how to use a Data Transfer Object (DTO) to retrieve and display
// person data from a web API. In a financial context, this pattern is useful for securely
// transferring customer or account data between services or applications, ensuring only
// necessary information is exposed to the client.
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Call the Person API to retrieve person data
        using var client = new HttpClient();
        // Adjust the URL as needed if running on a different port
        var person = await client.GetFromJsonAsync<Person>("http://localhost:5026/api/person");
        if (person != null)
        {
            // Map the received data to a DTO for secure transfer and display
            var personDto = new PersonDto
            {
                Id = person.Id, // Only expose the ID
                Name = person.Name, // Only expose the Name
                Email = person.Email // Now also expose the Email for financial notifications
            };
            // In a financial app, this could be used to show customer info without sensitive data
            Console.WriteLine($"DTO: Id={personDto.Id}, Name={personDto.Name}, Email={personDto.Email}");
        }
        else
        {
            Console.WriteLine("Failed to retrieve person from API.");
        }
    }
}
// Note: The Person and PersonDto classes should match the data contract expected from the API.
// This approach helps maintain security and clarity in financial software by controlling data exposure.
