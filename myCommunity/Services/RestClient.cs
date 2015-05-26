using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;

namespace myCommunity
{
	public class RestClient
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
	}
}

