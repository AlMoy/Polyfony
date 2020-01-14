using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UWP_SellIt.Views.MVVMLight.ClientPage
{
    public class ClientListPageViewModel: ViewModelBase
    {
        private INavigationService navigationService;

        public ICommand Deconnectionbtn => new RelayCommand(() =>
        {
            this.navigationService.NavigateTo("MainPage");

        });

        public ICommand Returnbtn => new RelayCommand(() =>
        {
            this.navigationService.GoBack();

        });

        public ICommand Ajoutbtn => new RelayCommand(() =>
        {
            this.navigationService.NavigateTo("NewClient");

        });

        public ClientListPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

        }
    }
}
