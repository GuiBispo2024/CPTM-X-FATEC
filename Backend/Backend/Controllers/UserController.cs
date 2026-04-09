using Backend.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _service;

    public UserController(UserService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var users = _service.GetUsers();
        return Ok(users);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Users user)
    {
        try
        {
            var createdUser = _service.CreateUser(user);

            return CreatedAtAction(nameof(Get), new { id = createdUser.Id }, createdUser);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Users user)
    {
        try
        {
            var updated = _service.UpdateUser(id, user);

            if (!updated)
                return NotFound("Usuário não encontrado");

            return Ok("Atualizado com sucesso");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = _service.DeleteUser(id);

        if (!deleted)
            return NotFound("Usuário não encontrado");

        return Ok("Deletado com sucesso");
    }
}