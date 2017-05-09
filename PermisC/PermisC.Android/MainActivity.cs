using Android.App;
using Android.Content.PM;
using Android.OS;
using System;

namespace PermisC.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        Boolean isConnect;
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;


            Connection co = new Connection();

            if(co.State.ToString().Contains("Disconnected"))
            {
                isConnect = false;
            }
            else
            {
                isConnect = true;
            }
            base.OnCreate(bundle);

            //bool co = Connection.IsConnected(Android.App.Application.Context);
            //Console.WriteLine(co);
            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App(isConnect));
        }
    }
}