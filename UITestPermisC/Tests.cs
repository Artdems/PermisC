using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;
using PermisC.ViewModels;

namespace PermisC.Test
{
    [TestFixture]
    public class Tests
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

                .ApkFile("../../../PermisC.Android/bin/com.companyname.PermisC.apk")
                // TODO: Update this path to point to your Android app and uncomment the
                // code if the app is not included in the solution.
                //.ApkFile ("../../../Android/bin/Debug/UITestsAndroid.apk")
                .StartApp();
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void TestSave()
        {
            NewRemorqueViewModel test = new NewRemorqueViewModel();
            test.Item.Immatriculation = "Coucou";
            test.Item.Poid = "Re-coucou";
            test.Save();
        }
    }
}

