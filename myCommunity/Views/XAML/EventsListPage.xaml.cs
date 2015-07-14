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
	public partial class EventsListPage : ContentPage
	{
		private string Username = string.Empty;
		private FilterModel m_Filter;

		public EventsListPage()
		{
			InitializeComponent();
            MessagingCenter.Subscribe<DetailsPage>(this, "RefreshFromSignup", this.RefreshFromSignup);
			MessagingCenter.Subscribe<FilterEventsPage, FilterModel> (this, "Filter", (childPage, filter) => {
				var currentFilter = m_Filter;
				m_Filter = filter;
				if(m_Filter != null && m_Filter.IsEquals(currentFilter))
				{
					Navigation.PopModalAsync();
					return;
				}
				UpdateList();
				Navigation.PopModalAsync();
			});

        }

        private void RefreshFromSignup(DetailsPage obj)
        {

            UpdateList();
            this.CheckForUser();
        }

        protected override void OnDisappearing()
        {
            this.ListViewEvents.IsVisible = false;
            base.OnDisappearing();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.CheckForUser();
            this.ListViewEvents.IsVisible = true;

            App.MainNavigation.BarTextColor = Color.FromHex("333333");
            App.MainNavigation.BarBackgroundColor = Color.FromHex("F0F0F0");

            // if the list is empty 

            if (ListViewEvents.ItemsSource == null)
                UpdateList();

		}		
			
		private DateTime GetFirstDayOfMonthDate(string p_EventDate)
		{
			return new DateTime(DateTime.Parse (p_EventDate).Year, DateTime.Parse (p_EventDate).Month, 1);
		}
		private void CheckForUser()
        {
			this.Username = string.Empty;

			if (Application.Current.Properties.ContainsKey(AppStrings.USERNAME))
				Username = Application.Current.Properties[AppStrings.USERNAME] as string;

			if (!string.IsNullOrEmpty(Username))
            {
                stkUser.IsVisible = true;
				lblUser.Text = string.Format("{0}", Username);
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
						UserDialogs.Instance.Alert("No Elements found", "Error", "Error");
					}
					else
					{
						var filteredEvents = this.ApplyFilter(communityEventsArray);

						foreach(var date in filteredEvents.Select(x => GetFirstDayOfMonthDate(x.EventDate)).Distinct().ToList())
						{
							var listItemGroup = new CommunityEventCollection(date);
							foreach(var item in filteredEvents.Where(x => GetFirstDayOfMonthDate(x.EventDate).CompareTo(date) == 0))
							{
								listItemGroup.Add(item);
							}
							allListItemGroups.Add(listItemGroup);
						}
					}
					ListViewEvents.GroupHeaderTemplate = new DataTemplate(typeof(HeaderCell));
					ListViewEvents.GroupShortNameBinding = new Binding("Title");
					ListViewEvents.ItemsSource = allListItemGroups;
				}
				catch (Exception ex)
				{
					UserDialogs.Instance.Alert("Please check internet connection.", "Loading Failed", "OK");
				}
				this.IsBusy = false;
			}
		}

		private IEnumerable<CommunityEvent> ApplyFilter(IEnumerable<CommunityEvent> p_Events)
		{
			if (m_Filter == null) 
			{
				return  p_Events;
			}
			if (m_Filter.ShowMyEventsOnly) 
			{
				p_Events = p_Events.Where (p_This => p_This.Attendees.Any (attendee => attendee.Name == Username));
			}
			//other filters to be placed here
			return p_Events;
		}

		protected async void Filter_Clicked(object sender, EventArgs e)
		{
			var filterPage = new FilterEventsPage (m_Filter);
			Navigation.PushModalAsync(filterPage);
		}

		protected void Refresh_Clicked(object sender, EventArgs e)
		{
			UpdateList();
		}

		protected async void ListViewEvents_ItemTapped(object sender, ItemTappedEventArgs e)
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