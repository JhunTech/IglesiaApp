using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IglesiaApp
{
    public class IglesiaPageViewModel: INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        public IglesiaPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
        }
        public async Task<ObservableCollection<GaleriaRest>> GetGaleria(string strAccion, int intSeccion, int intInicioLimite, int intLongitudLimite)
        {
            return await ServiceRest.GetGaleria(strAccion, intSeccion, intInicioLimite, intLongitudLimite);
        }

        private ObservableCollection<GaleriaRest> listaCarousel;
        public ObservableCollection<GaleriaRest> ListaCarousel
        {
            get { return listaCarousel; }
            set
            {
                listaCarousel = value;
                OnPropertyChanged("ListaCarousel");
            }
        }

        private ObservableCollection<GaleriaRest> listaGaleria;
        public ObservableCollection<GaleriaRest> ListaGaleria
        {
            get { return listaGaleria; }
            set
            {
                listaGaleria = value;
                OnPropertyChanged("ListaGaleria");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string strPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(strPropertyName));
        }
    }
}
