using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TrabajoSGE1
{
    public partial class WindowAddSocio : Window
    {
        private String usuarioLog;
        private String rangoUsuario;
        private List<WindowRegSocios.Socio> listaSocios;
        public WindowAddSocio(string usuLog, string rangoUsu, List<WindowRegSocios.Socio> socios)
        {
            InitializeComponent();
            usuarioLog = usuLog;
            rangoUsuario = rangoUsu;
            lbl_usuLog.Content = usuarioLog;
            lbl_rango.Content = rangoUsuario;

        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            WindowRegSocios wrs = new WindowRegSocios(usuarioLog, rangoUsuario);
            wrs.Show();
            this.Close();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            string dni = txt_dni.Text;
            string nombre = txt_nom.Text;
            string cuentaBancaria = txt_cuentaB.Text;
            string direccion = txt_dir.Text;
            string cuota = "Pagada";
            string fechaAlta = 
            string fechaCaducidad = txt_fechCad.Text;

            // Validar que los campos no estén vacíos (puedes agregar más validaciones si es necesario)
            if (string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Crear un nuevo objeto Socio
            WindowRegSocios.Socio nuevoSocio = new WindowRegSocios.Socio()
            {
                Dni = dni,
                Nombre = nombre,
                CuentBanc = cuentaBancaria,
                Dir = direccion,
                Cuota = cuota,
                FechAlt = fechaAlta,
                FechCad = fechaCaducidad
            };

            // Agregar el nuevo socio a la lista
            listaSocios.Add(nuevoSocio);

            // (Opcional) Limpiar los TextBox después de agregar el socio
            txt_dni.Clear();
            txt_nombre.Clear();
            txt_cuentBanc.Clear();
            txt_dir.Clear();
            txt_cuota.Clear();
            txt_fechAlt.Clear();
            txt_fechCad.Clear();

            // (Opcional) Mostrar un mensaje de éxito
            MessageBox.Show("Socio agregado correctamente.");
        }
    }
}
