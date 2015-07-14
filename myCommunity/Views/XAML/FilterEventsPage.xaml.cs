using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;
using myCommunity.Views.XAML;

namespace myCommunity
{
	public partial class FilterEventsPage : ContentPage
	{

		public FilterEventsPage (FilterModel p_Model)
		{
			InitializeComponent ();
			if (p_Model != null) {
				this.showMyEventsOnlySwitch.IsToggled = p_Model.ShowMyEventsOnly;
			}
		}
			

		protected void ApplyFilter(object sender, EventArgs e)
		{
			var model = new FilterModel {
				ShowMyEventsOnly = this.showMyEventsOnlySwitch.IsToggled,	
			};
			MessagingCenter.Send<FilterEventsPage, FilterModel> (this, "Filter", model);
		}

		protected void ClearFilter(object sender, EventArgs e)
		{
			MessagingCenter.Send<FilterEventsPage, FilterModel> (this, "Filter", null);
		}
	}
}

