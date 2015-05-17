using System;

using Xamarin.Forms;

namespace myCommunity
{
	public class EventViewCell : ViewCell
	{
		public EventViewCell()
		{
			var topicLabel = new Label {
				YAlign = TextAlignment.Center
			};

			// bind the label to the "topic" property of the CommunityEvent class
			topicLabel.SetBinding (Label.TextProperty, "Topic");
		
			// create a stacklayout with one child, which is the topic (for now, at least)
			// ideas for later: we can show more details in a clever way, or with icons... and group by month
			var layout = new StackLayout {
				Padding = new Thickness (20, 0, 0, 0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = { topicLabel }
			};
			View = layout;
		}

	}


}

