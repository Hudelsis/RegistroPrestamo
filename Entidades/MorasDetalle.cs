using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace RegistroPrestamos.Entidades
{
    public class MorasDetalle
    {
        [Key] 
        public int MoraDetalleId { get; set; }
        public int MoraId { get; set; }
        public int PrestamoId { get; set; }
        public float Valor{ get; set; }


        public  MorasDetalle()
        {
            MoraDetalleId = 0;
            MoraId = 0;
            PrestamoId = 0;
            Valor= 0;
        }


        public MorasDetalle(int moraId, int prestamoId, float valor)
        {
            MoraDetalleId = 0;
            MoraId = moraId;
            PrestamoId = prestamoId;
            Valor = valor;
        }
    }

}