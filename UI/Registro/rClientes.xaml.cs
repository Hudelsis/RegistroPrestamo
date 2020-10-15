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
    /// <summary>
    /// Lógica de interacción para rClientes.xaml
    /// </summary>
    public partial class rClientes : Window
    {
        private bool editando = false;

        private Clientes clientes;
        public rClientes()
        { 
            InitializeComponent();  
            Limpiar();
        }

        private void Limpiar()
        {
            this.clientes = new Clientes();
            IDTextBox.IsEnabled = true;
            IDTextBox.Text = "";
            this.DataContext = clientes;
        }

        private bool Validar()
        {
            bool esValido = true; 

            if(editando){
                if(IDTextBox.Text.Length == 0){
                    esValido = false;
                MessageBox.Show("Transaccion Fallida, Debe indicar el cliente que desea editar", "Fallo");
                }
            }

            if (NombresTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo");
            }

            return esValido; 
        }

        private void mostrarDatos(){ 
                IDTextBox.Text = clientes.Id.ToString();
                NombresTextBox.Text = clientes.Nombres;
                TelefonoTextBox.Text = clientes.Telefono;
                CedulaTextBox.Text = clientes.Cedula;
                DireccionTextBox.Text = clientes.Direccion;
                BalanceTextBox.Text = clientes.Balance.ToString("N2");
        } 

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        { 
            if (IDTextBox.Text.Length ==0){
                return;
            }

            clientes = ClientesBLL.Buscar(int.Parse(IDTextBox.Text));

            if (clientes != null)
                mostrarDatos();
            else
                clientes = new Clientes();


         this.DataContext = this.clientes;
         editando = true; 
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar(); 
            editando = false;
        } 

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            int id = 0;

            if (!Validar())
                return;

            if(IDTextBox.Text.Length > 0){
                id = int.Parse(IDTextBox.Text);
            }

            clientes.Id = id ;
            clientes.Nombres = NombresTextBox.Text;
            clientes.Cedula = CedulaTextBox.Text;
            clientes.Direccion = CedulaTextBox.Text;
            clientes.Telefono = TelefonoTextBox.Text; 
            
            if(!editando){
                paso = ClientesBLL.Guardar(clientes);
            }else{
                paso = ClientesBLL.Modificar(clientes);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transacciones exitosa!", "Existo");
            }
            else{
                MessageBox.Show("Transacciones Fallida", "Fallo");
            } 
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        { 
            if (ClientesBLL.Eliminar(int.Parse(IDTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado", "Existo");
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo"); 
        }
    }
}
