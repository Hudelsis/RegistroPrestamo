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
     public partial class rMoras : Window
     {
        private Moras moras = new Moras();

        public rMoras()
        {
            InitializeComponent();
            //Constructor
            this.DataContext = moras;
        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = moras;
        }
        private void Limpiar()
        {
            this.moras = new Moras();
            this.DataContext = moras;
        }
        private bool Validar()
        {
            bool Validado = true;
            if (MoraIdTextBox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transaccion Errada", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return Validado;

        }
        
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
           
            Moras encontrado = MorasBLL.Buscar(moras.MoraId);

            if (encontrado != null)
            {
                moras = encontrado;
                Cargar();
                MessageBox.Show("Articulo Encontrado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show($"Esta Id de Articulo no fue encontrada.\n\nAsegurese que existe o cree una nueva.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
            }
        }
         private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
                            
         var filaDetalle = new MorasDetalle(Convert.ToInt32(MoraIdTextBox.Text), Convert.ToInt32(PrestamoTextBox.Text), Convert.ToSingle(ValorTextBox.Text));

           moras.Detalle.Add(filaDetalle);
            Cargar();

           MoraIdTextBox.Clear();
           ValorTextBox.Clear();
           PrestamoTextBox.Clear();


            
        }
        
        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                moras.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Moras esValido = MorasBLL.Buscar(moras.MoraId);

            return (esValido != null);
        }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (moras.MoraId == 0)
            {
                paso = MorasBLL.Guardar(moras);
            }
            else
            {
                if (ExisteEnLaBaseDeDatos())
                {
                    paso = MorasBLL.Guardar(moras);
                }
                else
                {
                    MessageBox.Show("No existe en la base de datos", "ERROR");
                }
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Fallo al guardar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    
        
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (MoraIdTextBox.Text.Length ==0){
                return;
            }
            if (MorasBLL.Eliminar(int.Parse(MoraIdTextBox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {  
                    MessageBox.Show("No se pudo eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            
        }
        

    }
}