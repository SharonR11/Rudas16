using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Rudas16.Model;

namespace Rudas16
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private const string BaseUrl = "https://api-multi-sharonr11s-projects.vercel.app/musica";

        public async Task<T> GetAsync<T>(string endpoint)
        {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                // Realizar la solicitud GET al servidor
                HttpResponseMessage response = await client.GetAsync(endpoint);

                // Verificar si la solicitud fue exitosa (código de estado 200)
                if (response.IsSuccessStatusCode)
                {
                    // Leer y deserializar la respuesta JSON
                    string json = await response.Content.ReadAsStringAsync();
                    T result = JsonConvert.DeserializeObject<T>(json);
                    return result;
                }
                else
                {
                    // Manejar errores
                    throw new Exception($"Error en la solicitud: {response.StatusCode}");
                }
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var result = await GetAsync<MusicApiResponse>("https://api-multi-sharonr11s-projects.vercel.app/musica");
                cancionesListView.ItemsSource = result.songs;
                // Procesar el resultado
            }
            catch (Exception ex)
            {
                throw ex;
                // Manejar errores
            }
        }

        private void Crear_Clicked(object sender, EventArgs e)
        {
            Song nuevaCancion = new Song
            {
                Title = txtTitle.Text,
                Artist = txtArtist.Text,
                Duration = txtDuration.Text,
                ReleaseDate = DatePicker.Date,
            };
            var canciones = (List<Song>)cancionesListView.ItemsSource;

            canciones.Add(nuevaCancion);

            cancionesListView.ItemsSource = null;
            cancionesListView.ItemsSource = canciones;

        }


    }
}
