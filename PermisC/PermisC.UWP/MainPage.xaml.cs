using System;

namespace PermisC.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {

            Boolean isConnect = connection.IsInternet();
            this.InitializeComponent();
            LoadApplication(new PermisC.App(isConnect));
        }
    }
}