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
using UWP_SellIt.Views.MVVMLight.CommonButton;
using UWP_SellIt.Views.MVVMLight.HomePage1;
using UWP_SellIt.Views.MVVMLight.ProductPage;
using UWP_SellIt.Views.Orders;
using UWP_SellIt.Views.Roles;

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
                navigationService.Configure("NewOrder", typeof(NewOrderPage));
                navigationService.Configure("ListOrder", typeof(ListOrderPage));
                navigationService.Configure("HomePage", typeof(HomePage));


                return navigationService;
            });
            SimpleIoc.Default.Register<HomePageViewModel>();
            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<MenuProductPageViewModel>();
            SimpleIoc.Default.Register<MenuProduct2ViewModel>();
            SimpleIoc.Default.Register<MenuProductUC3ViewModel>();
            SimpleIoc.Default.Register<ClientListPageViewModel>();            
            SimpleIoc.Default.Register<NewClientViewModel>();
            SimpleIoc.Default.Register<DeconnectionButViewModel>();
            SimpleIoc.Default.Register<ReturnButUCViewModel>();
            SimpleIoc.Default.Register<RoleViewModel>();
            SimpleIoc.Default.Register<NewOrderViewModel>();
            SimpleIoc.Default.Register<ListOrderPageViewModel>();


            SimpleIoc.Default.Register<DatabaseService>(() =>
            {
                return new DatabaseService();
            }, true);
        }


        public HomePageViewModel HomePageInstance
        {
            get { return ServiceLocator.Current.GetInstance<HomePageViewModel>(); }
        }

        public MainPageViewModel MainPageInstance
        {
            get { return ServiceLocator.Current.GetInstance<MainPageViewModel>(); }
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

        public NewOrderViewModel NewOrderPageInstance
        {
            get { return ServiceLocator.Current.GetInstance<NewOrderViewModel>(); }
        }

        public ListOrderPageViewModel ListOrderPageInstance
        {
            get { return ServiceLocator.Current.GetInstance<ListOrderPageViewModel>(); }
        }


        public RoleViewModel RolePageInstance
        {
            get { return ServiceLocator.Current.GetInstance<RoleViewModel>(); }
        }


        public MenuProduct2ViewModel MenuProduct2Instance
        {
            get { return ServiceLocator.Current.GetInstance<MenuProduct2ViewModel>(); }
        }

        public MenuProductUC3ViewModel MenuProductUC3Instance
        {
            get { return ServiceLocator.Current.GetInstance<MenuProductUC3ViewModel>(); }
        }


        public DeconnectionButViewModel DeconnectionButInstance
        {
            get { return ServiceLocator.Current.GetInstance<DeconnectionButViewModel>(); }
        }

        public ReturnButUCViewModel ReturnButUCInstance
        {
            get { return ServiceLocator.Current.GetInstance<ReturnButUCViewModel>(); }
        }


    }
}
