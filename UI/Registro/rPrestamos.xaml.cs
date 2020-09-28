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
    public partial class rPrestamos : Window
    {
        private bool editando = false;
        private Prestamos prestamo;

        public rPrestamos()
        {
            InitializeComponent();
            Limpiar();
        }

        private void Limpiar(){
            IDTextBox.Text = "";
            IdPersonaTextBox.Text = "";
            IDTextBox.IsEnabled = true;

            prestamo = new Prestamos();
            this.DataContext = prestamo;
        }

        private bool Validar()
        {
            bool esValido = true; 

            if(editando){
                if(IDTextBox.Text.Length == 0){
                    esValido = false;
                    MessageBox.Show("Transaccion Fallida, Debe indicar el numero de prestamo que desea editar", "Fallo");
                }
            }

            if (IdPersonaTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida, Debe seleccionar un cliente", "Fallo");
            }

            if (ConceptoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida, Debe indicar un concepto", "Fallo");
            }

            if (MontoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida, Debe introducir un monto", "Fallo");
            }

            return esValido; 
        }

        private void desabilitarTextBox(bool estado){
            FechaTextBox.IsEnabled = estado;
            IdPersonaTextBox.IsEnabled = estado;
            ConceptoTextBox.IsEnabled = estado;
            MontoTextBox.IsEnabled = estado;
        }

        private void buscarCliente(int id){ 
            Clientes cliente = new Clientes();
            if(id > 0){
                cliente = ClientesBLL.Buscar(id);
                IdPersonaTextBox.Text = cliente.Id.ToString();
                ClienteTextBox.Text = cliente.Nombres;
            }
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            if (IDTextBox.Text.Length ==0){
                return;
            }

            prestamo = PrestamosBLL.Buscar(int.Parse(IDTextBox.Text));

            if (prestamo != null)
            {
                desabilitarTextBox(false); 
                IDTextBox.Text = prestamo.PrestamoId.ToString();
                FechaTextBox.Text = prestamo.Fecha; 
                ConceptoTextBox.Text = prestamo.Concepto;
                MontoTextBox.Text = prestamo.Monto.ToString("N2");
                BalanceTextBox.Text = prestamo.Balance.ToString("N2");
                buscarCliente(prestamo.PersonaId);
            }else{
                 this.DataContext = this.prestamo;
            }
        }

        private void BuscarPersonaButton_Click(object sender, RoutedEventArgs e)
        { 
            if(IdPersonaTextBox.Text.Length != 0){
                buscarCliente(int.Parse(IdPersonaTextBox.Text));
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar(); 
            editando = false;
            IDTextBox.IsEnabled = true;
            desabilitarTextBox(true);
        }

        private void EditarButton_Click(object sender, RoutedEventArgs e)
        {
            editando = true;
            IDTextBox.IsEnabled = false;
            desabilitarTextBox(true);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Prestamos prestamoAnt = new Prestamos();
            Clientes cliente = new Clientes();

            bool paso = false;
            int id = 0;

            if (!Validar())
                return;

            if(IDTextBox.Text.Length > 0){
                id = int.Parse(IDTextBox.Text);
                prestamoAnt = PrestamosBLL.Buscar(id);
            }

            prestamo.PrestamoId = id;
            prestamo.Fecha = FechaTextBox.Text;
            prestamo.PersonaId = int.Parse(IdPersonaTextBox.Text);
            prestamo.Cliente = ClienteTextBox.Text;
            prestamo.Concepto = ConceptoTextBox.Text;
            prestamo.Monto = float.Parse(MontoTextBox.Text); 
            prestamo.Balance = prestamo.Monto; 

            cliente = ClientesBLL.Buscar(prestamo.PersonaId);

            if(!editando){
                paso = PrestamosBLL.Guardar(prestamo); 
                cliente.Balance += prestamo.Monto; 
            }else{ 
                paso = PrestamosBLL.Modificar(prestamo); 
                cliente.Balance -= prestamoAnt.Monto;
                cliente.Balance += prestamo.Monto;
            }

            if (paso)
            {
                Limpiar();
                ClientesBLL.Guardar(cliente);
                MessageBox.Show("Transacciones exitosa!", "Exito");
            }
            else{
                MessageBox.Show("Transacciones Fallida", "Fallo");
            } 
        }

         private void EliminarButton_Click(object sender, RoutedEventArgs e)
         { 
            if (IDTextBox.Text.Length ==0){
                return;
            }

            if (IdPersonaTextBox.Text.Length ==0){
                MessageBox.Show("Debe seleccionar el prestamo", "Fallo");
                return;
            }

            Clientes cliente = ClientesBLL.Buscar(int.Parse(IdPersonaTextBox.Text));

              if (PrestamosBLL.Eliminar(int.Parse(IDTextBox.Text)))
            {
                cliente.Balance -= float.Parse(MontoTextBox.Text);
                ClientesBLL.Guardar(cliente);
                Limpiar();
                MessageBox.Show("Registro eliminado", "Exito");
            }
            else{
                MessageBox.Show("No fue posible eliminar", "Fallo"); 
            }
         }
    }
}