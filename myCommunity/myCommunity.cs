using myCommunity.Views.XAML;
using System;
using Xamarin.Forms;
using myCommunity.ViewModel;

namespace myCommunity
{
	public class App : Application
	{
        public static NavigationPage MainNavigation { get; set; }
		public App ()
		{
			// The root page of your application
			MainNavigation = new NavigationPage(new EventsListPage());

            MainPage = MainNavigation;
		}
			
		private static ViewModelLocator _locator;

		public static ViewModelLocator Locator
		{
			get
			{
				if (_locator == null)
				{
					_locator = new ViewModelLocator();
				}

				return _locator;
			}
		}


		protected override void OnStart ()
		{
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

