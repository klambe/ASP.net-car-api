
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;


namespace CarClient
{
    class Program
    {
        // get all stock listings
        static async Task GetAllAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:7254/");                             // base URL for API Controller i.e. RESTFul service

                    // add an Accept header for JSON
                    client.DefaultRequestHeaders.
                        Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // GET ../api/stock
                    // get all stock listings
                    HttpResponseMessage response = await client.GetAsync("api/cars");                  // async call, await suspends until result available            
                    if (response.IsSuccessStatusCode)                                                   // 200..299
                    {
                        // read result 
                        var listings = await response.Content.ReadAsAsync<IEnumerable<Car>>();
                        foreach (var listing in listings)
                        {
                            Console.WriteLine(listing.ID + " " + listing.Registration + " " + listing.Price + " " + listing.Vat + " " + listing.Vin );
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        // delete a stock listing
        static async Task DeleteAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:7254/");

                    // de-list Google
                    // Delete/api/FB                                                    
                    HttpResponseMessage response = await client.DeleteAsync("api/Cars/8");
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static void Main(string[] args)
        {
            GetAllAsync().Wait();
            DeleteAsync().Wait();
            GetAllAsync().Wait();
        }
    }
}
