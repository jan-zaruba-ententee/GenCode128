using System;
using System.IO;
using GenCode128;
using SixLabors.ImageSharp.Formats.Png;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2 || args.Length > 3)
            {
                Console.WriteLine("Usage: dotnet sample.dll filename.png data [weight]");
                return;
            }
            var filename = args[0];
            var data = args[1];
            var weight = args.Length == 3 ? Int32.Parse(args[2]) : 2;

            try
            {
                var myImage = Code128Rendering.MakeBarcodeImage(data, weight, true);
                using (var outputStream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    myImage.Save(outputStream, new PngEncoder());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }
    }
}
