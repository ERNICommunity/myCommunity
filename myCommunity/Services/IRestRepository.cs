﻿using myCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myCommunity.Services
{
    public interface IRestRepository
    {
        Task<CommunityEvent[]> GetEventsAsync();
        Task<News[]> GetNewsAsync();
        Task<SignUpResponse> EventSignUpAsync(string eventId, string username);
    }
}
