using GalaSoft.MvvmLight;
using Xamarin.Forms;
using System;
using myCommunity.Models;
using System.Collections.Generic;
using Acr.UserDialogs;
using myCommunity.Services;
using Connectivity.Plugin;
using System.Collections.ObjectModel;
using System.Linq;
using myCommunity.Views.XAML;
using GalaSoft.MvvmLight.Command;

namespace myCommunity.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class EventsViewModel : ViewModelBase
    {
		private bool m_ListViewIsVisible;
		private bool m_UserIsVisible;
		private string m_Username;
		private ObservableCollection<CommunityEventCollection> m_ItemsCollection;
		private RelayCommand m_ShowFilterPage;
		private RelayCommand m_RefreshList;
		private FilterViewModel m_Filter;
		private CommunityEvent m_SelectedItem;

		Page m_FilterPage;

		bool IsBusy;

		public EventsViewModel() 
		{ 
			m_SelectedItem = new CommunityEvent ();
			m_FilterPage = new FilterEventsPage ();
			MessagingCenter.Subscribe<DetailsViewModel>(this, "RefreshFromSignup", RefreshFromSignup);
			MessagingCenter.Subscribe<FilterViewModel, FilterViewModel> (this, "Filter", (childPage, filter) => 
				FilterList (filter));
		}

		public INavigation Navigation { get; set; }

		public bool ListViewEventsVisible { get { return m_ListViewIsVisible; } set { m_ListViewIsVisible = value; RaisePropertyChanged ("ListViewEventsVisible");} }
		public bool UserIsVisible { get { return m_UserIsVisible; } set { m_UserIsVisible = value; RaisePropertyChanged ("UserIsVisible");} }
		public string UsernameText { get { return string.Format ("{0}", m_Username); } set { m_Username = value; RaisePropertyChanged ("UsernameText");} }
		public DataTemplate GroupHeaderTemplate {get{ return new DataTemplate (typeof(HeaderCell));}}
		public Binding GroupShortNameBinding {get{ return new Binding("Title");}}
		public ObservableCollection<CommunityEventCollection> ItemsCollection { get { return m_ItemsCollection;} set{ m_ItemsCollection = value; RaisePropertyChanged ("ItemsCollection");}}
		public CommunityEvent SelectedItem 
		{ 
			get { 
				return m_SelectedItem;
			} 
			set 
			{ 
				m_SelectedItem = value; 
				RaisePropertyChanged ("SelectedItem");
				SelectEvent ();
			}
		}

		public void CheckForUser()
		{
			var username = string.Empty;

			if (Application.Current.Properties.ContainsKey(AppStrings.USERNAME))
				username = Application.Current.Properties[AppStrings.USERNAME] as string;

			if (!string.IsNullOrEmpty (username)) 
			{
				UserIsVisible = true;
				UsernameText = username;
			} 
			else 
			{
				UserIsVisible = false;
			}
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

						foreach(var date in filteredEvents.Select(x => GetFirstDayOfMonthDate(x.EventDate)).Distinct())
						{
							var listItemGroup = new CommunityEventCollection(date);
							foreach(var item in filteredEvents.Where(x => GetFirstDayOfMonthDate(x.EventDate).CompareTo(date) == 0))
							{
								listItemGroup.Add(item);
							}
							allListItemGroups.Add(listItemGroup);
						}
					}
					ItemsCollection = allListItemGroups;
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
			if (App.Locator.FilterModel == null) 
			{
				return  p_Events;
			}
			if (App.Locator.FilterModel.ShowMyEventsOnly) 
			{
				p_Events = p_Events.Where (p_This => p_This.Attendees.Any (attendee => attendee.Name == m_Username));
			}
			//other filters to be placed here
			return p_Events;
		}

		public RelayCommand ShowFilterPage
		{
			get
			{ 
				return m_ShowFilterPage ?? new RelayCommand (
					() => {App.MainNavigation.Navigation.PushModalAsync(m_FilterPage);}, () => true); 
			}
		}

		public RelayCommand RefreshList
		{
			get
			{ 
				return m_RefreshList ?? new RelayCommand (UpdateList); 
			}
		}

		public void FilterList(FilterViewModel p_Filter)
		{
			var currentFilter = m_Filter;
			m_Filter = p_Filter;
			if(m_Filter != null && m_Filter.IsEquals(currentFilter))
			{
				Navigation.PopModalAsync();
				return;
			}
			UpdateList();
			Navigation.PopModalAsync();
		}

		public void SelectEvent()
		{
			if (m_SelectedItem != null) {
				var detailsPage = new DetailsPage (m_SelectedItem);
				App.MainNavigation.Navigation.PushAsync (detailsPage);
			}
		}

		protected async void ListViewEvents_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			// get the current CommunityEvent selected by the user and assign it to a temp variable
			var communityEvent = (CommunityEvent)e.Item;

			//				create the DetailsPage
			var detailsPage = new DetailsPage(communityEvent);


			((ListView)sender).SelectedItem = null;

			//				bring up the details page
			await App.MainNavigation.Navigation.PushAsync(detailsPage);
		}

		public void RefreshFromSignup(object obj)
		{
			UpdateList();
			this.CheckForUser();
		}



		private DateTime GetFirstDayOfMonthDate(string p_EventDate)
		{
			return new DateTime(DateTime.Parse (p_EventDate).Year, DateTime.Parse (p_EventDate).Month, 1);
		}
    }
}