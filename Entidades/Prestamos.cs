
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace RegistroPrestamos.Entidades
{
    public class Prestamos
    {
        [Key] 
        public int PrestamoId { get; set; }

        public int PersonaId { get; set; }

        public string Cliente{ get; set; }

        public string Fecha{ get; set; }

        public float Monto { get; set; }

        public float Balance{ get; set; }

        public string Concepto { get; set; }

        
    }

}