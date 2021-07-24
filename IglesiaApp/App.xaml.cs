using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
[assembly: ExportFont("NeueHaasDisplayBlack.ttf", Alias = "FontBlack")]
[assembly: ExportFont("NeueHaasDisplayBold.ttf", Alias = "FontBold")]
[assembly: ExportFont("NeueHaasDisplayLight.ttf", Alias = "FontLight")]
[assembly: ExportFont("NeueHaasDisplayMedium.ttf", Alias = "FontMedium")]
[assembly: ExportFont("NeueHaasDisplayRoman.ttf", Alias = "FontRoman")]

namespace IglesiaApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            //MainPage = new TabbedTransaccionalPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        static UsuarioDatabase database;

        public static UsuarioDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new UsuarioDatabase(DependencyService.Get<IGlobalData>().ObtenerPathLocal(ConstantesService.strBDDName));
                }
                return database;
            }
        }
    }
}
