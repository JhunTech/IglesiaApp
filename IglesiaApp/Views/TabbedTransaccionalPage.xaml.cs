using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace IglesiaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedTransaccionalPage : Xamarin.Forms.TabbedPage
    {
        public TabbedTransaccionalPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(false);
            CargarTabbed();
        }
        private void CargarTabbed()
        {
            UnselectedTabColor = Color.FromHex("#ABABAB");
            SelectedTabColor = Color.FromHex("#A30C94");

            NavigationPage page1 = new NavigationPage(new IglesiaPage())
            {
                Title = "Inicio",
                IconImageSource = "icono_inicio.png"
            };

            NavigationPage page2 = new NavigationPage(new GaleriaPage())
            {
                Title = "Galería",
                IconImageSource = "icono_galeria.png"
            };

            NavigationPage page3 = new NavigationPage(new HojaDominicalPage())
            {
                Title = "Hoja Dom",
                IconImageSource = "icono_hoja.png"
            };

            NavigationPage page4 = new NavigationPage(new ProductosPage())
            {
                Title = "SR Green",
                IconImageSource = "icono_producto.png"
            };
            NavigationPage page5 = new NavigationPage(new NoticiasPage())
            {
                Title = "Contáctanos",
                IconImageSource = "icono_contactanos.png"
            };


            Children.Add(page1);
            Children.Add(page2);
            Children.Add(page3);
            Children.Add(page4);
            Children.Add(page5);
        }
    }
}