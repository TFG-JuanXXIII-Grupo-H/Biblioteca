using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace TrabajoSGE1
{
    public partial class WindowAddSocio : Window
    {
        private Usuario _usuario;

        public WindowAddSocio(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;

            lbl_usuLog.Content = _usuario.Name;
            lbl_rango.Content = _usuario.Rango;
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void btn_add_Click(object sender, RoutedEventArgs e)
        {
            string dni = txt_dni.Text;
            string nombre = txt_nom.Text;
            int cadLenght = txt_cuentaB.Text.Length;
            string cuentaBancaria = "****" + txt_cuentaB.Text.Substring(cadLenght - 4);
            string direccion = txt_dir.Text;
            int cuota = 1;
            var fechaAlta = DateTime.Now;
            var fechaCaducidad = fechaAlta.AddMonths(1);

            if (string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            using (var client = new HttpClient())
            {
                var jsonContent = new
                {
                    dni_socio = dni,
                    nombre_socio = nombre,
                    cnta_bancaria_socio = cuentaBancaria,
                    lugar_socio = direccion,
                    cuota_pagada_socio = cuota,
                    telefono_socio = 646845442
                };
                
                var content = new StringContent(
                    JsonSerializer.Serialize(jsonContent), 
                    Encoding.UTF8, 
                    "application/json"
                );

                try
                {
                    var response = await client.PostAsync("http://localhost:3000/api/v1/socios", content);
                    var responseBody = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Socio creado correctamente.");
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
            var nuevoSocio = new Socio()
            {
                Dni = dni,
                Nombre = nombre,
                CuentBanc = cuentaBancaria,
                Dir = direccion,
                Cuota = cuota,
                FechAlt = fechaAlta,
                FechCad = fechaCaducidad
            };
            
            this.Close();
        }
    }
}


