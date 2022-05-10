using System;
using System.Collections.Generic;
using System.Text;

namespace CreditSuisse.Utils
{
    public static class UtlidadesFormatacao
    {
        public static DateTime ToData(this string value)
        {
            if (DateTime.TryParse(value, out DateTime data))
                return data;
            else throw new Exception("Data informada invalida");

        }

        public static double ToDouble(this string value)
        {
            if (string.IsNullOrEmpty(value)) return 0;

            if (double.TryParse(value, out double valor))
                return valor;
            else throw new Exception("Valor informada invalido");
        }

        public static double ToInt(this string value)
        {
            if (string.IsNullOrEmpty(value)) return 0;

            if (double.TryParse(value, out double valor))
                return valor;
            else throw new Exception("Valor informada invalido");
        }

    }
}
