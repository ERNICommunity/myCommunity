using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace myCommunity.Views.XAML
{
    public partial class EventsViewCell : ViewCell
    {
        public EventsViewCell()
        {
            InitializeComponent();
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
        }
        
    }
}
