using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pomodoro.Server.DbContexts;
using Pomodoro.Server.Models;

namespace Pomodoro.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly EntryDbContexts _entryDbContext;
         
        public UserController(ILogger<UserController> logger, EntryDbContexts entryDbContexts)
        {
            _logger = logger;
            _entryDbContext = entryDbContexts;
        }

        // GET: api/<EntryController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _entryDbContext.users.ToArray();
        }

        //Add Users
        [HttpPost]
        public async Task<IActionResult> SaveUser([FromBody] User user)
        {
            //_entryDbContexts.users.Add(user);
            //await _entryDbContexts.SaveChangesAsync();
            //_logger.LogInformation("User details has saved.");
            //return Ok(user);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingEntry = await _entryDbContext.users.FindAsync(user.UserId);
            if (existingEntry != null)
            {
                // If the entity already exists, return a conflict response
                return Conflict("A user with the same ID already exists.");
            }

            _entryDbContext.users.Add(user);
            await _entryDbContext.SaveChangesAsync();

            return Ok(user);

        }
    }
}
