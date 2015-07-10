using System;
using Xamarin.Forms;

namespace myCommunity
{
	public class GroupHeaderCell : ViewCell
	{
		public GroupHeaderCell()
		{
			this.Height = 50;
			var title = new Label
			{
				Font = Font.SystemFontOfSize(NamedSize.Small, FontAttributes.Bold),
				TextColor = Color.White,
				VerticalOptions = LayoutOptions.Center
			};
			title.SetBinding(Label.TextProperty, "Title");

			View = new StackLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 50,
				BackgroundColor = Color.Olive,
				Padding = 5,                
				Orientation = StackOrientation.Horizontal,
				Children = { title }
			};
		}
	}
}

