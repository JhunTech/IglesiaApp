using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IglesiaApp
{
    public class LoginPageViewModel: INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        public Command Registrarse { get; set; }
        public LoginPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.Registrarse = new Command(async () => await RegistrarDatos());
        }
        public async Task RegistrarDatos()
        {
            await Navigation.PushAsync(new RegistrarDatosPage());
        }
        public async Task<bool> LoginUsuario(string strEmail, string strPassword)
        {
            return await ServiceRest.GetLogin(strEmail, strPassword);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string strPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(strPropertyName));
        }
    }
}
