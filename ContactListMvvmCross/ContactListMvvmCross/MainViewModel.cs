using System;
using Cirrious.MvvmCross.ViewModels;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using Android.Runtime;
using ContactListXamarin;
using Cirrious.CrossCore.Droid.Platform;

namespace ContactListMvvmCross
{
    public class MainViewModel : MvxViewModel
    {
        public const String ATTRIBUTE_NAME_NAME = "name";
        public const String ATTRIBUTE_NAME_PHONE = "phone";
        public const String ATTRIBUTE_NAME_IMAGE = "image";

        string _result;

        public IList Data { get; set; }

        public string Result
    {
        get
        {
                return _result;
        }

        set
        {
            _result = value;
            RaisePropertyChanged(() => Result);
        }
    }

        public override void Start()
        {
            base.Start();
            
            var texts = new String[1000];
            var numbers = new String[texts.Length];
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i] = "Ivan Ivanov" + i;
                numbers[i] = "+375(55)1112222 " + i.ToString(CultureInfo.InvariantCulture);
            }

            var data = new List<IDictionary<String, Object>>(texts.Length);
            for (int i = 0; i < texts.Length; i++)
            {
                var m = new JavaDictionary<String, Object>();
                m[ATTRIBUTE_NAME_NAME] = texts[i];
                m[ATTRIBUTE_NAME_PHONE] = numbers[i];
                m[ATTRIBUTE_NAME_IMAGE] = i % 2 == 0 ? Resource.Drawable.xamarin : Resource.Drawable.ic_launcher;
                data.Add(m);
            }

            Data = data;
            RaisePropertyChanged(() => Data);

//            String[] from = { ATTRIBUTE_NAME_NAME, ATTRIBUTE_NAME_PHONE, ATTRIBUTE_NAME_IMAGE };
//            int[] to = { Resource.Id.tvName, Resource.Id.tvNumber, Resource.Id.tvImage };
        }

        public void Test1(object sender, EventArgs eventArgs)
        {
            var result = new TestExecuter().Run(new Test1());
            PrintResults(result);
        }

        public void Test2(object sender, EventArgs eventArgs)
        {
            var result = new TestExecuter().Run(new Test2());
            PrintResults(result);
        }

        public void Test3(object sender, EventArgs eventArgs)
        {
            var activity = Cirrious.CrossCore.Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
            
            var result = new TestExecuter().Run(new Test3(activity));
            PrintResults(result);
        }

        private void PrintResults(String result)
        {
           Result = result;
        }
    }
}

