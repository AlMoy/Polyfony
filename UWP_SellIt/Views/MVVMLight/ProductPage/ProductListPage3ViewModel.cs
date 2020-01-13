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
    public class ProductListPage3ViewModel : ViewModelBase
    {
        private INavigationService navigationService;

        public ICommand Deconnectionbtn3 => new RelayCommand(() =>
        {
            this.navigationService.NavigateTo("MainPage");

        });

        public ProductListPage3ViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

        }
    }
}
