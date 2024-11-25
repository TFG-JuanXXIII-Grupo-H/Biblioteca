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
    /// Lógica de interacción para WindowRegLibros.xaml
    /// </summary>
    public partial class WindowRegLibros : Window
    {
        private Usuario _usuario;
        private List<Libro> lista;
        private List<Recibo> listaRec;

        public WindowRegLibros(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;

            lista = new List<Libro>
            {
                new Libro() { ISBN = "1234", nombre = "Libro 1", editorial = "asaber.es", year = "12/12/2022", genero = "no binario", precio = 2, codBiblio = 1, autor = "pascu" },
                new Libro() { ISBN = "2345", nombre = "libro 2", editorial = "asaber.com", year = "11/11/2011", genero = "binario", precio = 2, codBiblio = 2, autor = "joshua" }
            };

            lbl_usuLog.Content = _usuario.Name;
            lbl_rango.Content = _usuario.Rango;

            lst_libros.ItemsSource = lista;
        }

        private void btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1(_usuario);
            w1.Show();
            this.Close();
        }

        public void ActualizarListaLibros()
        {
            lst_libros.ItemsSource = null;
            lst_libros.ItemsSource = lista;
        }

        private void btn_addSocio_Click(object sender, RoutedEventArgs e)
        {
            WindowAddLibro was = new WindowAddLibro(_usuario, lista);
            was.Closed += (s, args) => ActualizarListaLibros();
            was.Show();
        }

        private void btn_alqLibro_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
