using System;

using Xamarin.Forms;

namespace myCommunity
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			var MainNav = new NavigationPage (new EventsListPage ());
			MainPage = MainNav;
		}




		protected override void OnStart ()
		{
			// Handle when your app starts
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

