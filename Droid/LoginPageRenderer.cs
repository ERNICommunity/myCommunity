using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Android.Webkit;

namespace myCommunity.Droid
{
    class LoginPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Page> e)
        {
            base.OnElementChanged(e);

            WebView yammerLogin = new WebView();
            WebSettings webSettings = yammerLogin.Settings;
            webSettings.JavaScriptEnabled = true;
            var htmlSource = new HtmlWebViewSource ();
            htmlSource.Html = @"
                <!DOCTYPE html><html lang=""en"">
                  <head>
                    <meta charset=""utf-8"">
                    <title>myCommunity's Yammer Login</title>
                    <script type=""text/javascript"" data-app-id=""tzGrdv1lUGeML22k9maP7w"" src=""https://c64.assets-yammer.com/assets/platform_js_sdk.js""></script>
                    <script type=""text/javascript"">
                        var token;

                        function login() {
                            yam.platform.getLoginStatus(function (statusResponse) {
                                if (statusResponse) {
                                    yam.platform.login(function (loginResponse) {
                                        if (loginResponse.authResponse) {
                                            token = loginResponse.access_token.token;
                                            fetchUserData(); // for some fucked up reason, we don't get the user json in THIS flow`s response.
                                        }
                                        else {
                                            console.warn('YammerLogin: Login failed.');
                                        }
                                    });
                                }
                            });
                        }
                    </script>
                  </head>
                  <body>
                    <!-- page content -->
                  </body>
                </html>";
browser.Source = htmlSource;
        }
    }
}