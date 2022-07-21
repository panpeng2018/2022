using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/<CustomerController>
        private readonly IHubContext<MessageHub> _hubContext;
        // GET: api/<CustomController>
        public CustomerController(IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        [HttpPost("{customerid}/score/{score}")]
        public bool Post(string customerid,string score)
        {
            var res= CustomController.UpdateList(Int64.Parse(customerid), decimal.Parse(score));
            _hubContext.Clients.All.SendAsync("show", "4444");
            return res;
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
