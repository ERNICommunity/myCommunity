using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace myCommunity.Views.XAML
{
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage()
        {
            InitializeComponent();
            //this.SetBinding(ContentPage.TitleProperty, "Title"); // display the "Title" field as the title of the page
        }

        protected override void OnAppearing()
        {
            NavigationPage.SetTitleIcon(this, "ic_type.png");
            App.MainNavigation.BarTextColor = Color.FromHex("333333");
            App.MainNavigation.BarBackgroundColor = Color.FromHex("F0F0F0");
            base.OnAppearing();
        }
    }
}
