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
			var eventType = new Label ();
			eventType.SetBinding (Label.TextProperty, "Type");

//			// ... the location
			var locationLabel = new Label { Text = "Location:" };
			var eventLocation = new Label ();
			eventLocation.SetBinding (Label.TextProperty, "Location");

			// ... the date and time (just showing as a string for now)
			var dateTimeLabel = new Label { Text = "When:" };
			var eventDateTime = new Label ();
			eventDateTime.SetBinding (Label.TextProperty, "EventDateTime".ToString());

			// ... the organiser / reponsible person
			var responsibleLabel = new Label { Text = "Organiser:" };
			var eventResponsible = new Label ();
			eventResponsible.SetBinding (Label.TextProperty, "Responsible");

			// ... the organiser / reponsible person
			var isFoodLabel = new Label { Text = "Food provided:" };
			var isFoodSwitch = new Switch ();
			isFoodSwitch.SetBinding (Switch.IsToggledProperty, "IsFood");

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness(20),
				Children = {
					typeLabel,
					eventType,
					locationLabel,
					eventLocation,
					dateTimeLabel,
					eventDateTime,
					responsibleLabel,
					eventResponsible,
					isFoodLabel,
					isFoodSwitch
				}
			};
		}
	}


}

