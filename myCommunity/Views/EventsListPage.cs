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
			listView.ItemsSource = MockData.getMockData();

			// the list view items will take their layout from a custom ViewCell class
			listView.ItemTemplate = new DataTemplate (typeof(EventViewCell));

			// handler for list item clicks
			listView.ItemSelected += (sender, e) => {
				
				// get the current CommunityEvent selected by the user and assign it to a temp variable
				var communityEvent = (CommunityEvent)e.SelectedItem;
				// create the DetailsPage
				var detailsPage = new DetailsXaml();
				// bind the CommunityEvent source to the DetailsPage target
				detailsPage.BindingContext = communityEvent;
				// bring up the details page
				Navigation.PushAsync (detailsPage);
							
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

