using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace UWP_SellIt.Views
{
    public sealed partial class Person : UserControl
    {
        #region Proprietiés
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Adress { get; set; }
        public String Tel { get; set; }
        public String Email { get; set; }
        #endregion
        public Person()
        {
    
            this.InitializeComponent();
            this.Firstname = "";
            this.Lastname = "";
            //this.DateOfBirth = "";
            this.Adress = "";
            this.Tel = "";
            this.Email = "";
            this.DataContext = this;

        }
        private void Button_Click(object sender, RoutedEventArgs e) 
        { 
            Debug.WriteLine(Firstname); 
            Debug.WriteLine(Lastname);
            Debug.WriteLine(DateOfBirth);
            Debug.WriteLine(Adress);
            Debug.WriteLine(Tel);
            Debug.WriteLine(Email);
        }
    }
}
