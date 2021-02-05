using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AddMeSnaps_Poster
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }
        static async Task MainAsync()
        {
            Console.WriteLine("Type Victims Name: ");
            var victim = Console.ReadLine();
            Console.WriteLine("Type Mins Before Each Post: ");
            var Delay = Console.ReadLine();
            while (true)
            {
                HttpClient proxyclient = new HttpClient();
                var response = await proxyclient.GetAsync("https://gimmeproxy.com/api/getProxy?ipPort=true&get=true&supportsHttps=true&maxCheckPeriod=60");
                HttpClient client = new HttpClient(new HttpClientHandler { Proxy = new WebProxy(await response.Content.ReadAsStringAsync()), UseProxy = true });
                await client.GetAsync("https://www.addmesnaps.com/index.php?snapname=" + victim + "$user&age=1&gender=female");
                await Task.Delay(TimeSpan.FromMinutes(Convert.ToDouble(Delay)));
            }
        }
    }
}
