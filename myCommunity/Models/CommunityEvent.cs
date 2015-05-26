using System;

namespace myCommunity
{
	public class CommunityEvent
	{
		public CommunityEvent ()
		{
			
		}

//		public int ID { get; set; }
//		public string Topic { get; set; }
//		public string Type { get; set; }
//		public string Location { get; set; }
//		public string Description { get; set; }
//		public string Responsible { get; set; }
//		public string EventDate { get; set; } // TODO make this a proper DateTime
//		public string EventTime { get; set; } // TODO make this a proper DateTime... need to then StringFormat in the XAML
//		public bool IsFood { get; set; }
//		public int BookableTime { get; set; }
//		public bool Favorite { get; set; }

		public string id { get; set; }
		public string title { get; set; }
		public string description { get; set; }
		public string eventDate { get; set; }
		public string organiser { get; set; }
		public string bookablehours { get; set; }
		public string pictureurl { get; set; }

		public override string ToString ()
		{
			return String.Format ("{0}: {1}, {2}, {3}", id, title, organiser, eventDate);
		}
	}


}

