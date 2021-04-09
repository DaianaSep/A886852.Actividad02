using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmaceutica.Clases
{
    public class Validaciones
    {
        public bool ValidarEntero(string numero, ref int Salida)
        {
            bool Flag = false;

            if (!int.TryParse(numero, out Salida))
            {
                Console.WriteLine("El valor debe ser numérico.");
            }
            else
            {
                Flag = true;
            }

            return Flag;
        }

        public bool ValidarTexto(string valor, string campo)
        {
            bool Flag = false;

            if (string.IsNullOrEmpty(valor))
            {
                Console.WriteLine("El campo {0} no debe ser vacio.", campo);
            }
            else
            {
                Flag = true;
            }

            return Flag;
        }
    }
}
