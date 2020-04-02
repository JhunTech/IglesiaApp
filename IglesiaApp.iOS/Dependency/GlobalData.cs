using System;
using System.IO;
using Xamarin.Forms;
using IglesiaApp.iOS;

[assembly: Dependency(typeof(GlobalData))]
namespace IglesiaApp.iOS
{
    public class GlobalData: IGlobalData
    {
        public string ObtenerPathLocal(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}