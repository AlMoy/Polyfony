using System;
using System.Collections.Generic;
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

namespace UWP_SellIt.Views.MVVMLight.ProductPage
{
    public sealed partial class ProductFemmePageUC : UserControl
    {
        public ProductFemmePageUC()
        {
            this.InitializeComponent();
            this.InitializeComponent();
            String path1 = Directory.GetCurrentDirectory() + @"\Assets\images\trothomelec";
            fvtrothomelec.ItemsSource = Directory.GetFiles(path1).Select(p => "ms-appx:///" + p);

            String path2 = Directory.GetCurrentDirectory() + @"\Assets\images\trothomsim";
            fvtrothomsim.ItemsSource = Directory.GetFiles(path2).Select(p => "ms-appx:///" + p);
        }
    }
}
