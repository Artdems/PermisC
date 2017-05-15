
using Foundation;
using System;
using UIKit;

namespace PermisC.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
            Boolean test = true;
            global::Xamarin.Forms.Forms.Init();
			LoadApplication(new App(test));

            

            return base.FinishedLaunching(app, options);
		}
	}
}
