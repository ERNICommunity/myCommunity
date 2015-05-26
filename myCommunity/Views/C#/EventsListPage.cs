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
			var b = new Button { Text = "Refresh" };
			var spinner = new ActivityIndicator
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Color = Color.Black,
				IsVisible = false 
			};

			// for now, make the fetching of the list a manual thing by clicking on this button
			b.Clicked += async (sender, e) => {

				// grab the list as an array of CommunityEvents from the webservice
				var webservice = new RestClient ();

				// start a activity indicator
				spinner.IsVisible=true;
				spinner.IsRunning=true;

				// try to fetch from the webservice
				var communityEventsArray = await webservice.GetEventsAsync ();

				// stop activity indicator
				spinner.IsVisible=false;
				spinner.IsRunning=false;

				Debug.WriteLine (communityEventsArray.ToString ());
				// and assign it to the list source
				listView.ItemsSource = communityEventsArray;
			};
			// the list view items will take their layout from a custom ViewCell class
			listView.ItemTemplate = new DataTemplate (typeof(EventViewCell));

			// handler for list item clicks
			listView.ItemSelected += (sender, e) => {
				
				// get the current CommunityEvent selected by the user and assign it to a temp variable
				var communityEvent = (CommunityEvent)e.SelectedItem;

//				DisplayAlert("Event info", communityEvent.ToString(), "OK", "cancel");

//				create the DetailsPage
				var detailsPage = new DetailsXaml();

//				bind the CommunityEvent source to the DetailsPage target
				detailsPage.BindingContext = communityEvent;

//				bring up the details page
				Navigation.PushAsync (detailsPage);

											
			};

			// set stack layout and add the listview to this
			var layout = new StackLayout ();
			layout.Children.Add (b);
			layout.Children.Add (spinner);
			layout.Children.Add (listView);
			layout.VerticalOptions = LayoutOptions.FillAndExpand;

			//set the content property of the Content Page to the defined layout with it's children (i.e. the list)
			Content = layout;
		}


	}

}

