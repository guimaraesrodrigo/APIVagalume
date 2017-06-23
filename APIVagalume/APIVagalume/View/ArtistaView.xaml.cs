using APIVagalume.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APIVagalume.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArtistaView : ContentPage
    {
        public ArtistaView()
        {            
            InitializeComponent();
            this.BindingContext = new ArtistaViewModel();
            
            
        }

        
    }
}