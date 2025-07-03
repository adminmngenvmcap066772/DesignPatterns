using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    [HttpGet]
    public ActionResult<Person> Get()
    {
        var person = new Person { Id = 1, Name = "Alice", Email = "alice@example.com" };
        return Ok(person);
    }
}
