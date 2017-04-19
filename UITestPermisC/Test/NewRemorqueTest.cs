using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PermisC.Models;
using PermisC.ViewModels;
using Xamarin.UITest.Android;
using Xamarin.UITest;

namespace PermisC.Test
{
    [TestFixture]
    public class Test
    {
        AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            // TODO: If the Android app being tested is included in the solution then open
            // the Unit Tests window, right click Test Apps, select Add App Project
            // and select the app projects that should be tested.
            app = ConfigureApp
                .Android

                .ApkFile("../../../PermisC.Android/bin/Debug/com.companyname.PermisC-Signed.apk")
                // TODO: Update this path to point to your Android app and uncomment the
                // code if the app is not included in the solution.
                //.ApkFile ("../../../Android/bin/Debug/UITestsAndroid.apk")
                .StartApp();
        }

        
    }
}
