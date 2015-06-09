﻿using System;
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

            ///CommunityEvent[] communityEvents;

            var client = new System.Net.Http.HttpClient();
            client.Timeout = TimeSpan.FromMilliseconds(1);
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
            client.Timeout = TimeSpan.FromMilliseconds(1);
            client.BaseAddress = new Uri("http://mycommunity.nova.swisscloud.io");

            var response = await client.GetAsync("news");

            var eventsJson = response.Content.ReadAsStringAsync().Result;
            Debug.WriteLine("JSON String: " + eventsJson);
            var news = JsonConvert.DeserializeObject<News[]>(eventsJson);

            return news;

        }
    }
}

