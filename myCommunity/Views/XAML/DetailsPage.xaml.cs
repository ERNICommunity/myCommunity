using Acr.UserDialogs;
using myCommunity.Models;
using myCommunity.Services;
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
            NavigationPage.SetTitleIcon(this, "ic_event_date.png");
            App.MainNavigation.BarTextColor = Color.FromHex("333333");
            App.MainNavigation.BarBackgroundColor = Color.FromHex("F0F0F0");
            base.OnAppearing();
        }

        protected void SignUp_Clicked(object sender, EventArgs e)
        {
            var communityEvent = this.BindingContext as CommunityEvent;
            string username = string.Empty;

            if(Application.Current.Properties.ContainsKey("username"))
                username = Application.Current.Properties["username"] as string;

            if (string.IsNullOrEmpty(username) && communityEvent != null)
            {


                var promptConfig = new PromptConfig{
                    CancelText = "Cancel",
                    IsCancellable = true,
                    OkText = "OK",
                    Message = "this will be saved to the application preferences which will be used on your next sign up",
                    Title = "Signup Name",
                    InputType = InputType.Default,
                    Placeholder = "Your Name",
                    OnResult = this.OnSignUp
                };
                UserDialogs.Instance.Prompt(promptConfig);

            }
            else{
                this.SignUp(username);
            }
        }

        private void OnSignUp(PromptResult result)
        {

            if (result.Ok)
            {
                Application.Current.Properties.Add("username", result.Text);
                this.SignUp(result.Text);
            }
        }

        private async void SignUp(string username)
        {
            var communityEvent = this.BindingContext as CommunityEvent;

            if (communityEvent != null)
            {
                var webservice = new RestClient();
                var retval = await webservice.EventSignUpAsync(communityEvent.ID, username);
                if(retval.Code == "Created")
                {
                    UserDialogs.Instance.Alert("Succesfully signed up in the event", "Signed Up", "OK");
                }
            }
        }
    }
}
