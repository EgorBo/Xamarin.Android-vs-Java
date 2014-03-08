using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;

namespace ContactListMvvmCross
{
	public class App : MvxApplication
	{
        public App(){
            Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<MainViewModel>());
        }

	}
}

