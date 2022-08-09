using CacheServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

namespace CacheServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        readonly AppDbContext _dbcontext;
        private readonly IDistributedCache _cache;
        private readonly IConfiguration _configuration;

        public ProductController(AppDbContext appDbContext, IConfiguration configuration, IDistributedCache cache)
        {
            _dbcontext = appDbContext;
            _configuration = configuration;
            _cache = cache;


        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(bool enableCache)
        {
            var data = new List<product>();
            string cacheKey = "key";
            //if (!enableCache)
            //{
            //    return Ok(_dbcontext.products.ToList());
            //}
            byte[] cachedData = await _cache.GetAsync(cacheKey);
            if (cachedData != null)
            {
                // If the data is found in the cache, encode and deserialize cached data.
                var cachedDataString = Encoding.UTF8.GetString(cachedData);
                data = JsonSerializer.Deserialize<List<product>>(cachedDataString);
            }
            else
            {
                // If the data is not found in the cache, then fetch data from database
                data = _dbcontext.products.ToList();

                // Serializing the data
                string cachedDataString = JsonSerializer.Serialize(data);
                var dataToCache = Encoding.UTF8.GetBytes(cachedDataString);

                // Setting up the cache options
                DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(15))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5));
                // Add the data into the cache
                await _cache.SetAsync(cacheKey, dataToCache, options);
            }

            return Ok(data);
        }
        [HttpPost("SaveRecords")]
        public IActionResult SaveRecords([FromBody] List<long> time)
        {
            for (int i = 0; i < time.Count(); i++)
            {
                var newTime = new ExecuteTime { Method = "RedisCache", Time = time[i] };
                _dbcontext.executetimes.Add(newTime);
            }
            _dbcontext.SaveChanges();
            return Ok();

        }


    }
}