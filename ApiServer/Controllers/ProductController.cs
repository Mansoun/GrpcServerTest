using CacheServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace CacheServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        readonly AppDbContext _dbcontext;
        public ProductController(AppDbContext appDbContext)
        {
            _dbcontext = appDbContext;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = _dbcontext.products.ToList();
            return Ok(data);
        }
        [HttpPost("SaveRecords")]
        public IActionResult SaveRecords([FromBody]  List<long> time)
        {
            for (int i = 0; i < time.Count(); i++)
            {
                var newTime = new ExecuteTime { Method = "Api", Time = time[i] };
                _dbcontext.executetimes.Add(newTime);
            }
            _dbcontext.SaveChanges();
            return Ok();

        }


    }
}