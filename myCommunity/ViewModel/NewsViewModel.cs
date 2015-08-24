using System;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using myCommunity.Services;
using Acr.UserDialogs;
using System.Diagnostics;
using GalaSoft.MvvmLight.Command;
using myCommunity.Models;
using myCommunity.Views.XAML;

namespace myCommunity
{
	public class NewsViewModel : ViewModelBase
	{
		private ObservableCollection<News> m_ItemsCollection;
		private News m_SelectedItem;
		private bool IsBusy;
		private RelayCommand m_RefreshCommand;

		public NewsViewModel ()
		{
		}

		public ObservableCollection<News> ItemsCollection { get { return m_ItemsCollection;} set{ m_ItemsCollection = value; RaisePropertyChanged ("ItemsCollection");}}
		public News SelectedItem { get { return m_SelectedItem; } set { m_SelectedItem = value; ListViewNews_ItemTapped (value);}}

		public async void UpdateList()
		{
			// grab the list as an array of CommunityEvents from the webservice
			var webservice = new RestClient();

			using (UserDialogs.Instance.Loading("Updating News..."))
			{
				// start the activity indicator
				this.IsBusy = true;
				try
				{

					// try to fetch from the webservice
					var communityEventsArray = await webservice.GetNewsAsync();

					this.ItemsCollection = new ObservableCollection<News>(communityEventsArray);
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
					UserDialogs.Instance.Alert("Please check internet connection.", "Loading Failed", "OK");
				}
				// stop activity indicator
				this.IsBusy = false;
			}
		}

		public RelayCommand RefreshCommand
		{
			get
			{ 
				return m_RefreshCommand ?? new RelayCommand (UpdateList); 
			}
		}

		protected async void ListViewNews_ItemTapped(News p_Event)
		{
			//				create the DetailsPage
			var detailsPage = new NewsDetailsPage(p_Event);

			//				bring up the details page
			await App.MainNavigation.Navigation.PushAsync(detailsPage);
		}


	}
}

