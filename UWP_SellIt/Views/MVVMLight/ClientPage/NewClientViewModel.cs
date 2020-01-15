
﻿using GalaSoft.MvvmLight;

﻿using EntityUWP.Entity;
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
using UWP_SellIt.Views.ViewModels.Accessors;
using Windows.UI.Xaml.Controls;


namespace UWP_SellIt.Views.MVVMLight.ClientPage
{
    public class NewClientViewModel : ViewModelBase
    {
        private INavigationService navigationService;
        private DatabaseService databaseService;
        public ClientPageAccessor Datas { get; set; }


        public ICommand Deconnectionbtn => new RelayCommand(() =>
            {
                this.navigationService.NavigateTo("MainPage");

            });

        public ICommand Returnbtn => new RelayCommand(() =>
        {
            this.navigationService.GoBack();

        });




        

        public ICommand showlistbtn => new RelayCommand(() =>
        {
            this.navigationService.NavigateTo("ClientList");

        });


        public NewClientViewModel(INavigationService navigationService, DatabaseService databaseService)
        {
            this.navigationService = navigationService;
            this.databaseService = databaseService;
            SetupDatas();
        }


        private void SetupDatas()
        {
            Datas = new ClientPageAccessor();
            SetUpClientEdit();

        }

        private void SetUpClientEdit()
        {
            Datas.ClientEdit.Button.Content = "Valider";
            Datas.ClientEdit.Button.Action = new RelayCommand(ClientEditCommand);
            Datas.ClientEdit.Client = new Person();
        }

        private void ClientEditCommand()
        {
            Person client = new Person();
            client.CopyFrom(Datas.ClientEdit.Client);
            
            try
            {
                databaseService.SqliteConnection.Insert(client);
                Datas.ClientList.Clients.Add(client);
            }
            catch (Exception e)
            {
                ContentDialog contentDialog = new ContentDialog();
                contentDialog.Title = "Error";
                contentDialog.Content = e.Message;
                contentDialog.IsSecondaryButtonEnabled = false;
                contentDialog.PrimaryButtonText = "ok";
                contentDialog.ShowAsync();
            }
        }

    }
    
}
