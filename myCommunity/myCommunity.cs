using myCommunity.Views.XAML;
using System;
using Xamarin.Forms;

namespace myCommunity
{
	public class App : Application
	{
        public static NavigationPage MainNavigation { get; set; }

        public static Page GetMainPage()
        {
            // The root page of your application
            MainNavigation = new NavigationPage(new MainTabPage());

            return MainNavigation;
        }

        public static bool IsLoggedIn
        {
            get
            {
                return !string.IsNullOrWhiteSpace(_Token);
            }
        }

        static string _Token;
        public static string Token
        {
            get
            {
                return _Token;
            }
        }

        public static void SaveToken(string token)
        {
            _Token = token;
        }

        public static Action SuccessfulLoginAction
        {
            get
            {
                return new Action(() =>
                {
                    MainNavigation.Navigation.PopModalAsync();
                });
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
	}
}

