using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_SellIt.Views.MVVMLight
{
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            //Register your services used here
            SimpleIoc.Default.Register<INavigationService, NavigationService>();
            //SimpleIoc.Default.Register<Page1ViewModel>();
            //SimpleIoc.Default.Register<Page2ViewModel>();
        }


        //public Page1ViewModel BlankPageInstance
        //{
        //    get { return ServiceLocator.Current.GetInstance<BlankPageViewModel>(); }
        //}
        //public Page2ViewModel MyProperty
        //{
        //    get { return ServiceLocator.Current.GetInstance<OtherPageViewModel>(); }
        //}
    }
}
