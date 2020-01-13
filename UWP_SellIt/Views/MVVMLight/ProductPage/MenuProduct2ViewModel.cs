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
    public class MenuProduct2ViewModel : ViewModelBase
    {

        private INavigationService navigationService;

               

        public ICommand Returnbtn2 => new RelayCommand(() =>
        {
            this.navigationService.GoBack();

        });

        public ICommand Suivantbtn2 => new RelayCommand(() =>
        {
            this.navigationService.NavigateTo("ProductEnfantList");

        });

        public MenuProduct2ViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
    }
}
