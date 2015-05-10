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
		public string Responsible { get; set; }
		public DateTime EventDateTime { get; set; }
		public bool IsFood { get; set; }
		public int BookableTime { get; set; }


	}
}

