using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;


namespace DownloadBanker
{
    class acessoAuditoriaFunc
    {

        Criptografia cripto = new Criptografia("ETEP");

        DataTable tabelaFiltro;

        public DataTable TabelaFiltro
        {
            get { return tabelaFiltro; }
            set { tabelaFiltro = value; }
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


        private String conversorData(String data)
        {
            DateTime dt = Convert.ToDateTime(data);
            return dt.ToString("yyyy/MM/dd");
        }

        public void inserir(string dt, string hr, string id, string acao, string desc)
        {
            String dataCorreta = conversorData(dt);

            dataCorreta = cripto.Encrypt(dataCorreta);
            hr = cripto.Encrypt(hr);
            acao = cripto.Encrypt(acao);
            desc = cripto.Encrypt(desc);

            carregar_tabela("insert into auditoriaF values(0,'" + dataCorreta + "','" + hr + "','" + id + "','" + acao + "','" + desc + "');");

            
        }

        public DataTable Log()
        {
            DataTable temp = new DataTable();

            carregar_tabela("select af.* , f.nome1_func from auditoriaF af inner join funcionario f on f.id_func=af.id_func;");
            temp.Columns.Add("id_audF", typeof(int));
            temp.Columns.Add("nome1_func", typeof(String));
            temp.Columns.Add("acao_audF", typeof(String));
            temp.Columns.Add("desc_audF", typeof(String));
            temp.Columns.Add("data_audF", typeof(String));
            temp.Columns.Add("hora_audF", typeof(String));



            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = temp.NewRow();
                linha["id_audF"] = tabela_memoria.Rows[i]["id_audF"].ToString();
                linha["nome1_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["nome1_func"].ToString());
                linha["data_audF"] = cripto.Decrypt(tabela_memoria.Rows[i]["data_audF"].ToString());
                linha["hora_audF"] = cripto.Decrypt(tabela_memoria.Rows[i]["hora_audF"].ToString());
                linha["acao_audF"] = cripto.Decrypt(tabela_memoria.Rows[i]["acao_audF"].ToString());
                linha["desc_audF"] = cripto.Decrypt(tabela_memoria.Rows[i]["desc_audF"].ToString());
                temp.Rows.Add(linha);
            }

            return temp;
        }

        public DataTable pesqFunc(string pesq)
        {
            DataTable temp = new DataTable();

            carregar_tabela("select af.* , f.nome1_func from auditoriaF af inner join funcionario f on f.id_func=af.id_func;");
            temp.Columns.Add("id_audF", typeof(int));
            temp.Columns.Add("nome1_func", typeof(String));
            temp.Columns.Add("acao_audF", typeof(String));
            temp.Columns.Add("desc_audF", typeof(String));
            temp.Columns.Add("data_audF", typeof(String));
            temp.Columns.Add("hora_audF", typeof(String));

            temp.DefaultView.RowFilter = "nome1_func like '" + pesq + "%'";

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = temp.NewRow();
                linha["id_audF"] = tabela_memoria.Rows[i]["id_audF"].ToString();
                linha["nome1_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["nome1_func"].ToString());
                linha["data_audF"] = cripto.Decrypt(tabela_memoria.Rows[i]["data_audF"].ToString());
                linha["hora_audF"] = cripto.Decrypt(tabela_memoria.Rows[i]["hora_audF"].ToString());
                linha["acao_audF"] = cripto.Decrypt(tabela_memoria.Rows[i]["acao_audF"].ToString());
                linha["desc_audF"] = cripto.Decrypt(tabela_memoria.Rows[i]["desc_audF"].ToString());
                temp.Rows.Add(linha);
            }

            tabelaFiltro = temp;
            return tabelaFiltro;
        }
    }
}
