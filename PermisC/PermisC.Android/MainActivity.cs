using Android.App;
using Android.Content.PM;
using Android.OS;
using System;
using Tesseract;
using Tesseract.Droid;
using TinyIoC;
using XLabs.Ioc;
using XLabs.Ioc.TinyIOC;
using XLabs.Platform.Device;

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

            var container = TinyIoCContainer.Current;

            container.Register<IDevice>(AndroidDevice.CurrentDevice);
            container.Register<ITesseractApi>((cont, parameters) =>
            {
                return new TesseractApi(ApplicationContext, AssetsDeployment.OncePerInitialization);
            });

            Resolver.SetResolver(new TinyResolver(container));

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

            LoadApplication(new App());
        }
    }
}