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
    public partial class cPrestamos : Window
    {
        public cPrestamos()
        {
            InitializeComponent();
        }
        
        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            
            var listado = new List<Prestamos>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: 
                        listado = PrestamosBLL.GetList(e => e.PrestamoId == int.Parse(CriterioTextBox.Text));
                        break;

                    case 1:                       
                        listado = PrestamosBLL.GetList(e => e.PersonaId== int.Parse(CriterioTextBox.Text));
                        break;
                    case 2:                       
                        listado = PrestamosBLL.GetList(e => e.Cliente.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;
                    case 3:                       
                        listado = PrestamosBLL.GetList(e => e.Fecha.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;
                    case 4:                       
                        listado = PrestamosBLL.GetList(e => e.Monto== float.Parse(CriterioTextBox.Text));
                        break; 
                    case 5:                       
                        listado = PrestamosBLL.GetList(e => e.Balance== float.Parse(CriterioTextBox.Text));
                        break;   
                    case 6:                       
                        listado = PrestamosBLL.GetList(e => e.Concepto.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break; 
                     

                    
                }
            }
            else
            {
                listado = PrestamosBLL.GetList(c => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }



        
        
    }
}