// The PersonDto class is a Data Transfer Object (DTO) used to transfer data between processes.
// In a financial application, DTOs are useful for exposing only the necessary data to clients,
// such as when sharing customer information without sensitive details like account numbers or balances.
// This promotes security and separation of concerns.
public class PersonDto
{
    // Unique identifier for the person (e.g., customer ID in a banking system)
    public int Id { get; set; }
    // Name of the person (e.g., account holder's name)
    public string Name { get; set; }
    // Email address of the person (e.g., for sending financial statements or notifications)
    public string Email { get; set; }
}