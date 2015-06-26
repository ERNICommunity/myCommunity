using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using myCommunity.Models;

namespace myCommunity.Services
{
    public class RestClient : IRestRepository
    {
        public RestClient()
        {
        }

        public async Task<CommunityEvent[]> GetEventsAsync()
        {

            var client = new System.Net.Http.HttpClient();
            client.Timeout = TimeSpan.FromSeconds(30);
            client.BaseAddress = new Uri("http://mycommunity.nova.swisscloud.io");

            var response = await client.GetAsync("events");

            var eventsJson = response.Content.ReadAsStringAsync().Result;
            Debug.WriteLine("JSON String: " + eventsJson);

            var communityEvents = JsonConvert.DeserializeObject<CommunityEvent[]>(eventsJson);



            return communityEvents;

        }

        public async Task<News[]> GetNewsAsync()
        {

            var client = new System.Net.Http.HttpClient();
            client.Timeout = TimeSpan.FromSeconds(30);
            client.BaseAddress = new Uri("http://mycommunity.nova.swisscloud.io");

            var response = await client.GetAsync("news");

			var newsJson = response.Content.ReadAsStringAsync().Result;
            Debug.WriteLine("JSON String: " + newsJson);
            var news = JsonConvert.DeserializeObject<News[]>(newsJson);

            return news;

        }
    }
}

