using System;

// No top-level statements or hidden characters. Only the Program class in the correct namespace.
namespace FluentValidationConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var person = new Person { FirstName = "", LastName = "Smith", Age = 130 };
            var validator = new PersonValidator();
            var results = validator.Validate(person);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    Console.WriteLine($"Property {failure.PropertyName} failed validation. Error: {failure.ErrorMessage}");
                }
            }
            else
            {
                Console.WriteLine("Person is valid!");
            }
        }
    }
}
