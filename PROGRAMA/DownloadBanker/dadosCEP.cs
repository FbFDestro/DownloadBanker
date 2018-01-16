using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DownloadBanker
{
    abstract class dadosCEP
    {
        static String cep, num, comple, uf, cidade, bairro, tipo, rua, zonaRural;

        public static String ZonaRural
        {
            get { return dadosCEP.zonaRural; }
            set { dadosCEP.zonaRural = value; }
        }

        public static String Rua
        {
            get { return dadosCEP.rua; }
            set { dadosCEP.rua = value; }
        }

        public static String Tipo
        {
            get { return dadosCEP.tipo; }
            set { dadosCEP.tipo = value; }
        }

        public static String Bairro
        {
            get { return dadosCEP.bairro; }
            set { dadosCEP.bairro = value; }
        }

        public static String Cidade
        {
            get { return dadosCEP.cidade; }
            set { dadosCEP.cidade = value; }
        }

        public static String Uf
        {
            get { return dadosCEP.uf; }
            set { dadosCEP.uf = value; }
        }

        public static String Comple
        {
            get { return dadosCEP.comple; }
            set { dadosCEP.comple = value; }
        }

        public static String Num
        {
            get { return dadosCEP.num; }
            set { dadosCEP.num = value; }
        }

        public static String Cep
        {
            get { return dadosCEP.cep; }
            set { dadosCEP.cep = value; }
        }

    }
}
