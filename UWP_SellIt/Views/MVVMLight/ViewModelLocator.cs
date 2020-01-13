using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_SellIt.Services;
using UWP_SellIt.Views.MVVMLight.ClientPage;
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
                navigationService.Configure("ClientList", typeof(ClientListPage));
                navigationService.Configure("ProductFemmeList", typeof(ProductListPage2));
                navigationService.Configure("ProductEnfantList", typeof(ProductListPage3));
                navigationService.Configure("NewClient", typeof(NewClient));
                //navigationService.Configure("ProductHommeList", typeof(ProductHommePageUC));

                return navigationService;
            });
            SimpleIoc.Default.Register<HomePageViewModel>();
            SimpleIoc.Default.Register<ProductPageViewModel>();
            SimpleIoc.Default.Register<MenuProductPageViewModel>();
            SimpleIoc.Default.Register<MenuProduct2ViewModel>();
            SimpleIoc.Default.Register<MenuProductUC3ViewModel>();
            SimpleIoc.Default.Register<ClientListPageViewModel>();
            SimpleIoc.Default.Register<ProductListPage2ViewModel>();
            SimpleIoc.Default.Register<ProductListPage3ViewModel>();
            SimpleIoc.Default.Register<NewClientViewModel>();
            //SimpleIoc.Default.Register<Page2ViewModel>();

            SimpleIoc.Default.Register<DatabaseService>(() =>
            {
                return new DatabaseService();
            }, true);
        }


        public HomePageViewModel HomePageInstance
        {
            get { return ServiceLocator.Current.GetInstance<HomePageViewModel>(); }
        }

        public ProductPageViewModel ProductPageInstance
        {
            get { return ServiceLocator.Current.GetInstance<ProductPageViewModel>(); }
        }

        public MenuProductPageViewModel MenuProductPageInstance
        {
            get { return ServiceLocator.Current.GetInstance<MenuProductPageViewModel>(); }
        }

        public ClientListPageViewModel ClientListPageInstance
        {
            get { return ServiceLocator.Current.GetInstance<ClientListPageViewModel>(); }
        }
        public NewClientViewModel NewClientPageInstance
        {
            get { return ServiceLocator.Current.GetInstance<NewClientViewModel>(); }
        }

        public ProductListPage2ViewModel ProductListPage2Instance
        {
            get { return ServiceLocator.Current.GetInstance<ProductListPage2ViewModel>(); }
        }

        public ProductListPage3ViewModel ProductListPage3Instance
        {
            get { return ServiceLocator.Current.GetInstance<ProductListPage3ViewModel>(); }
        }

        public MenuProduct2ViewModel MenuProduct2Instance
        {
            get { return ServiceLocator.Current.GetInstance<MenuProduct2ViewModel>(); }
        }

        public MenuProductUC3ViewModel MenuProductUC3Instance
        {
            get { return ServiceLocator.Current.GetInstance<MenuProductUC3ViewModel>(); }
        }

        //public Page2ViewModel MyProperty
        //{
        //    get { return ServiceLocator.Current.GetInstance<OtherPageViewModel>(); }
        //}
    }
}
