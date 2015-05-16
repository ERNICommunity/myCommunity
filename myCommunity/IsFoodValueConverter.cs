using System;

using Xamarin.Forms;

namespace myCommunity
{
	public class IsFoodValueConverter : IValueConverter
	{
		#region IValueConverter implementation

		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return ((bool)value) ? "Yeah Pizza !!!" : "No pizza :-("; // Why don't you work?
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException ();
		}

		#endregion


	}
}


