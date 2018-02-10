using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CallMeMaybe.Models;
using System.Net.Http;

namespace CallMeMaybe.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        [HttpPost("{fib}")]
        public FibExample Post([FromBody]FibExample fibNum)
        {
            if (fibNum.value == 0)
            {
                return new FibExample { value = 1 };
            }

            HttpClient client = new HttpClient();

            var newRoute = new FibExample { value = fibNum.value - 1 };
            var result = client.PostAsJsonAsync("http://localhost:52404/api/values/fib", newRoute);
            result.Wait();
            var x = result.Result.Content.ReadAsAsync<FibExample>();
            x.Wait();

            return new FibExample { value = fibNum.value * x.Result.value };
        }


        [HttpPost("{build}")]
        public IList<IList<Item>> Post([FromBody]ItemRequest itemRequest)
        {
            if (itemRequest.Items.Count == 0)
            {
                return new List<IList<Item>>();
            }

            var builder = new ItemBuilder();
            return builder.BuildCombos(itemRequest.Items);
        }



        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
