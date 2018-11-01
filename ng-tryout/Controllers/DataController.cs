using Microsoft.AspNetCore.Mvc;
using Ngtryout.Infrastructure;
using Ngtryout.Models;
using System;
using System.Threading.Tasks;

namespace Ngtryout.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {

        private readonly IDataRepository _repo;

        public DataController(IDataRepository dr)
        {
            _repo = dr;
        }

        [HttpGet]
        public async Task<JsonResult> Get() =>
           new JsonResult(await _repo.GetAllDataPoints());


        [HttpGet("{id}", Name = "Get")]
        public async Task<JsonResult> Get(string id) =>
            new JsonResult(await _repo.GetDatapoint(id));


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string name)
        {
            var dp = new DatapointDomain(name, DateTime.Now, new Random().Next());
            if (!await _repo.AddDatapoint(dp))
                return BadRequest();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(string id, [FromBody] string name, double value)
        {
            var status = await _repo.UpdateDatapoint(id, name, value);
            if (!status)
                return BadRequest();
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var status = await _repo.DeleteDatapoint(id);
            if (!status)
                return BadRequest();
            return Ok();
        }

        public void TriggerSocket()
        {

        }
    }
}
