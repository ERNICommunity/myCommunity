﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace myCommunity
{
    public class BaseContentPage : TabbedPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!App.IsLoggedIn)
            {
                Navigation.PushModalAsync(new LoginPage());
            }
        }
    }
}
