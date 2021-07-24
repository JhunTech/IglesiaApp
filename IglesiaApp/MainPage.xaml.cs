using IglesiaApp.Resources.Constants;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace IglesiaApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            CargarData();
        }

        private async void CargarData()
        {
            var current = Connectivity.NetworkAccess;
            lblTitulo.Text = ConstantsFrontApp.IntroTitulo;
            lblUbicacion.Text = ConstantsFrontApp.IntroUbicacion;

            if (current == NetworkAccess.Internet)
            {
                await Task.Delay(3000);
                await Navigation.PushAsync(new LoginPage());
            }
            else
            {
                await DisplayAlert("Atención", "No tienes ninguna conexión a internet activa.", "Aceptar");
            }
        }
    }
}
