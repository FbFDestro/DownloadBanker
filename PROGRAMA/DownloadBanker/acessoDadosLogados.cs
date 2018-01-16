using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DownloadBanker
{
    abstract class acessoDadosLogado
    {
        static string codigo, nome, login, tipo, senha;

        public static string Codigo
        {
            get { return acessoDadosLogado.codigo; }
            set { acessoDadosLogado.codigo = value; }
        }

        public static string Senha
        {
            get { return acessoDadosLogado.senha; }
            set { acessoDadosLogado.senha = value; }
        }

        public static string Tipo
        {
            get { return acessoDadosLogado.tipo; }
            set { acessoDadosLogado.tipo = value; }
        }

        public static string Login
        {
            get { return acessoDadosLogado.login; }
            set { acessoDadosLogado.login = value; }
        }

        public static string Nome
        {
            get { return acessoDadosLogado.nome; }
            set { acessoDadosLogado.nome = value; }
        }
    }
}
