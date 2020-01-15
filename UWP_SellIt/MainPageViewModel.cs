using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UWP_SellIt.Services;

namespace UWP_SellIt
{
    public class MainPageViewModel : ViewModelBase
    {
        private INavigationService navigationService;
        private DatabaseService databaseService;

        public ICommand suivantbtn => new RelayCommand(() =>
        {
            this.navigationService.NavigateTo("HomePage");

        });

        public MainPageViewModel(INavigationService navigationService, DatabaseService databaseService)
        {
            this.navigationService = navigationService;
            this.databaseService = databaseService;
            //SetupDatas();

        }
    }
}
