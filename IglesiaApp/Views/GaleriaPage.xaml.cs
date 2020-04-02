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
    public partial class GaleriaPage : ContentPage
    {
        public GaleriaPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }
    }
}