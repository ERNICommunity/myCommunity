using Xamarin.Forms;
using myCommunity.Models;

namespace myCommunity.Views.XAML
{
    public partial class NewsDetailsPage : ContentPage
    {
		public NewsDetailsPage(News p_BindingContext)
        {
            InitializeComponent();
			BindingContext = p_BindingContext;
        }
    }
}
