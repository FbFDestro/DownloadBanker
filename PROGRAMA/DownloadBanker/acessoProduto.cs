using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DownloadBanker
{
    class acessoProduto
    {
        Criptografia cripto = new Criptografia("ETEP");

        int id_prod, status_prod, id_user;
        double valor_prod;
        string nome_prod, sobre_prod, contem_prod, imagem_prod, arquivo_prod, tamanho_prod;

        #region Variaveis STRING

        public string Nome_prod
        {
            get { return nome_prod; }
            set { nome_prod = value; }
        }

        public string Sobre_prod
        {
            get { return sobre_prod; }
            set { sobre_prod = value; }
        }

        public string Contem_prod
        {
            get { return contem_prod; }
            set { contem_prod = value; }
        }

        public string Imagem_prod
        {
            get { return imagem_prod; }
            set { imagem_prod = value; }
        }

        public string Arquivo_prod
        {
            get { return arquivo_prod; }
            set { arquivo_prod = value; }
        }

        public string Tamanho_prod
        {
            get { return tamanho_prod; }
            set { tamanho_prod = value; }
        }

        #endregion

        #region Variaveis INT
        public int Id_prod
        {
            get { return id_prod; }
            set { id_prod = value; }
        }

        public int Status_prod
        {
            get { return status_prod; }
            set { status_prod = value; }
        }

        public int Id_user
        {
            get { return id_user; }
            set { id_user = value; }
        }
        #endregion

        #region Variaveis FLOAT
        public double Valor_prod
        {
            get { return valor_prod; }
            set { valor_prod = value; }
        }
        #endregion

        DataTable tabelaFiltro;

        public DataTable TabelaFiltro
        {
            get { return tabelaFiltro; }
            set { tabelaFiltro = value; }
        }

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

        public DataTable listarTudo()
        {
            // criando uma nova tabela memória para
            // as informações descriptografadas
            DataTable tabelaTemp = new DataTable();

            // criando as colunas da nova tabela memória
            tabelaTemp.Columns.Add("id_prod", typeof(int));
            tabelaTemp.Columns.Add("id_user", typeof(int));
            tabelaTemp.Columns.Add("nome_prod", typeof(String));
            tabelaTemp.Columns.Add("valor_prod", typeof(double));
            tabelaTemp.Columns.Add("imagem_prod", typeof(String));
            tabelaTemp.Columns.Add("arquivo_prod", typeof(String));
            tabelaTemp.Columns.Add("status_prod", typeof(int));
            tabelaTemp.Columns.Add("tamanho_prod", typeof(String));



            // carregando os dados da tabela criptografada
            carregar_tabela("select * from produto where status_prod=1;");

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = tabelaTemp.NewRow();

                linha["id_prod"] = tabela_memoria.Rows[i]["id_prod"].ToString();
                linha["id_user"] = tabela_memoria.Rows[i]["id_user"].ToString();
                linha["nome_prod"] = cripto.Decrypt(tabela_memoria.Rows[i]["nome_prod"].ToString());
                linha["valor_prod"] = cripto.Decrypt(tabela_memoria.Rows[i]["valor_prod"].ToString());
                linha["imagem_prod"] = cripto.Decrypt(tabela_memoria.Rows[i]["imagem_prod"].ToString());
                linha["arquivo_prod"] = cripto.Decrypt(tabela_memoria.Rows[i]["arquivo_prod"].ToString());
                linha["status_prod"] = tabela_memoria.Rows[i]["status_prod"].ToString();
                linha["tamanho_prod"] = cripto.Decrypt(tabela_memoria.Rows[i]["tamanho_prod"].ToString());

                tabelaTemp.Rows.Add(linha);
            }

            return tabelaTemp;
        }

        public DataTable pesquisaNomeFiltro(String Pesq)
        {
            // criando uma nova tabela memória para
            // as informações descriptografadas
            DataTable tabelaTemp = new DataTable();

            // criando as colunas da nova tabela memória
            tabelaTemp.Columns.Add("id_prod", typeof(int));
            tabelaTemp.Columns.Add("id_user", typeof(int));
            tabelaTemp.Columns.Add("nome_prod", typeof(String));
            tabelaTemp.Columns.Add("valor_prod", typeof(double));
            tabelaTemp.Columns.Add("imagem_prod", typeof(String));
            tabelaTemp.Columns.Add("arquivo_prod", typeof(String));
            tabelaTemp.Columns.Add("status_prod", typeof(int));
            tabelaTemp.Columns.Add("tamanho_prod", typeof(String));


            // carregando os dados da tabela criptografada
            carregar_tabela("select * from produto where status_prod=1;");

            tabelaTemp.DefaultView.RowFilter = "nome_prod like '" + Pesq + "%'";

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = tabelaTemp.NewRow();

                linha["id_prod"] = tabela_memoria.Rows[i]["id_prod"].ToString();
                linha["id_user"] = tabela_memoria.Rows[i]["id_user"].ToString();
                linha["nome_prod"] = cripto.Decrypt(tabela_memoria.Rows[i]["nome_prod"].ToString());
                linha["valor_prod"] = cripto.Decrypt(tabela_memoria.Rows[i]["valor_prod"].ToString());
                linha["imagem_prod"] = cripto.Decrypt(tabela_memoria.Rows[i]["imagem_prod"].ToString());
                linha["arquivo_prod"] = cripto.Decrypt(tabela_memoria.Rows[i]["arquivo_prod"].ToString());
                linha["status_prod"] = tabela_memoria.Rows[i]["status_prod"].ToString();
                linha["tamanho_prod"] = cripto.Decrypt(tabela_memoria.Rows[i]["tamanho_prod"].ToString());



                tabelaTemp.Rows.Add(linha);
            }
            tabelaFiltro = tabelaTemp;
            return tabelaFiltro;
        }

        public void desativarProd(string status)
        {
            carregar_tabela("update produto set status_prod=0 where id_prod = " + status + ";");
        }
    }
}
