﻿using EntityUWP.Entity;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_SellIt.Services;
using UWP_SellIt.Views.ViewModels.Accessors;
using Windows.UI.Xaml.Controls;

namespace UWP_SellIt.Views.Roles
{
    public class RoleViewModel : ViewModelBase
    {
        private INavigationService navigationService;
        private DatabaseService databaseService;

        public RolePageAccessor Datas { get; set; }
        

        public RoleViewModel(INavigationService navigationService, DatabaseService databaseService)
        {
            this.navigationService = navigationService;
            this.databaseService = databaseService;
            SetupDatas();

        }

        private void SetupDatas()
        {
            Datas = new RolePageAccessor();
            SetupRoleEdit();
            SetupRoleList();
            SetupRoleShow();
        }

        private void SetupRoleShow()
        {
            Datas.RoleShow.Role = new Role();
        }

        private void SetupRoleList()
        {
            Datas.RoleList.Roles = new ObservableCollection<Role>();
            foreach (var item in databaseService.Roles)
            {
                Datas.RoleList.Roles.Add(item);
            }
            Datas.RoleList.ListView.SelectedItem = new Role();
            Datas.RoleList.ListView.SelectionChanged = new RelayCommand(RoleListSelectionChanged);


        }

        private void RoleListSelectionChanged()
        {
            Role role = Datas.RoleList.ListView.SelectedItem;
            if (role != null)
            {
                Datas.RoleShow.Role.CopyFrom(role);
            }
        }


        private void SetupRoleEdit()
        {
            Datas.RoleEdit.Button.Content = "Valider";
            Datas.RoleEdit.Button.Action = new RelayCommand(RoleEditCommand);
            Datas.RoleEdit.Role = new Role();
        }

        private void RoleEditCommand()
        {
            Role role = new Role();
            role.CopyFrom(Datas.RoleEdit.Role);

            try
            {
                databaseService.SqliteConnection.Insert(role);
                Datas.RoleList.Roles.Add(role);
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
