using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using APIVagalume.ViewModel;
using APIVagalume.Services;
using APIVagalume.Model;
using System.Collections.ObjectModel;

namespace APIVagalume.ViewModel
{
    public class ArtistaViewModel : BaseViewModel
    {
        public Command BuscaCommand { get; set; }
        private SearchBar _SearchBar { get; }

        private ObservableCollection<Item3> _ListaAlbuns;
        public ObservableCollection<Item3> ListaAlbuns
        {
            get { return _ListaAlbuns; }
            set
            {
                _ListaAlbuns = value;
            }
        }

        private string _Ano;
        
        private string _TextoBusca;
        public string TextoBusca
        {
            get { return _TextoBusca; }
            set
            {
                _TextoBusca = value;
                notify();
                BuscaCommand.Execute(_TextoBusca);

            }
        }

        private string _ImagemArtista;
        public string ImagemArtista
        {
            get { return _ImagemArtista; }
            set
            {
                _ImagemArtista = value;
                notify();
            }
        }

        private bool _ListaAlbumCountMaiorQueZero;

        public bool ListaAlbumCountMaiorQueZero
        {
            get { return _ListaAlbumCountMaiorQueZero; }
            set
            {
                _ListaAlbumCountMaiorQueZero = value;
                notify();
            }
        }



        public ArtistaViewModel()
        {
            BuscaCommand = new Command(ExecutarBuscaCommand, PodeExecutarBuscaCommand);
            ListaAlbuns = new ObservableCollection<Item3>();
        }

        async void BuscarArtista()
        {
            try
            {
                _ListaAlbuns.Clear();
                var WebAPI = DependencyService.Get<IWebAPIService>();
                artist Artista = await WebAPI.GetLista(_TextoBusca);
                if (Artista != null)
                {
                    ImagemArtista = "https://s2.vagalume.com/" + Artista.pic_medium;                    
                    foreach (Item3 Album in Artista.albums.item)
                    {
                        _ListaAlbuns.Add(Album);
                    }
                }
                ListaAlbumCountMaiorQueZero = _ListaAlbuns.Count > 0;
            }
            catch (Exception)
            {

                //throw;
            }

        }
        async void ExecutarBuscaCommand()
        {
            BuscarArtista();
        }

        bool PodeExecutarBuscaCommand()
        {
            //return !string.IsNullOrEmpty(_TextoBusca);
            return true;
        }

    }
}
