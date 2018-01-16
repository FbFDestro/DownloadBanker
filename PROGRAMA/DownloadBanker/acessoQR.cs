using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DownloadBanker
{
    class acessoQR
    {
        Criptografia cripto = new Criptografia("ETEP");

        int id_qr;
        double valor_qr;
        string status_qr;



        // variaveis para acessar o MySql
        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        public string Status_qr
        {
            get
            {
                return status_qr;
            }

            set
            {
                status_qr = value;
            }
        }

        public double Valor_qr
        {
            get
            {
                return valor_qr;
            }

            set
            {
                valor_qr = value;
            }
        }

        public int Id_qr
        {
            get
            {
                return id_qr;
            }

            set
            {
                id_qr = value;
            }
        }

        // método private de acesso ao BD
        private void carregar_tabela(string comando)
        {
            // criar uma sacolinha vazia
            tabela_memoria = new DataTable();

            // converter um texto (string) para um comando SQL
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);

            // executar o comando SQL 
            executar_comando = new MySqlCommandBuilder(comando_sql);

            // resposta que será armazenada na sacolinha
            comando_sql.Fill(tabela_memoria);
        }


        public void cadastrarCartao(string valor, string status)
        {
            valor = cripto.Encrypt(valor);
            carregar_tabela("insert into QrCode values (0,'" + valor + "','" + status + "');");
        }

        public DataTable listarCartao()
        {

            carregar_tabela("select * from QrCode");
            return tabela_memoria;

        }

    }
}
