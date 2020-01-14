using EntityUWP.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour en savoir plus sur le modèle d'élément Contrôle utilisateur, consultez la page https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWP_SellIt.Views.ProductPage
    {
    public sealed partial class ListAdvanceUC : UserControl
        {
        public ObservableCollection<Product> ProductList { get; set; }

        public ListAdvanceUC()
            {
            this.InitializeComponent();

            this.ProductList = new ObservableCollection<Product>();
            this.ProductList.Add(new Product() { Id = 1, Name = "Produit 1", Color = "Blue", Size = "S", Weight = 3, Quantity = 10, ToValid = true, ProductOrders = new List<Order>(), ProductStateProducts = new List<StateProduct>(), ProductType = null });
            this.ProductList.Add(new Product() { Id = 2, Name = "Produit 2", Color = "Rouge", Size = "M", Weight = 2.5F, Quantity = 15, ToValid = true, ProductOrders = new List<Order>(), ProductStateProducts = new List<StateProduct>(), ProductType = null });
            this.ProductList.Add(new Product() { Id = 3, Name = "Produit 3", Color = "Jaune", Size = "L", Weight = 1.5F, Quantity = 0, ToValid = true, ProductOrders = new List<Order>(), ProductStateProducts = new List<StateProduct>(), ProductType = null });

            this.DataContext = this;
            }
        }
    }
