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
    /// Lógica de interacción para WindowAddLibro.xaml
    /// </summary>
    public partial class WindowAddLibro : Window
    {
        private Usuario _usuario;
        private List<Libro> listaLibros;

        public WindowAddLibro(Usuario usuario, List<Libro> libros)
        {
            InitializeComponent();
            _usuario = usuario;
            listaLibros = libros;

            lbl_usuLog.Content = _usuario.Name;
            lbl_rango.Content = _usuario.Rango;
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            string isbn = txt_isbn.Text;
            string nombre = txt_nom.Text;
            string editorial = txt_editorial.Text;
            string year = txt_year.Text;
            string genero = txt_genero.Text;
            int precio = int.Parse(txt_precio.Text);
            int codBib = int.Parse(txt_codBib.Text);
            string autor = txt_autor.Text;

            var nuevoLibro = new Libro()
            {
                ISBN = isbn,
                nombre = nombre,
                editorial = editorial,
                year = year,
                genero = genero,
                precio = precio,
                codBiblio = codBib,
                autor = autor
            };

            listaLibros.Add(nuevoLibro);
            MessageBox.Show("Libro añadido correctamente.");
            this.Close();
        }
    }
}
