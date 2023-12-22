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
                ImageUrl = txtImageUrl.Text
            };
            var canciones = (List<Song>)cancionesListView.ItemsSource;

            // Agregar la nueva canción a la lista
            canciones.Add(nuevaCancion);

            // Actualizar la vista del ListView con la nueva lista de canciones
            cancionesListView.ItemsSource = null; // Limpiar el ListView
            cancionesListView.ItemsSource = canciones;

        }
        private void Eliminar_Clicked(object sender, EventArgs e)
        {
            var botonEliminar = (Button)sender;
            var cancionAEliminar = (Song)botonEliminar.CommandParameter;

            // Obtener la lista actual de canciones del ListView
            var canciones = (List<Song>)cancionesListView.ItemsSource;

            // Eliminar la canción seleccionada de la lista
            canciones.Remove(cancionAEliminar);

            // Actualizar la vista del ListView con la nueva lista de canciones
            cancionesListView.ItemsSource = null; // Limpiar el ListView
            cancionesListView.ItemsSource = canciones; // Asignar la nueva lista de canciones
        }



    }
}
