using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization.Configuration;

namespace TrabajoSGE1
{
    public partial class WindowRegSocios : Window
    {
        private Usuario _usuario;
        private List<Socio> lista;

        public WindowRegSocios(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;

            InitializeSocios();

            lbl_usuLog.Content = _usuario.Name;
            lbl_rango.Content = _usuario.Rango;
        }
        
        private async Task InitializeSocios()
        {
            lista = await ObtenerSocios();
            lst_socios.ItemsSource = lista;
        }

        private async Task<List<Socio>>  ObtenerSocios()
        {
           var lista = new List<Socio>();
           using (var client = new HttpClient())
           {
               try
               {
                   var response = await client.GetAsync("http://localhost:3000/api/v1/socios");
                   var responseBody = await response.Content.ReadAsStringAsync();

                   if (response.IsSuccessStatusCode)
                   {
                       using (var jsonDoc = JsonDocument.Parse(responseBody))
                       {
                           var root = jsonDoc.RootElement;
                           if (root.TryGetProperty("socios", out var socios))
                           {
                               var options = new JsonSerializerOptions
                               {
                                   PropertyNameCaseInsensitive = true
                               };
                               var listUsers = JsonSerializer.Deserialize<List<Socio>>(socios.GetRawText(), options);
                               if (listUsers != null)
                               {
                                   foreach (var socio in listUsers)
                                   {
                                       socio.FechAlt = socio.FechAlt.Date;
                                       socio.FechCad = socio.FechCad.Date; 
                                   }

                                   lista.AddRange(listUsers);
                               }
                               else
                               {
                                   MessageBox.Show("Error al obtener el socios");
                               }
                           }
                           else
                           {
                               MessageBox.Show("Error al obtener el socios");
                           }
                       }
                   }
                   else
                   {
                       MessageBox.Show("Error al obtener el socios");
                   }
               }
               catch (Exception ex)
               {
                   MessageBox.Show("Error de conexión: " + ex.Message);
               }
           }
           return lista;
        }

        private void btn_volver_Click(object sender, RoutedEventArgs e)
        {
            var w1 = new Window1(_usuario);
            w1.Show();
            this.Close();
        }

        private void btn_addSocio_Click(object sender, RoutedEventArgs e)
        {
            var was = new WindowAddSocio(_usuario);
            was.Closed += (s, args) => InitializeSocios();
            was.Show();
        }
    }
}
