using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LeaderboardController : ControllerBase
    {
        // GET: api/<LeaderboardController>
        private readonly IHubContext<MessageHub> _hubContext;
        // GET: api/<CustomController>
        public LeaderboardController(IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }
        [HttpGet]
        public IActionResult Get(string start, string end)
        {
            var list = CustomController.GetList(int.Parse(start), int.Parse(end));
            _hubContext.Clients.All.SendAsync("show", "1111");
            return new JsonResult(list);
        }

        // GET api/<LeaderboardController>/5
        [HttpGet("{customerid}")]
        public IActionResult Get(string customerid, string high,string low)
        {
            var list = CustomController.GetList(int.Parse(customerid),int.Parse(high), int.Parse(low));
            _hubContext.Clients.All.SendAsync("show", "2222");
            return new JsonResult(list);
        }

        // POST api/<LeaderboardController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LeaderboardController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LeaderboardController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
