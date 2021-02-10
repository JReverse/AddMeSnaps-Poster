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
                retry:
                try
                {
                    var PostParams = new Dictionary<string, string>();
                    PostParams.Add("snapname", victim);
                    PostParams.Add("age", "1");
                    PostParams.Add("gender", "female");
                    HttpClient proxyclient = new HttpClient();
                    var response = await proxyclient.GetAsync("https://gimmeproxy.com/api/getProxy?ipPort=true&get=true&supportsHttps=true&maxCheckPeriod=60");
                    HttpClient client = new HttpClient(new HttpClientHandler { Proxy = new WebProxy(await response.Content.ReadAsStringAsync()), UseProxy = true });
                    await client.PostAsync("https://www.addmesnaps.com/index.php", new FormUrlEncodedContent(PostParams));
                    await Task.Delay(TimeSpan.FromMinutes(Convert.ToDouble(Delay)));
                }
                catch (Exception) {
                    goto retry;
                }
            }
        }
    }
}
