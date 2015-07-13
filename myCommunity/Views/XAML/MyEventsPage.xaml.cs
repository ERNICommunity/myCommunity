using myCommunity.Models;
using myCommunity.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;
using Connectivity.Plugin;
using System.Collections.ObjectModel;

namespace myCommunity.Views.XAML
{
	public partial class MyEventsPage : ContentPage
	{
		public MyEventsPage()
		{
			InitializeComponent();
            MessagingCenter.Subscribe<DetailsPage>(this, "RefreshFromSignup", this.RefreshFromSignup);

        }

		protected string username = string.Empty;

        private void RefreshFromSignup(DetailsPage obj)
        {

            UpdateList();
            this.CheckForUser();
        }

        protected override void OnDisappearing()
        {
            this.MyListViewEvents.IsVisible = false;
            base.OnDisappearing();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.CheckForUser();
            this.MyListViewEvents.IsVisible = true;

            App.MainNavigation.BarTextColor = Color.FromHex("333333");
            App.MainNavigation.BarBackgroundColor = Color.FromHex("F0F0F0");

            // if the list is empty 

            if (MyListViewEvents.ItemsSource == null)
                UpdateList();

		}		
			
		private DateTime GetFirstDayOfMonthDate(string p_EventDate)
		{
			return new DateTime(DateTime.Parse (p_EventDate).Year, DateTime.Parse (p_EventDate).Month, 1);
		}
		private void CheckForUser()
        {
			if (Application.Current.Properties.ContainsKey(AppStrings.USERNAME))
				username = Application.Current.Properties[AppStrings.USERNAME] as string;

            if (!string.IsNullOrEmpty(username))
            {
                stkUser.IsVisible = true;
                lblUser.Text = string.Format("{0}", username);
            }
            else stkUser.IsVisible = false;
        }
        public async void UpdateList()
        {

            if (!CrossConnectivity.Current.IsConnected)
            {
                UserDialogs.Instance.Alert("Please check internet connection.", "No connection", "OK");
                return;
            }
            // grab the list as an array of CommunityEvents from the webservice
            var webservice = new RestClient();


			// start the activity indicator
			using (UserDialogs.Instance.Loading("Updating Events..."))
			{
				this.IsBusy = true;
				try
				{
					// try to fetch from the webservice
					var communityEventsArray =  await webservice.GetEventsAsync();

					var allListItemGroups = new ObservableCollection<CommunityEventCollection>();

					if(!communityEventsArray.Any())
					{
						UserDialogs.Instance.Alert("You didn't sign up for any events, yet", "Error", "Error");
					}
					else
					{
						foreach(var date in communityEventsArray.Where(cEvent => cEvent.Attendees.Any(attendee => attendee.Name == username)).Select(x => GetFirstDayOfMonthDate(x.EventDate)).Distinct().ToList())
						{
							var listItemGroup = new CommunityEventCollection(date);
							foreach(var item in communityEventsArray.Where(x => GetFirstDayOfMonthDate(x.EventDate).CompareTo(date) == 0))
							{
								listItemGroup.Add(item);
							}
							allListItemGroups.Add(listItemGroup);
						}
					}
					MyListViewEvents.GroupHeaderTemplate = new DataTemplate(typeof(HeaderCell));
					MyListViewEvents.GroupShortNameBinding = new Binding("Title");
					MyListViewEvents.ItemsSource = allListItemGroups;
				}
				catch (Exception ex)
				{
					UserDialogs.Instance.Alert("Please check internet connection.", "Loading Failed", "OK");
				}
				this.IsBusy = false;
			}
		}

		protected void Refresh_Clicked(object sender, EventArgs e)
		{
			UpdateList();
		}

		protected async void MyListViewEvents_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			// get the current CommunityEvent selected by the user and assign it to a temp variable
			var communityEvent = (CommunityEvent)e.Item;

			//				create the DetailsPage
			var detailsPage = new DetailsPage();

			//				bind the CommunityEvent source to the DetailsPage target
			detailsPage.BindingContext = communityEvent;

			((ListView)sender).SelectedItem = null;

			//				bring up the details page
			await Navigation.PushAsync(detailsPage);
		}


	}
}