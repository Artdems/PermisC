using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;
using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services.Media;

namespace PermisC.ViewModels
{
    class PhotoAndroid
    {
        public async Task<string> TakePhoto_Clicked()
        {
            string rep = "";

            ITesseractApi api = Resolver.Resolve<ITesseractApi>();
            IDevice device = Resolver.Resolve<IDevice>();

            var mediaStorageOptions = new CameraMediaStorageOptions
            {
                DefaultCamera = CameraDevice.Rear,
                Directory = "Receipts",
                Name = $"immat.jpg"
            };

            // Take a photo of the business receipt.
            var file = await device.MediaPicker.TakePhotoAsync(mediaStorageOptions);

            

            if(!api.Initialized)
                await api.Init("fra");

            var photo = file;
            if (photo != null)
            {
                var imageBytes = new byte[photo.Source.Length];
                photo.Source.Position = 0;
                photo.Source.Read(imageBytes, 0, (int)photo.Source.Length);
                photo.Source.Position = 0;

                await api.SetImage(imageBytes);
                /*if (tessResult)
                {
                    rep = api.Text;
                }*/

                rep = api.Text;
            }

            return rep;

        }
    }
}
