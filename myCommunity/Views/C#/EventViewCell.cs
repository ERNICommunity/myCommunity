using System;

using Xamarin.Forms;

namespace myCommunity
{
	public class EventViewCell : ViewCell
	{
		public EventViewCell()
		{
			var topicLabel = new Label {
				FontAttributes = FontAttributes.Bold,
				XAlign = TextAlignment.Start,
				YAlign = TextAlignment.Center
			};
			var typeLabel = new Label {
				XAlign = TextAlignment.End
			};

			// bind the label to the "topic" property of the CommunityEvent class
			topicLabel.SetBinding (Label.TextProperty, "Topic");

			// bind the sublabel to the "type" property
			typeLabel.SetBinding (Label.TextProperty, "Type");

			// create a stacklayout with one child, which is the topic (for now, at least)
			// ideas for later: we can show more details in a clever way, or with icons... and group by month
			var layout = new StackLayout {
				Padding = new Thickness (20, 0, 0, 0),
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = { topicLabel, typeLabel }
			};
			View = layout;
		}

	}


}

