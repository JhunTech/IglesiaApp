using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IglesiaApp
{
    public class RegistrarDatosPageViewModel: INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        public RegistrarDatosPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
        }

        public async Task<bool> SaveUsuario(string strAccion, string strEmail, string strNombre, string strPassword)
        {
            return await ServiceRest.SavePersona(strAccion, strEmail, strNombre, strPassword);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string strPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(strPropertyName));
        }
    }
}
