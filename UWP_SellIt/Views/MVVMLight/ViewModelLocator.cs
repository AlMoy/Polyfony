using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_SellIt.Views.MVVMLight.HomePage;
using UWP_SellIt.Views.MVVMLight.ProductPage;

namespace UWP_SellIt.Views.MVVMLight
{
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            //Register your services used here

            SimpleIoc.Default.Register<INavigationService>(() =>
            {
                var navigationService = new NavigationService();
                navigationService.Configure("MainPage", typeof(MainPage));
                navigationService.Configure("ProductListPage", typeof(ProductListPage));               
                return navigationService;
            });
            SimpleIoc.Default.Register<HomePageViewModel>();
            SimpleIoc.Default.Register<ProductPageViewModel>();
            //SimpleIoc.Default.Register<Page2ViewModel>();
        }


        public HomePageViewModel HomePageInstance
        {
            get { return ServiceLocator.Current.GetInstance<HomePageViewModel>(); }
        }

        public ProductPageViewModel ProductPageInstance
        {
            get { return ServiceLocator.Current.GetInstance<ProductPageViewModel>(); }
        }

        //public Page2ViewModel MyProperty
        //{
        //    get { return ServiceLocator.Current.GetInstance<OtherPageViewModel>(); }
        //}
    }
}
