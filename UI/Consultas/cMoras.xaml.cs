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
    public partial class cMoras : Window
    {
        public cMoras()
        {
            InitializeComponent();
        }
        
        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            
            var listado = new List<Moras>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: 
                        listado = MorasBLL.GetList(e => e.MoraId == int.Parse(CriterioTextBox.Text));
                        break;

                    case 1:                       
                        listado = MorasBLL.GetList(e => e.Fecha == DateTime.Parse(CriterioTextBox.Text));
                        break;
                    case 2:                       
                        listado = MorasBLL.GetList(e => e.Total == float.Parse(CriterioTextBox.Text));
                        break;
                    
                     

                    
                }
            }
            else
            {
                listado = MorasBLL.GetList(c => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }



        
        
    }
}