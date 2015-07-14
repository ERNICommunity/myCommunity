using System;

namespace myCommunity
{
	public class FilterModel
	{
		public bool ShowMyEventsOnly { get; set; }

		public bool IsEquals(FilterModel p_Filter)
		{
			if (p_Filter != null && ShowMyEventsOnly == p_Filter.ShowMyEventsOnly) 
			{
				return true;
			}
			return false;
		}
	}
}

