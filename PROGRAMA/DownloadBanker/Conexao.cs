using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DownloadBanker
{
    static class Conexao
    {
        static MySqlConnection conectar;

        public static MySqlConnection Conectar
        {
            get { return Conexao.conectar; }
            set { Conexao.conectar = value; }
        }


        public static Boolean criar_Conexao()
        {
            if (conectar != null)
            {
                conectar.Close();
            }

            string configuracao = string.Format("server={0};user id={1}; password={2};database=mysql; pooling=false", dadosConexao.Ip, dadosConexao.Usu, dadosConexao.Senha);

            try
            {
                conectar = new MySqlConnection(configuracao);
                conectar.Open();
            }
            catch (MySqlException erro)
            {
                return false;
            }

            MySqlDataReader banco = null;

            MySqlCommand usar = new MySqlCommand("use DownloadBankerCripto", conectar);

            try
            {
                banco = usar.ExecuteReader();
            }
            catch (MySqlException erro)
            {
                return false;
            }
            finally
            {
                if (banco != null)
                {
                    banco.Close();
                }
            }

            return true;
        }
    }
}
