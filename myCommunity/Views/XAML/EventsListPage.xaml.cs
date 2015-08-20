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
		private FilterViewModel m_Filter;

		public EventsListPage()
		{
			InitializeComponent();
			var eventsViewModel = App.Locator.EventsModel;
			BindingContext = eventsViewModel;
			eventsViewModel.Navigation = this.Navigation;

			/*
            MessagingCenter.Subscribe<DetailsPage>(this, "RefreshFromSignup", this.RefreshFromSignup);
			MessagingCenter.Subscribe<FilterEventsPage, FilterViewModel> (this, "Filter", (childPage, filter) => {
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
*/
        }
			
		protected override void OnDisappearing()
		{
			var viewmodel = App.Locator.EventsModel;
			viewmodel.ListViewEventsVisible = false;
			base.OnDisappearing ();
		}
			
		protected override void OnAppearing()
		{
			base.OnAppearing ();
			var viewmodel = App.Locator.EventsModel;
			viewmodel.CheckForUser();
			viewmodel.ListViewEventsVisible = true;

			App.MainNavigation.BarTextColor = Color.FromHex("333333");
			App.MainNavigation.BarBackgroundColor = Color.FromHex("F0F0F0");


			// if the list is empty 

			if (viewmodel.ItemsCollection == null)
				viewmodel.UpdateList();
		}


	}
}