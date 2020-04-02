using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IglesiaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IglesiaPage : ContentPage
    {
        IglesiaPageViewModel VistaModelo;
        public IglesiaPage()
        {           
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            VistaModelo = new IglesiaPageViewModel(this.Navigation);
            this.BindingContext = VistaModelo;
            CargarIglesia();
        }
        private async void CargarIglesia()
        {
            VistaModelo.ListaCarousel = await VistaModelo.GetGaleria(ConstantesService.AccionGaleria, 1, -1, -1);
            carouselIglesia.ItemsSource = VistaModelo.ListaCarousel;
        }
    }
}