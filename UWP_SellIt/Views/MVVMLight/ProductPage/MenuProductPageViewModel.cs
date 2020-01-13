using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UWP_SellIt.Views.MVVMLight.ProductPage
{
    public class MenuProductPageViewModel : ViewModelBase
    {
        private INavigationService navigationService;

        public ICommand Hommebtn => new RelayCommand(() =>
        {
            this.navigationService.NavigateTo("ProductHommeList");

        });

        public ICommand Femmebtn => new RelayCommand(() =>
        {
            this.navigationService.NavigateTo("MainPage");

        });

        public ICommand Enfantbtn => new RelayCommand(() =>
        {
            this.navigationService.NavigateTo("MainPage");

        });

        public ICommand Returnbtn => new RelayCommand(() =>
        {
            this.navigationService.GoBack();

        });

        public ICommand Suivantbtn => new RelayCommand(() =>
        {
            this.navigationService.NavigateTo("ProductFemmeList");

        });

        public MenuProductPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

        }
    }
}
