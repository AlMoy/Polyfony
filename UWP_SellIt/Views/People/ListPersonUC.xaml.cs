using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using EntityUWP.Entity;
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

namespace UWP_SellIt.Views.People
{
    public sealed partial class ListPersonUC : UserControl
    {
        public ObservableCollection<Person> PersonList { get; set; }

        public ListPersonUC()
        {
            this.InitializeComponent();
            this.PersonList = new ObservableCollection<Person>();
            this.DataContext = PersonList;
        }

        private void MenuFlyoutDelete_Click(object sender, RoutedEventArgs e)
        {
            this.PersonList.Remove(sender as Person);
        }
    }
}
