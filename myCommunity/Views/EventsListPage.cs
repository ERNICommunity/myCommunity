using System;

using Xamarin.Forms;
using System.Diagnostics;

namespace myCommunity
{
	class EventsListPage : ContentPage
	{
		ListView listView;

		public EventsListPage ()
		{
			Title = "myCommunity Events";

			listView = new ListView ();

			// for now, just initialise the list view with an array of hard coded CommunityEvents

			listView.ItemsSource = new CommunityEvent [] {
				new CommunityEvent {Topic = "Xamarin"},
				new CommunityEvent {Topic = "Xamarin Hack Session"},
				new CommunityEvent {Topic = "Xamarin Hackathon"},
			};
			// the list view items will take their layout from a custom ViewCell class
			listView.ItemTemplate = new DataTemplate (typeof(EventViewCell));

			// handler for list item clicks
			listView.ItemSelected += (sender, e) => {
				Debug.WriteLine("clicked item " + e);
				// TODO
				// get the CommunityEvent that is selected and assign it to a temp variable

				// create the DetailsPage

				// bind the CommunityEvent object to the DetailsPage

				// bring up the DetailsPage
							
			};

			// set stack layout and add the listview to this
			var layout = new StackLayout ();
			layout.Children.Add (listView);
			layout.VerticalOptions = LayoutOptions.FillAndExpand;

			//set the content property of the Content Page to the defined layout with it's children (i.e. the list)
			Content = layout;
		}


	}

}

