using Microsoft.AspNetCore.Mvc;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchValueController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SearchValueController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("fetch")]
        public async Task<IEnumerable<SearchModel>> Get()
        {
            return await _context.SearchModels.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
                return BadRequest();

            var searchResponse = await _context.SearchModels.FirstOrDefaultAsync(m => m.Id == id);
            if (searchResponse == null)
                return NotFound();

            return Ok(searchResponse);
        }

        [HttpPost("store")]
        public async Task<IActionResult> Post(SearchModel searchModel)
        {
            _context.Add(searchModel);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(SearchModel searchData)
        {
            if (searchData == null || searchData.Id == 0)
                return BadRequest();

            var search = await _context.SearchModels.FindAsync(searchData.Id);
            if (search == null)
                return NotFound();
            search.SearchValue = searchData.SearchValue;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();
            var searchData = await _context.SearchModels.FindAsync(id);
            if (searchData == null)
                return NotFound();
            _context.SearchModels.Remove(searchData);
            await _context.SaveChangesAsync();
            return Ok();

        }

    }
}
