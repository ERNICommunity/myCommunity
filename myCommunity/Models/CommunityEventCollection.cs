using System;
using myCommunity.Models;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace myCommunity
{
	public class CommunityEventCollection : ObservableCollection<CommunityEvent>
	{
		public string Title { get; private set;}
		public string LongTitle { get; private set; }

		public CommunityEventCollection (string title)
		{
			Title = title;
			LongTitle = title;
			Items = new List<CommunityEvent> ();
		}

		public List<CommunityEvent> Items { get; set;}
	}
}

