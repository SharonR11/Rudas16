//using System;
//using System.Net;
//using Android.Content;
//using System.Threading;
//using System.Threading.Tasks;
//using Xamarin.Forms;
//using Xamarin.Forms.Platform.Android;

//[assembly: ExportImageSourceHandler(typeof(UriImageSource), typeof(Rudas16.Droid.CustomUriImageSourceHandler))]

//namespace Rudas16.Droid
//{
//    public class CustomUriImageSourceHandler : IImageSourceHandler
//    {
//        public async Task<bool> LoadImageAsync(ImageSource imagesource, Context context, CancellationToken cancelationToken)
//        {
//            try
//            {
//                if (imagesource is UriImageSource uriImageSource && uriImageSource.Uri != null)
//                {
//                    using (var webClient = new WebClient())
//                    {
//                        // Descargar la imagen desde la URL
//                        var imageBytes = await webClient.DownloadDataTaskAsync(uriImageSource.Uri);

//                        if (imageBytes != null && imageBytes.Length > 0)
//                        {
//                            // La carga fue exitosa, realiza la lógica necesaria con la imagen

//                            // Por ejemplo, podrías cargar la imagen en un ImageView:
//                            // var bitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
//                            // imageView.SetImageBitmap(bitmap);

//                            return true; // Indica que la carga fue exitosa
//                        }
//                    }
//                }

//                // Si algo falla o la imagen no se pudo cargar, retorna false
//                return false;
//            }
//            catch (Exception ex)
//            {
//                // Manejo de errores si ocurre alguna excepción
//                // Registra el error o realiza alguna acción correspondiente

//                return false; // Indica que la carga falló
//            }
//        }
//    }
//}
