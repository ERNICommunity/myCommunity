using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;

namespace myCommunity
{
	public partial class DetailsXaml : ContentPage
	{
		public DetailsXaml ()
		{
			
				this.SetBinding (ContentPage.TitleProperty, "Title"); // display the "Title" field as the title of the page
                
				// set the page to allow back navigation
				NavigationPage.SetHasNavigationBar (this, true);

				InitializeComponent ();


		}
	}
}

