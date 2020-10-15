using System;
using System.Text;
using System.Windows.Controls;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RegistroPrestamos.Validaciones
{
    public class ValidarFeha : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
           if(value != null){
                DateTime fecha = new DateTime();
                DateTime.TryParse(value.ToString(), out fecha);

                if(fecha > DateTime.Now)
                    return new ValidationResult(false,"Debes poner una fecha valida");

            return ValidationResult.ValidResult;
           }

           return new ValidationResult(false, "Debes poner una fecha");
        }
    }
}