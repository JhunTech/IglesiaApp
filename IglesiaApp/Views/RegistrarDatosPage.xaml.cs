using Acr.UserDialogs;
using System.Security.Cryptography;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IglesiaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrarDatosPage : ContentPage
    {
        RegistrarDatosPageViewModel VistaModelo;
        public RegistrarDatosPage()  
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            VistaModelo = new RegistrarDatosPageViewModel(this.Navigation);
            this.BindingContext = VistaModelo;
        }

        private void BtnCancelar_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private async void BtnGuardar_Clicked(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtPassword1.Text) && !string.IsNullOrEmpty(txtPassword2.Text))
            {
                UserDialogs.Instance.ShowLoading("Procesando");
                if (txtPassword1.Text.Equals(txtPassword2.Text))
                {
                    using (MD5 md5Hash = MD5.Create())
                    {
                        string strHash = Codificar.GetMd5Hash(md5Hash, txtPassword1.Text);
                        bool blnGuardarUsuario = await VistaModelo.SaveUsuario(ConstantesService.strAccionInsertarLogin, txtEmail.Text, txtNombre.Text, strHash);
                        if (blnGuardarUsuario)
                        {
                            UserDialogs.Instance.HideLoading();
                            await DisplayAlert(null, ConstantesMensajes.MensajePersonaAlmacenada, ConstantesMensajes.Aceptar);
                            App.Current.MainPage = new TabbedTransaccionalPage();
                        }
                        else
                        {
                            UserDialogs.Instance.HideLoading();
                            await DisplayAlert(ConstantesMensajes.Error, ConstantesMensajes.ErrorAlmacenarPersona, ConstantesMensajes.Aceptar);
                            await Navigation.PopAsync();
                        }
                    }                    
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    await DisplayAlert(ConstantesMensajes.Error, ConstantesMensajes.ErrorPasswordsDiferentes, ConstantesMensajes.Aceptar);
                }
                
            }
            else
            {
                await DisplayAlert(ConstantesMensajes.Error, ConstantesMensajes.ErrorCamposObligatorios, ConstantesMensajes.Aceptar);
            }
            
        }
    }
}