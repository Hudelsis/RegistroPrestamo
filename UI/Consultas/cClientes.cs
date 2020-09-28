using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RegistroPrestamos.Entidades;
using RegistroPrestamos.BLL;
using RegistroPrestamos.DAL;
using Microsoft.EntityFrameworkCore;

namespace RegistroPrestamos.UI.Registro
{
    public partial class cClientes : Window
    {
        public cClientes()
        {
            InitializeComponent();
        }
        
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {

        }
        
    }
}