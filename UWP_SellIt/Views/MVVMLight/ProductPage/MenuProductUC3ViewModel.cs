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
    public class MenuProductUC3ViewModel : ViewModelBase
    {
        private INavigationService navigationService;

        
        public ICommand Returnbtn2 => new RelayCommand(() =>
        {
            this.navigationService.GoBack();

        });

        public MenuProductUC3ViewModel (INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
    }
}
