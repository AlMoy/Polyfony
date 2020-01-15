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
using UWP_SellIt.Views.ViewModels.Accessors.Orders;

namespace UWP_SellIt.Views.Orders
{
    public class ListOrderPageViewModel : ViewModelBase
    {
        private INavigationService navigationService;
        private DatabaseService databaseService;
        public OrderListAccessor Datas { get; set; }



        public ICommand Ajoutbtn => new RelayCommand(() =>
        {
            this.navigationService.NavigateTo("NewOrder");

        });

        public ListOrderPageViewModel(INavigationService navigationService, DatabaseService databaseService)
        {
            this.navigationService = navigationService;
            this.databaseService = databaseService;
           // SetupDatas();

        }
    }
}
