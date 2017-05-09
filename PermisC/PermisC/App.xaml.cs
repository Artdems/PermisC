using PermisC.Views;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PermisC
{
    
    public partial class App : Application
    {
        public App(Boolean isConnect)
        {
            InitializeComponent();
            SetMainPage(isConnect);
        }

        public static void SetMainPage(Boolean isConnect)
        {
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new ItemsPage(isConnect))
                    {
                        Title = "Véhicule répértorier",
                        Icon = Device.OnPlatform("tab_feed.png",null,null)
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "Véhicule non répértorier",
                        Icon = Device.OnPlatform("tab_about.png",null,null)
                    },
                }
            };
        }
    }
}
