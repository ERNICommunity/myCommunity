using System;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using Xamarin.Forms;
using GalaSoft.MvvmLight.Command;

namespace myCommunity
{
	public class FilterViewModel : ViewModelBase
	{
		public FilterViewModel()
		{
			ApplyCommand = new RelayCommand<object> (ApplyFilter);
			ClearCommand = new RelayCommand<object> (ClearFilter);
		}

		public bool ShowMyEventsOnly { get; set; }

		public bool IsEquals(FilterViewModel p_Filter)
		{
			if (p_Filter != null && ShowMyEventsOnly == p_Filter.ShowMyEventsOnly) 
			{
				return true;
			}
			return false;
		}

		public RelayCommand<object> ApplyCommand { get; private set; }
		public RelayCommand<object> ClearCommand { get; private set; }

		public void ApplyFilter(object o)
		{
			var model = new FilterViewModel {
				ShowMyEventsOnly = ShowMyEventsOnly
			};
			MessagingCenter.Send<FilterViewModel, FilterViewModel> (this, "Filter", model);
		}

		public void ClearFilter(object o)
		{
			MessagingCenter.Send<FilterViewModel, FilterViewModel> (this, "Filter", new FilterViewModel());
		}


	}
}

