using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RegistroPrestamos.Entidades
{
    public class Moras
    {
        [Key] 
        public int MoraId{ get; set;}

        public DateTime Fecha{ get; set;}

        public float Total{ get; set;}

        [ForeignKey("MoraId")]
        public List<MorasDetalle> Detalle { get; set; } = new List<MorasDetalle>();

         public Moras()
        {
            MoraId = 0;
            Fecha = DateTime.Now;
            Total = 0;
           
        }

        public Moras(int moraId, DateTime fecha, float total)
        {
            MoraId = moraId;
            Fecha = fecha;
            Total = total;
        }

    }


        
    

}