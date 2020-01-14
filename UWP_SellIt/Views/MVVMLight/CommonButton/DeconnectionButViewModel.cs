using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UWP_SellIt.Views.MVVMLight.CommonButton
{
    public class DeconnectionButViewModel : ViewModelBase
    {
        private INavigationService navigationService;

        
        public ICommand Deconnectionbtn => new RelayCommand(() =>
        {
            this.navigationService.NavigateTo("MainPage");

        });

        public DeconnectionButViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
    }
}
