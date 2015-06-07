﻿using myCommunity.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace myCommunity.Views.XAML
{
    public partial class NewsListPage : ContentPage
    {
        public NewsListPage()
        {
            InitializeComponent(); 

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            App.MainNavigation.BarTextColor = Color.FromHex("333333");
            App.MainNavigation.BarBackgroundColor = Color.FromHex("F0F0F0");
            if (ListViewNews.ItemsSource == null)
            {
                UpdateList();
            }
        }

        public async void UpdateList()
        {
            // grab the list as an array of CommunityEvents from the webservice
            var webservice = new RestClient();

            // start the activity indicator
            this.IsBusy = true;

            // try to fetch from the webservice
            var communityEventsArray = await webservice.GetNewsAsync();

            // stop activity indicator
            this.IsBusy = false;

            Debug.WriteLine(communityEventsArray.ToString());

            // and assign it to the list source
            ListViewNews.ItemsSource = communityEventsArray;
        }

        protected async void ListViewNews_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // get the current CommunityEvent selected by the user and assign it to a temp variable
            var communityEvent = (News)e.Item;

            //				create the DetailsPage
            var detailsPage = new NewsDetailsPage();

            //				bind the CommunityEvent source to the DetailsPage target
            detailsPage.BindingContext = communityEvent;

            ((ListView)sender).SelectedItem = null;

            //				bring up the details page
            await Navigation.PushAsync(detailsPage);
        }
    }
}
