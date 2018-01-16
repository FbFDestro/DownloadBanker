using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DownloadBanker
{
    abstract class acessoDadosQR
    {
        static string codigo, valor;

        public static string Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public static string Valor
        {
            get
            {
                return valor;
            }

            set
            {
                valor = value;
            }
        }
    }
}
