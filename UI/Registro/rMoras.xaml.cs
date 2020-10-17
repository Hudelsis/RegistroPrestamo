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
using System.Text.RegularExpressions;


namespace RegistroPrestamos.UI.Registro
{
     public partial class rMoras : Window
     {
        //private bool editando = false;
        private Moras moras = new Moras();
        private Prestamos prestamo = new Prestamos();

        public rMoras()
        {
            InitializeComponent();
            this.DataContext = moras;
        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = moras;
        }
        private void Limpiar()
        {
            moras = new Moras();
            MoraIdTextBox.Text = "";
            this.DataContext = moras;
        }   
        private bool Validar()
        {
            if (MoraIdTextBox.Text.Length == 0 || PrestamoTextBox.Text.Length == 0 ||
                PrestamoTextBox.Text.Length == 0 || ValorTextBox.Text.Length == 0 || MoraIdTextBox.Text.Length == 0)
            {
                MessageBox.Show("Favor llenar los campo.", "Obligatorio.", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
             if (!Regex.IsMatch(MoraIdTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Id Solo permite un digito del 0 - 9.", "Id.", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Regex.IsMatch(PrestamoTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Id Solo permite un digito del 0 - 9.", "MoraId.", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Regex.IsMatch(PrestamoTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Id Solo permite un digito del 0 - 9.", "PrestamoId.", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Regex.IsMatch(ValorTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Solo permite un digito del 0 - 9.", "Valor.", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
           if(MoraIdTextBox.Text.Length <= 0)
                return;

            Moras encontrado = MorasBLL.Buscar(int.Parse(MoraIdTextBox.Text));

            if (encontrado != null)
            {
                moras = encontrado;
                Cargar();
                MessageBox.Show("Mora Encontrada", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show($"Esta Id de Mora no fue encontrada.\n\nAsegurese que existe o cree una nueva.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
            }
        }
        private void BuscarPrestamosButton_Click(object sender, RoutedEventArgs e)
        {
             if(PrestamoTextBox.Text.Length > 0){
                 prestamo = PrestamosBLL.Buscar(int.Parse(PrestamoTextBox.Text));

                 if(prestamo.PrestamoId > 0){
                     MessageBox.Show("Prestamo Seleccionado");
                 }else{
                     MessageBox.Show("Prestamo no encontrado");
                 }
             }else{ 
                     MessageBox.Show("Debe digitar el numero de prestamo");
             }
        }
        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if(prestamo.PrestamoId > 0){

                var filaDetalle = new MorasDetalle(moras.MoraId, int.Parse(PrestamoTextBox.Text), float.Parse(ValorTextBox.Text));

                moras.Detalle.Add(filaDetalle);
                Cargar();

                
                ValorTextBox.Clear();
                PrestamoTextBox.Clear();   
            }else{
                MessageBox.Show("Prestamo no encontrado");
            }  
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
           //editando = false;
        }
        
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {  
              bool paso = false;

            if (!Validar())
                return;


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
                    MessageBox.Show("No existe en la base de datos", "Error");
                }
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transacciones exitosa.", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Transacciones  Fallida.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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