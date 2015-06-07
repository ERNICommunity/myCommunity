using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using myCommunity.Models;

namespace myCommunity.Services
{
	public class RestClient : IRestRepository
	{
		public RestClient ()
		{
		}

		public async Task<CommunityEvent[]> GetEventsAsync () {

			var client = new System.Net.Http.HttpClient ();

			client.BaseAddress = new Uri("http://mycommunity.nova.swisscloud.io");

			var response = await client.GetAsync("events");

			var eventsJson = response.Content.ReadAsStringAsync().Result;
			Debug.WriteLine ("JSON String: " + eventsJson);

			CommunityEvent[] communityEvents = JsonConvert.DeserializeObject<CommunityEvent[]>(eventsJson);

			return communityEvents;

		}

        public async Task<News[]> GetNewsAsync()
        {

            var client = new System.Net.Http.HttpClient();

            client.BaseAddress = new Uri("http://mycommunity.nova.swisscloud.io");

            var response = await client.GetAsync("news");

            var eventsJson = response.Content.ReadAsStringAsync().Result;
            Debug.WriteLine("JSON String: " + eventsJson);

            News[] news = JsonConvert.DeserializeObject<News[]>(eventsJson);

            return news;

        }
	}
}

