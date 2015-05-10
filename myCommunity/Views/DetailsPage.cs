using System;

using Xamarin.Forms;
using System.Diagnostics;

namespace myCommunity
{
	public class DetailsPage : ContentPage
	{
		public DetailsPage ()
		{
			this.SetBinding (ContentPage.TitleProperty, "Topic"); // display the "topic" field as the title of the page

			// set the page to allow back navigation
			NavigationPage.SetHasNavigationBar (this, true);

			// display the detail fields
			// ... the type
			var typeLabel = new Label { Text = "Event type:" };
			var typeContent = new Label ();
			typeContent.SetBinding (Label.TextProperty, "Type");

//			// ... the location
			var locationLabel = new Label { Text = "Location:" };
			var locationContent = new Label ();
			locationContent.SetBinding (Label.TextProperty, "Location");

			// ... the date and time TODO

			// and so on...


			Content = new StackLayout {
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness(20),
				Children = {
					typeLabel,
					typeContent,
					locationLabel,
					locationContent
				}
			};
		}
	}


}

