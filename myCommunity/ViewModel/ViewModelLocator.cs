/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:myCommunity"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace myCommunity.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
			SimpleIoc.Default.Register<FilterViewModel>();
			SimpleIoc.Default.Register<EventsViewModel>();
			SimpleIoc.Default.Register<DetailsViewModel>();
			SimpleIoc.Default.Register<NewsViewModel>();
		}
        
		public FilterViewModel FilterModel
		{
			get { return ServiceLocator.Current.GetInstance<FilterViewModel>(); } 
		}

		public EventsViewModel EventsModel
		{
			get { return ServiceLocator.Current.GetInstance<EventsViewModel>(); } 
		}

		public DetailsViewModel DetailModel
		{
			get { return ServiceLocator.Current.GetInstance<DetailsViewModel>(); } 
		}

		public NewsViewModel NewsModel
		{
			get { return ServiceLocator.Current.GetInstance<NewsViewModel>(); } 
		}

        public static void Cleanup()
		{
			SimpleIoc.Default.Unregister<FilterViewModel> ();
			SimpleIoc.Default.Unregister<EventsViewModel> ();
			SimpleIoc.Default.Unregister<DetailsViewModel> ();
			SimpleIoc.Default.Unregister<NewsViewModel> ();
        }
    }
}