using CallMeMaybe.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace CallMeMaybe
{
    public class ItemBuilder
    {
        // Recursive
        public IList<IList<Item>> BuildCombos(IList<Item> list)
        {
            var result = new List<IList<Item>>
            {
                new List<Item>{ list[0] }
            };

            if (list.Count == 1)
                return result;

            var tailCombos = BuildCombos(list.Skip(1).ToList());
            foreach (var combo in tailCombos)
            {
                result.Add(new List<Item>(combo));
                combo.Add(list[0]);
                result.Add(new List<Item>(combo));
            }
            return result;
        }


        private void CallMeHelper()
        {
            HttpClient client = new HttpClient();

            //var newRoute = new FibExample { value = fibNum.value - 1 };
            //var result = client.PostAsJsonAsync(GlobalStrings.baseURL + "fib", newRoute);
            //result.Wait();
            //var x = result.Result.Content.ReadAsAsync<FibExample>();
            //x.Wait();
        }
    }
}
