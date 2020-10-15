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

namespace RegistroPrestamos.UI.Consultas
{
    public partial class cClientes : Window
    {
        public cClientes()
        {
            InitializeComponent();
        }
        
        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            
            var listado = new List<Clientes>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: 
                        listado = ClientesBLL.GetList(e => e.Id == int.Parse(CriterioTextBox.Text));
                        break;

                    case 1:                       
                        listado = ClientesBLL.GetList(e => e.Nombres.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;
                    case 2:                       
                        listado = ClientesBLL.GetList(e => e.Telefono.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;
                    case 3:                       
                        listado = ClientesBLL.GetList(e => e.Cedula.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;   
                    case 4:                       
                        listado = ClientesBLL.GetList(e => e.Direccion.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;  
                    case 5:                       
                        listado = ClientesBLL.GetList(e => e.Balance== float.Parse(CriterioTextBox.Text));
                        break; 

                    
                }
            }
            else
            {
                listado = ClientesBLL.GetList(c => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }



        
        
    }
}