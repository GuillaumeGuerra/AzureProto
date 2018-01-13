using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureProto.Controllers
{
    [Produces("application/json")]
    [Route("api/Sweets")]
    public class SweetsController : Controller
    {
        private static List<Sweet> sweets = new List<Sweet>
            {
                new  Sweet()
                {
                    Id = 0,
                    Name = "Nutella",
                    Level = "Awesome"
                },
                new  Sweet()
                {
                    Id = 1,
                    Name = "Chocolate",
                    Level = "Amazing"
                },
                new  Sweet()
                {
                    Id = 2,
                    Name = "Vegetables",
                    Level = "Grrrrrr"
                }
            };

        public static List<Sweet> Sweets { get => sweets; set => sweets = value; }

        // GET: api/Sweets
        [HttpGet]
        public IEnumerable<Sweet> GetAllSweets()
        {
            return Sweets;
        }

        // GET: api/Sweets/5
        [HttpGet("{id}", Name = "Get")]
        public Sweet GetSweet(int id)
        {
            return Sweets.First(s => s.Id == id);
        }

        // POST: api/Sweets
        [HttpPost]
        public Sweet PostSweet([FromBody]Sweet value)
        {
            Sweets.Add(value);
            return value;
        }

        // PUT: api/Sweets/5
        [HttpPut("{id}")]
        public Sweet PutSweet(int id, [FromBody]Sweet value)
        {
            DeleteSweet(value.Id);
            Sweets.Add(value);
            return value;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Sweet DeleteSweet(int id)
        {
            var deleted = GetSweet(id);
            Sweets = Sweets.Where(s => s.Id != id).ToList();
            return deleted;
        }
    }
}
