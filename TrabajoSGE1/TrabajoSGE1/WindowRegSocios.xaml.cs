using System;
using System.Collections.Generic;
using System.Windows;

namespace TrabajoSGE1
{
    public partial class WindowRegSocios : Window
    {
        private String usuarioLog;
        private String rangoUsuario;

        public WindowRegSocios(string usuLog, string rangoUsu)
        {
            InitializeComponent();
            usuarioLog = usuLog;
            rangoUsuario = rangoUsu;
            lbl_usuLog.Content = usuarioLog;
            lbl_rango.Content = rangoUsuario;

            List<Socio> lista = new List<Socio>
            {
                new Socio()
                {
                    Id = 1,
                    Dni = "09134336R",
                    Nombre = "Jose",
                    CuentBanc = "****3546",
                    Dir = "C/Juan Pollas",
                    Cuota = "Pagada",
                    FechAlt = "04/11/2024",
                    FechCad = "04/12/2024"
                }
            };

            lst_socios.ItemsSource = lista;
        }

        private void btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1(usuarioLog, rangoUsuario);
            w1.Show();
            this.Close();
        }

        public class Socio
        {
            public int Id { get; set; }
            public String Dni { get; set; }
            public String Nombre { get; set; }
            public String CuentBanc { get; set; }
            public String Dir { get; set; }
            public String Cuota { get; set; }
            public String FechAlt { get; set; }
            public String FechCad { get; set; }
        }

        private void btn_addSocio_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
