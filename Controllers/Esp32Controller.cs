using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace stickwebapi.Controllers
{
    [Route("api/smartstick1/data")]
    [ApiController]
    public class Esp32Controller : ControllerBase
    {
        private readonly Esp32Repository _repository;

        public Esp32Controller(Esp32Repository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BsonDocument data)
        {
            await _repository.InsertDataAsync(data);
            return Ok("Data saved");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _repository.GetDataAsync();
            return Ok(data);
        }
    }
}
