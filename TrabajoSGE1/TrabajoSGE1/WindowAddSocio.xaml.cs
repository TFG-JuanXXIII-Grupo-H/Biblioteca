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
        public WindowAddSocio(string usuLog, string rangoUsu)
        {
            InitializeComponent();
            usuarioLog = usuLog;
            rangoUsuario = rangoUsu;
            lbl_usuLog.Content = usuarioLog;
            lbl_rango.Content = rangoUsuario;
        }
    }
}
