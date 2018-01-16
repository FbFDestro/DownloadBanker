using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DownloadBanker
{
    class acessoInicializações
    {
        int num_inicializacoes, novoNum;

        public int num_Inicializacoes
        {
            get { return num_inicializacoes; }
            set { num_inicializacoes = value; }
        }

        // variaveis para acessar o MySql
        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

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

        public bool verificarInicializacoes()
        {

            carregar_tabela("select * from inicializacoes");

            try
            {
                num_Inicializacoes = Convert.ToInt32(tabela_memoria.Rows[0]["num_inicializacoes"].ToString());
                novoNum = num_inicializacoes + 1;
            }
            catch { }

            if (num_inicializacoes == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void atualizarInicializacoes()
        {

            carregar_tabela("update inicializacoes set num_inicializacoes='" + novoNum + "' where num_inicializacoes=" + num_Inicializacoes + ";");

        }
    }
}
