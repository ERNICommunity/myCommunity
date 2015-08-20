using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;
using myCommunity.Views.XAML;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace myCommunity
{
	public partial class FilterEventsPage : ContentPage
	{
		public FilterEventsPage ()
		{
			InitializeComponent ();
			BindingContext = App.Locator.FilterModel;
		}
			
		public FilterViewModel ViewModel
		{ 
			get 
			{ 
				return (FilterViewModel)BindingContext;
			} 	
			set 
			{ 
				BindingContext = value;
			} 
		}
	}
}

