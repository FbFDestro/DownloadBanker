using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DownloadBanker
{
    abstract class acessoPergRespSecreta
    {
        static string identi, perg, resp;

        public static string Identi
        {
            get { return acessoPergRespSecreta.identi; }
            set { acessoPergRespSecreta.identi = value; }
        }

        public static string Perg
        {
            get { return acessoPergRespSecreta.perg; }
            set { acessoPergRespSecreta.perg = value; }
        }

        public static string Resp
        {
            get { return acessoPergRespSecreta.resp; }
            set { acessoPergRespSecreta.resp = value; }
        }


    }
}
