using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IglesiaApp
{
    public class HojaDominicalPageViewModel: INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        public HojaDominicalPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
        }
        public async Task<ObservableCollection<HojasDominicales>> GetListadoHojas(DateTime fechaInicio, DateTime fechaFin, int intInicioLimite, int intLongitudLimite)
        {
            return await ServiceRest.GetHojasDominicales(fechaInicio, fechaFin, intInicioLimite, intLongitudLimite);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string strPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(strPropertyName));
        }
    }
}
