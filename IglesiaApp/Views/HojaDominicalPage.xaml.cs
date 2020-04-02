using System;
using Acr.UserDialogs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IglesiaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HojaDominicalPage : ContentPage
    {
        HojaDominicalPageViewModel VistaModelo;
        DateTime fechaMinima = Convert.ToDateTime("2001-01-01");
        DateTime fechaMaxima = DateTime.Now;
        private const int InicioLimite = 0;
        private const int LongitudLimite = 3;
        public HojaDominicalPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            VistaModelo = new HojaDominicalPageViewModel(this.Navigation);
            this.BindingContext = VistaModelo;
            InitializeComponent();
            CargarFechas();
        }

        private void CargarFechas()
        {

            DpInicio.MinimumDate = fechaMinima;
            DpInicio.MaximumDate = fechaMaxima;
            DpFin.MinimumDate = fechaMinima;
            DpFin.MaximumDate = fechaMaxima;
            DpInicio.Date = fechaMinima;
        }

        private async void BtnBuscar_Clicked(object sender, EventArgs e)
        {
            if (DpInicio.Date < DpFin.Date)
            {
                UserDialogs.Instance.ShowLoading("Cargando");
                var listaHojas = await VistaModelo.GetListadoHojas(DpInicio.Date, DpFin.Date, InicioLimite, LongitudLimite);
                ListHojaDominical.ItemsSource = listaHojas;
                UserDialogs.Instance.HideLoading();
            }
            else
            {
                await DisplayAlert("Alerta", "La Fecha de Inicio debe ser menor a la Fecha de Fin", "OK");
            }
        }
    }
}