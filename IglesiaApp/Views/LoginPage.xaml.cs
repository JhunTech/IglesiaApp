using Acr.UserDialogs;
using System.Security.Cryptography;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IglesiaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginPageViewModel VistaModelo;
        public LoginPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            VistaModelo = new LoginPageViewModel(this.Navigation);
            this.BindingContext = VistaModelo;
        }

        private async void BtnLogin_Clicked(object sender, System.EventArgs e)
        {
            bool blnRespuesta = false;
            if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                UserDialogs.Instance.ShowLoading("Procesando");
                string strHash = string.Empty;
                using (MD5 md5Hash = MD5.Create())
                {
                    strHash = Codificar.GetMd5Hash(md5Hash, txtPassword.Text);
                }
                blnRespuesta = await VistaModelo.LoginUsuario(txtUsuario.Text, strHash);
                if (blnRespuesta)
                {
                    UserDialogs.Instance.HideLoading();
                    await App.Current.MainPage.DisplayAlert(null, ConstantesMensajes.Bienvenido + "\n" + App.Current.Resources["nombreUsuario"].ToString(), ConstantesMensajes.Aceptar);
                    App.Current.MainPage = new TabbedTransaccionalPage();
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    await DisplayAlert(ConstantesMensajes.Error, ConstantesMensajes.ErrorUsuarioNoEncontrado, ConstantesMensajes.Aceptar);
                }
            }
            else
            {
                await DisplayAlert(ConstantesMensajes.Atencion, ConstantesMensajes.ErrorCamposObligatorios, ConstantesMensajes.Aceptar);
            }
            
        }
    }
}