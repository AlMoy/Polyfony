using EntityUWP.Entity;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_SellIt.Services;
using UWP_SellIt.Views.ViewModels.Accessors;

namespace UWP_SellIt.Views.Orders
{
    public class NewOrderViewModel : ViewModelBase
    {
        private INavigationService navigationService;
        private DatabaseService databaseService;
        public ClientPageAccessor Datas { get; set; }

        public NewOrderViewModel(INavigationService navigationService, DatabaseService databaseService)
        {
            this.navigationService = navigationService;
            this.databaseService = databaseService;
            SetupDatas();
        }

        private void SetupDatas()
        {

            Datas = new ClientPageAccessor();
            SetupClientList();
        }

        private void SetupClientList()
        {
            Datas.ClientList.Clients = new ObservableCollection<Person>();
            foreach (var item in databaseService.People)
            {
                Datas.ClientList.Clients.Add(item);
            }
            // Datas.ClientList.ListView.SelectedItem = new Person();
            //Datas.ClientList.ListView.SelectionChanged = new RelayCommand(ClientListSelectionChanged);
        }
    }
}
