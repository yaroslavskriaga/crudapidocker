using crudapi.Models;
using crudapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace crudapi.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController: ControllerBase
{
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
        _userService = userService;
    }
    // GET: api/users
    [HttpGet]
    public async Task<ActionResult<List<User>>> Get()
    {
        return await _userService.Get();
    }

    // GET: api/user/{id}
    [HttpGet("{id}", Name = "Get")]
    public async Task<ActionResult<User>> Get(string id)
    {
        var u = await _userService.Get(id);
        if(u == null)
        {
            return NotFound();
        }

        return u;
    }

    
    // POST: api/user
    [HttpPost]
    public async Task<ActionResult<User>> Create([FromBody] User u)
    {
        await _userService.Create(u);
        return CreatedAtRoute("Get", new { id = u._id.ToString() }, u);

    }

    // PUT: api/user/{id}
    [HttpPut("{id}")]
    public  async Task<ActionResult<User>> Put(string id, [FromBody] User user)
    {
        var u = await _userService.Get(id);
        if (u == null)
        {
            return NotFound();
        }
        user._id = u._id;

        await _userService.Update(id, user);
        return CreatedAtRoute("Get", new { id = user._id.ToString() }, user);
    }

    // DELETE: api/user/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult<User>> Delete(string id)
    {
        var u = await _userService.Get(id);
        if (u == null)
        {
            return NotFound();
        } 
        
        await _userService.Delete(id);
        return Ok();
    }
}