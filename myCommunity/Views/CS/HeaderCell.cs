using System;
using Xamarin.Forms;

namespace myCommunity
{
	public class HeaderCell : ViewCell 
	{ 
		public HeaderCell() 
		{ 
			this.Height = 50; 
			var label = new Label 
			{ 
				Font = Font.SystemFontOfSize(NamedSize.Medium, FontAttributes.Bold), 
				TextColor = Color.White, 
				VerticalOptions = LayoutOptions.Center 
			};   
			label.SetBinding(Label.TextProperty, new Binding("LongTitle"));   

			View = new StackLayout 
			{ 
				HorizontalOptions = LayoutOptions.FillAndExpand, 
				HeightRequest = 50, 
				BackgroundColor = Color.Navy, 
				Padding = 5, 
				Orientation = StackOrientation.Horizontal, 
				Children = { label } 
			}; 
		} 
	} 
}