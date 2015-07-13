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

		public CommunityEventCollection (DateTime date)
		{
			Title = string.Format("{0} {1}", date.ToString("MM"), date.Year);
			LongTitle = string.Format("{0} {1}", date.ToString("MMMM"), date.Year);
			Items = new List<CommunityEvent> ();
		}

		public List<CommunityEvent> Items { get; set;}
	}
}

