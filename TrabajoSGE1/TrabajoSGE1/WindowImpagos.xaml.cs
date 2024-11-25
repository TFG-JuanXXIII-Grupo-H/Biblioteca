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
    /// Lógica de interacción para WindowImpagos.xaml
    /// </summary>
    public partial class WindowImpagos : Window
    {
        private Usuario _usuario;
        public WindowImpagos(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            lbl_usuLog.Content = _usuario.Name;
            lbl_rango.Content = _usuario.Rango;
        }

        private void btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1(_usuario);
            w1.Show();
            this.Close();
        }
    }
}
