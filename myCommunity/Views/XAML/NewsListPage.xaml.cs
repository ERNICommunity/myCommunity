using Acr.UserDialogs;
using myCommunity.Models;
using myCommunity.Services;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace myCommunity.Views.XAML
{
    public partial class NewsListPage : ContentPage
    {
        public NewsListPage()
        {
            InitializeComponent();
			BindingContext = App.Locator.NewsModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            App.MainNavigation.BarTextColor = Color.FromHex("333333");
            App.MainNavigation.BarBackgroundColor = Color.FromHex("F0F0F0");
			App.Locator.NewsModel.UpdateList ();
        }
    }
}
