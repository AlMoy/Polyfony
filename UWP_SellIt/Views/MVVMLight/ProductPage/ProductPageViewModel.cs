using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UWP_SellIt.Views.MVVMLight.ProductPage
{
    public class ProductPageViewModel : ViewModelBase
    {
        private INavigationService navigationService;

        public ICommand Deconnectionbtn => new RelayCommand(() =>
        {
            this.navigationService.NavigateTo("MainPage");

        });
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

        public ProductPageViewModel()
        {
            Messenger.Default.Register<SwitchViewMessage>(this, (switchViewMessage) =>
            {
                SwitchView(switchViewMessage.ViewName);
            });
        }

        private void SwitchView(string viewName)
        {
            throw new NotImplementedException();
        }

        public ProductPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

        }
    }
}
