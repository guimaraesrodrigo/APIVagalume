using APIVagalume.Model;
using APIVagalume.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using APIVagalume.View;

namespace APIVagalume
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new ArtistaView());
        }
    }
}
