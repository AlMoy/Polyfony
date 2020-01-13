using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;

namespace UWP_SellIt.Views.MVVMLight.HomePage
{
    public class HomePageViewModel : ViewModelBase
    {
        private INavigationService navigationService;

        public ICommand Deconnectionbtn => new RelayCommand(() =>
        {
            this.navigationService.NavigateTo("MainPage");

        });
        public ICommand ButtonProduct => new RelayCommand(() =>
        {
            this.navigationService.NavigateTo("ProductListPage");
            
        });

        public ICommand ButtonClient => new RelayCommand(() =>
        {
            this.navigationService.NavigateTo("ClientList");

        });

        public ICommand ButtonOrder => new RelayCommand(() =>
        {
            this.navigationService.NavigateTo("MainPage");

        });
        public HomePageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

        }
    }
}
