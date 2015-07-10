using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace myCommunity.Models
{
    public class CommunityEvent : BaseEvent
    {
        public CommunityEvent()
        {

        }

        // inherits "id", "title", "description", "short description" from BaseEvent

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("organiser")]
        public string Organiser { get; set; }

        [JsonProperty("eventDate")]
        public string EventDate { get; set; }

        [JsonProperty("eventTime")]
        public string EventTime { get; set; }

        [JsonProperty("isFood")]
        public bool IsFood { get; set; }

        [JsonProperty("bookablehours")]
        public int BookableTime { get; set; }

        public bool Favorite { get; set; }
        // won't have a json property, as it is only set by the user

        [JsonProperty("pictureurl")]
        public string PictureUrl { get; set; }

        [JsonProperty("participants")]
        public List<string> Participants { get; set; }

        [JsonIgnore]
        public List<Person> Attendees
        {
            get
            {
                var attendees = new List<Person>();
                if (Participants != null)
                    foreach (var i in Participants)
                        attendees.Add(new Person { Name = i });

                return attendees;
            }
        }

    }


}

