using RegistroPrestamos.UI.Registro;
using RegistroPrestamos.UI.Consultas;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegistroPrestamos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        } 

        private void rClientesMenu_Click(object sender, RoutedEventArgs e)
        {
            rClientes ventana = new rClientes();
            ventana.Show();
        }
        private void rPrestamosMenu_Click(object sender, RoutedEventArgs e)
        {
            rPrestamos ventana = new rPrestamos();
            ventana.Show();

        }
        private void rMorasMenu_Click(object sender, RoutedEventArgs e)
        {
           rMoras ventana = new rMoras();
           ventana.Show();

        }
        private void cClientesMenu_Click(object sender, RoutedEventArgs e)
        {
            cClientes ventana = new cClientes();
            ventana.Show();

        }

        private void cPrestamosMenu_Click(object sender, RoutedEventArgs e)
        {
            cPrestamos ventana = new cPrestamos();
            ventana.Show();
           

        }
        private void cMorasMenu_Click(object sender, RoutedEventArgs e)
        {
            cMoras ventana = new cMoras();
            ventana.Show();

        }
        private void AyudaMenu_Click(object sender, RoutedEventArgs e)
        {

        }
        
    }
}
