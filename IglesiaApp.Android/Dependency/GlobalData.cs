using System;
using System.IO;
using Xamarin.Forms;
using IglesiaApp.Droid;

[assembly: Dependency(typeof(GlobalData))]
namespace IglesiaApp.Droid
{
    public class GlobalData: IGlobalData
    {
        public string ObtenerPathLocal(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}