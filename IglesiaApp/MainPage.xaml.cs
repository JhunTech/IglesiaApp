using System;
using System.ComponentModel;
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
        }

        private async void BtnIniciar_Clicked(object sender, EventArgs e)
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                await Navigation.PushAsync(new LoginPage());
            }
            else
            {
                await DisplayAlert("Atención", "No tienes ninguna conexión a internet activa.", "Aceptar");
            }
            
        }
    }
}
