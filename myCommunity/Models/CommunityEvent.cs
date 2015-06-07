using System;
using Newtonsoft.Json;

namespace myCommunity.Models
{
	public class CommunityEvent
	{
		public CommunityEvent ()
		{
			
		}

		[JsonProperty ("id")]
		public string ID { get; set; }

		[JsonProperty ("title")]
		public string Title { get; set; }

		[JsonProperty ("type")]
		public string Type { get; set; }

		[JsonProperty ("location")]
		public string Location { get; set; }

		[JsonProperty ("description")]
		public string Description { get; set; }

		[JsonProperty ("organiser")]
		public string Organiser { get; set; }

		[JsonProperty ("eventDate")]
		public string EventDate { get; set; }

		[JsonProperty ("eventTime")]
		public string EventTime { get; set; }

		[JsonProperty ("isFood")]
		public bool IsFood { get; set; }

		[JsonProperty ("bookablehours")]
		public int BookableTime { get; set; }

		public bool Favorite { get; set; }
		// won't have a json property, as it is only set by the user

		[JsonProperty ("pictureurl")]
		public string PictureUrl { get; set; }

		public override string ToString ()
		{
			return String.Format ("{0}: {1}, {2}, {3}", ID, Title, Organiser, EventDate);
		}
	}


}

