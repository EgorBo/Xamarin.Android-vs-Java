using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Cirrious.CrossCore;
using Cirrious.MvvmCross;
using Cirrious.MvvmCross.Droid.Views;


namespace ContactListMvvmCross
{
    [Activity (Label = "ContactListMvvmCross", MainLauncher = true)]
    public class MainActivity : MvxActivity
    {
        public new MainViewModel ViewModel
        {
            get
            {
                return (MainViewModel)base.ViewModel;
            }

            set
            {
                base.ViewModel = value;
            }
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.Main);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        }
        

    }
}


