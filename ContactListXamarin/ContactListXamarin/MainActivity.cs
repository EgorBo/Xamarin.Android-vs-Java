using System;
using System.Collections.Generic;
using System.Globalization;
using Android.App;
using Android.Runtime;
using Android.Widget;
using Android.OS;

namespace ContactListXamarin
{
	[Activity(MainLauncher = true, Theme = "@android:style/Theme.Holo.Light.DarkActionBar")]
	public class MainActivity : Activity
	{
        public const String ATTRIBUTE_NAME_NAME = "name";
        public const String ATTRIBUTE_NAME_PHONE = "phone";
        public const String ATTRIBUTE_NAME_IMAGE = "image";

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

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

            String[] from = { ATTRIBUTE_NAME_NAME, ATTRIBUTE_NAME_PHONE, ATTRIBUTE_NAME_IMAGE };
            int[] to = { Resource.Id.tvName, Resource.Id.tvNumber, Resource.Id.tvImage };

            var adapter = new SimpleAdapter(this, data, Resource.Layout.item_row, from, to);
            var list = (ListView)FindViewById(Resource.Id.list);
            list.Adapter = adapter;

            //subscribing from axml directly doesn't work ;(
            FindViewById<Button>(Resource.Id.test1).Click += Test1;
            FindViewById<Button>(Resource.Id.test2).Click += Test2;
            FindViewById<Button>(Resource.Id.test4).Click += Test3;
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
            var result = new TestExecuter().Run(new Test3(this));
            PrintResults(result);
        }

        private void PrintResults(String result)
        {
            var resultTv = (TextView)FindViewById(Resource.Id.result);
            resultTv.Text = result;
        }
	}
}


