using Microsoft.AspNetCore.Mvc;
using Pomodoro.Server.DbContexts;
using Pomodoro.Server.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pomodoro.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly ILogger<EntryController> _logger;
        private readonly EntryDbContexts _entryDbContext;

        public EntryController(ILogger<EntryController> logger, EntryDbContexts entryDbContext)
        {
            _logger = logger;
            _entryDbContext = entryDbContext;
        }


        // GET: api/<EntryController>
        [HttpGet]
        public IEnumerable<Entry> Get()
        {
            return _entryDbContext.entries.ToArray();
        }

        // GET api/<EntryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EntryController>
        [HttpPost]
        public async Task<IActionResult> AddEntry([FromBody] Entry entry)
        {

            //_entryDbContext.entries.Add(entry);
            //await _entryDbContext.SaveChangesAsync();
            //_logger.LogInformation($"The data saved into Database.");
            //return Ok(entry);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = await _entryDbContext.entries.FindAsync(entry.EntryId);
            if (existingUser != null)
            {
                // If the entity already exists, return a conflict response
                return Conflict("A user with the same ID already exists.");
            }

            _entryDbContext.entries.Add(entry);
            await _entryDbContext.SaveChangesAsync();

            return Ok(entry);
        }



       
    }
}
