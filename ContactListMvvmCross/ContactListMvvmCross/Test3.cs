using System.IO;
using System.Text;
using Android.App;
using Android.Runtime;

namespace ContactListXamarin
{
    public class Test3 : ITest
    {
        private readonly Activity _activity;

        public Test3(Activity activity)
        {
            _activity = activity;
        }

        public void Run()
        {
            string result = "";
            var builder = new StringBuilder();
            for (int i = 0; i < 100000; i++) {
                builder.Append(i);
            }
            result = builder.ToString();
            result = result.Substring(1000);
            result = result.Replace("10", "");
            bool containsSubstring = result.Contains("123");
            string[] parts = result.Split('2');
            int length = parts.Length;
        }
        
        //private byte[] LoadData(string filename)
        //{
        //    var stream = _activity.Assets.Open (filename) as InputStreamInvoker;
        //    var size = stream.BaseInputStream.Available();
        //    var bytes = new byte[size];
        //    stream.Read (bytes, 0, bytes.Length);
        //    stream.Close ();
        //    return bytes;
        //}
    }
}