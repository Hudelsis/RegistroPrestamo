
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace RegistroPrestamos.Entidades
{
    public class Clientes
    {
        [Key] 
        public int Id { get; set; }
      
        public string Nombres { get; set; }

        public string Telefono { get; set; }

        public string Cedula { get; set; }

        public string Direccion { get; set; }

        public float Balance { get; set; } 
    }

}