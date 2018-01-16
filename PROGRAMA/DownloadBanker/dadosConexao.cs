using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DownloadBanker
{
    static class dadosConexao
    {
        static string ip, senha, usu;

        public static string Ip
        {
            get
            {
                return ip;
            }

            set
            {
                ip = value;
            }
        }

        public static string Senha
        {
            get
            {
                return senha;
            }

            set
            {
                senha = value;
            }
        }

        public static string Usu
        {
            get
            {
                return usu;
            }

            set
            {
                usu = value;
            }
        }
    }
}
