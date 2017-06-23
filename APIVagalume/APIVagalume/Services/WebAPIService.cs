using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Xamarin.Forms;
using System.Net;
using System.Text;
using APIVagalume.Model;
using System.Net.Http;
using System.Net.Http.Headers;

[assembly: Dependency(typeof(APIVagalume.Services.WebAPIService))]
namespace APIVagalume.Services
{
    public class WebAPIService : IWebAPIService
    {
        private const string BaseUrl = "https://www.vagalume.com.br/";

        public async Task<artist> GetLista(string artista)
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                artista = artista.Replace(" ","-");
                var uri = new Uri($"{BaseUrl}{artista}/index.js");
                var response = await httpClient.GetAsync(uri).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    //using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    // {
                    string content = await response.Content.ReadAsStringAsync();
                    //content = content.Replace(@"\","").Replace("/","");
                    var root = JsonConvert.DeserializeObject<RootObject>(content);
                    return root.artist;                    
                }
            }
            catch (Exception e)
            {
                App.Current.MainPage.DisplayAlert("API Vagalume", e.Message, "ok");
            }


            return null;
        }



    }
}

