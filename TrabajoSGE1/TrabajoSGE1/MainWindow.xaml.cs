using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.Json;

namespace TrabajoSGE1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Dictionary<string, Usuario> listUser = new Dictionary<string, Usuario>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btn_log_Click(object sender, RoutedEventArgs e)
        {
            var usuarioIngresado = txt_usu.Text;
            var passIngresado = txt_pass.Password;

            using (var client = new HttpClient())
            {
                var jsonContent = new {
                    username = usuarioIngresado,
                    password = passIngresado
                };

                var content = new StringContent(
                    JsonSerializer.Serialize(jsonContent), 
                    Encoding.UTF8, 
                    "application/json"
                );

                try
                {
                    var response = await client.PostAsync("http://localhost:3000/api/v1/login", content);
                    var responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        using (var jsonDoc = JsonDocument.Parse(responseBody))
                        {
                            var root = jsonDoc.RootElement;
                            if (root.TryGetProperty("user", out var userElement))
                            {
                                var options = new JsonSerializerOptions
                                {
                                    PropertyNameCaseInsensitive = true
                                };
                                var usuario = JsonSerializer.Deserialize<Usuario>(userElement.GetRawText(), options);
                                if (usuario != null)
                                {
                                    var window1 = new Window1(usuario);
                                    window1.Show();
                                    this.Close(); 
                                }
                                else
                                {
                                    MessageBox.Show("Error al iniciar sesion.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Error al iniciar sesion.");
                            }
                        };
                    }
                    else
                    {
                        MessageBox.Show(responseBody);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexión: " + ex.Message);
                }
            }
        }
    }
}