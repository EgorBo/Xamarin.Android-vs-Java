using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Android.App;
using Android.Runtime;
using Android.Widget;
using Android.OS;
using Java.IO;

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

			var texts = new String[0];

            using (var streamReader = new StreamReader(Assets.Open("data.dat")))
            {
                texts = streamReader.ReadToEnd().Split('\n');
            }

			var numbers = new String[texts.Length];
			for (int i = 0; i < texts.Length; i++)
			{
                numbers[i] = "+375(55)1112222 " + i.ToString(CultureInfo.InvariantCulture);
            }

            var data = new List<IDictionary<String, Object>>(texts.Length);
            JavaDictionary<String, Object> m;
            for (int i = 0; i < texts.Length; i++)
            {
                m = new JavaDictionary<String, Object>();
                m[ATTRIBUTE_NAME_NAME] = texts[i];
                m[ATTRIBUTE_NAME_PHONE] = numbers[i];
                m[ATTRIBUTE_NAME_IMAGE] = i % 2 == 0 ? Resource.Drawable.xamarin : Resource.Drawable.ic_launcher;
                data.Add(m);
            }

            String[] from = { ATTRIBUTE_NAME_NAME, ATTRIBUTE_NAME_PHONE, ATTRIBUTE_NAME_IMAGE };
            int[] to = { Resource.Id.tvName, Resource.Id.tvNumber, Resource.Id.tvImage };

            SimpleAdapter adapter = new SimpleAdapter(this, data, Resource.Layout.item_row, from, to);
            ListView list = (ListView)FindViewById(Resource.Id.list);
            list.Adapter = adapter ;
		}
	}
}


