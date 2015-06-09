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

namespace myCommunity.Views.XAML
{
    public partial class EventsListPage : ContentPage
    {
        public EventsListPage()
        {
            InitializeComponent();


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            App.MainNavigation.BarTextColor = Color.FromHex("333333");
            App.MainNavigation.BarBackgroundColor = Color.FromHex("F0F0F0");
            if (ListViewEvents.ItemsSource == null)
            {
                UpdateList();
            }
        }

        public async void UpdateList()
        {
            // grab the list as an array of CommunityEvents from the webservice
            var webservice = new RestClient();

            // start the activity indicator
            using (UserDialogs.Instance.Loading("Updating Events..."))
            {
                this.IsBusy = true;
                try
                {
                    // try to fetch from the webservice
                    var communityEventsArray = await webservice.GetEventsAsync();



                    // stop activity indicator


                    // and assign it to the list source
                    ListViewEvents.ItemsSource = communityEventsArray;
                }
                catch (Exception ex)
                {
                    UserDialogs.Instance.Alert("Webservice call failed!","Error","OK");
                }
                this.IsBusy = false;
            }
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
