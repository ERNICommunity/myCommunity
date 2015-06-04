using System;

using Xamarin.Forms;

namespace myCommunity
{
	public class App : Application
	{
        public static NavigationPage MainNavigation { get; set; }
		public App ()
		{
			// The root page of your application
            MainNavigation = new NavigationPage(new Views.XAML.MainTabPage());

            MainPage = MainNavigation;
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

