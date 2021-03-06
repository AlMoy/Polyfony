﻿using EntityUWP.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_SellIt.Views.ViewModels.Accessors.Commons;

namespace UWP_SellIt.Views.ViewModels.Accessors.Roles
{
    public class RoleListAccessor
    {
        public ObservableCollection<Role> Roles { get; set; }
        public ListViewAccessor<Role> ListView { get; set; }

        public RoleListAccessor()
        {
            this.Roles = new ObservableCollection<Role>();
            this.ListView = new ListViewAccessor<Role>();
        }
    }
}
