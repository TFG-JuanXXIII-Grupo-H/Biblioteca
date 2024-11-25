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
    public partial class Window1 : Window
    {
        private Usuario _usuario;
        public Window1(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            lbl_usuLog.Content = usuario.Name;
            lbl_rango.Content = usuario.Rango;
            if (usuario.Rango != "admin")
            {
                btn_addTrabajador.IsEnabled = false;
                lbl_aviso.Visibility = Visibility.Visible;
            }
        }

        private void btn_logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void btn_regSocio_Click(object sender, RoutedEventArgs e)
        {
            WindowRegSocios wrg = new WindowRegSocios(_usuario);
            wrg.Show();
            this.Close();
        }

        private void btn_retrasos_Click(object sender, RoutedEventArgs e)
        {
            WindowImpagos wi = new WindowImpagos(_usuario);
            wi.Show();
            this.Close();
        }

        private void btn_regLib_Click(object sender, RoutedEventArgs e)
        {
            WindowRegLibros wrg = new WindowRegLibros(_usuario);
            wrg.Show();
            this.Close();
        }

        private void btn_regRecib_Click(object sender, RoutedEventArgs e)
        {
            WindowRegRecibos wrr = new WindowRegRecibos(_usuario);
            wrr.Show();
            this.Close();
        }

        private void btn_addTrabajador_Click(object sender, RoutedEventArgs e)
        {
            WindowRegTrabajador wgt = new WindowRegTrabajador(_usuario);
            wgt.Show();
            this.Close();
        }
    }
}
