using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Linq;
using System;
using Microsoft.AspNetCore.SignalR;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomController : ControllerBase
    {
        private static List<Customer> list = new List<Customer>();
        [HttpGet]
        public List<Customer> Get()
        {
            return list.OrderByDescending(a => a.Score).ThenBy(a=>a.CustomerID).ToList(); 
        }

        // GET api/<CustomController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            try
            {
                for (var i = 0; i < id; i++)
                {
                    Customer ct = new Customer();
                    ct.CustomerID = list.Count + 1;
                    ct.Score = new Random().Next(1, 999999);
                    //ct.Score = 10;
                    list.Add(ct);
                }
                return list.Count.ToString();
            }
            catch(Exception ex) 
            {
                return ex.Message;
            }
        }
        // POST api/<CustomController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        
        public static bool UpdateList(Int64 customerid, decimal score)
        {
            try
            {
                var model = list.Where(c => c.CustomerID == customerid).FirstOrDefault();
                if (model != null)
                {
                    model.Score = model.Score+score;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static List<CustomerExt> GetList(int start, int end)
        {
            List<CustomerExt> newlist = new List<CustomerExt>();
            try
            {
                var lists = list.OrderByDescending(a => a.Score).ThenBy(a => a.CustomerID).ToList().GetRange(start-1, end-start+1);
                var i = start;
                foreach(var item in lists)
                {
                    CustomerExt cmd = new CustomerExt();
                    cmd.CustomerID = item.CustomerID;
                    cmd.Score = item.Score;
                    cmd.Rank = i;
                    i++;
                    newlist.Add(cmd);
                }
                return newlist;
            }
            catch
            {
                return newlist;
            }
        }
        public static List<CustomerExt> GetList(int customerid,int start, int end)
        {
            List<CustomerExt> newlist = new List<CustomerExt>();
            try
            {
                var listz = list.OrderByDescending(a => a.Score).ThenBy(a => a.CustomerID).ToList();
                var index = listz.FindIndex(u=>u.CustomerID== customerid);
                var lists = listz.GetRange(index - start, start + start+1);
                var i = start;
                foreach (var item in lists)
                {
                    CustomerExt cmd = new CustomerExt();
                    cmd.CustomerID = item.CustomerID;
                    cmd.Score = item.Score;
                    cmd.Rank = i;
                    i++;
                    newlist.Add(cmd);
                }
                return newlist;
            }
            catch
            {
                return newlist;
            }
        }
    }
}
