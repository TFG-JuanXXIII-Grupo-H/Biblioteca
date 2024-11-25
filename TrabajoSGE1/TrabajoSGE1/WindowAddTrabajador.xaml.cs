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
    /// <summary>
    /// Lógica de interacción para WindowAddTrabajador.xaml
    /// </summary>
    public partial class WindowAddTrabajador : Window
    {
        private Usuario _usuario;
        private List<Trabajador> listaTrabajadores;

        public WindowAddTrabajador(Usuario usuario, List<Trabajador> trabajador)
        {
            InitializeComponent();
            _usuario = usuario;
            listaTrabajadores = trabajador;

            lbl_usuLog.Content = _usuario.Name;
            lbl_rango.Content = _usuario.Rango;
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            var id = 1;
            var usuario = txt_usu.Text;
            var pass = txt_pass.Text;
            var email = txt_email.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            var newTrabajador = new Trabajador(id,usuario,pass,email);

            listaTrabajadores.Add(newTrabajador);
            MessageBox.Show("Trabajador añadido correctamente.");

            this.Close();
        }
    }
}
