using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DownloadBanker
{
    abstract class acessoVariaveis
    {
        static string tipo_user;
        static string funcionarioS;


        public static string Tipo_user
        {
            get { return tipo_user; }
            set { tipo_user = value; }
        }

        public static string FuncionarioS
        {
            get { return funcionarioS; }
            set { funcionarioS = value; }
        }



    }
}
