using System;

namespace myCommunity
{
	public class CommunityEvent
	{
		public CommunityEvent ()
		{
			
		}

		public int ID { get; set; }
		public string Topic { get; set; }
		public string Type { get; set; }
		public string Location { get; set; }
		public string Description { get; set; }
		public string Responsible { get; set; }
		public string EventDate { get; set; } // TODO make this a proper DateTime
		public string EventTime { get; set; } // TODO make this a proper DateTime... need to then StringFormat in the XAML
		public bool IsFood { get; set; }
		public int BookableTime { get; set; }


	}
}

