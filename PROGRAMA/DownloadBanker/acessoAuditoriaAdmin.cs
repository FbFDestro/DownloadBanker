using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;


namespace DownloadBanker
{
    class acessoAuditoriaAdmin
    {

        Criptografia cripto = new Criptografia("ETEP");
        DataTable tabelaFiltro;
        // variaveis para acessar o MySql
        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        public DataTable TabelaFiltro
        {
            get
            {
                return tabelaFiltro;
            }

            set
            {
                tabelaFiltro = value;
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

        public void inserir(string dt, string hr, string id, string acao, string desc)
        {
            String dataCorreta = conversorData(dt);

            dataCorreta = cripto.Encrypt(dataCorreta);
            hr = cripto.Encrypt(hr);
            acao = cripto.Encrypt(acao);
            desc = cripto.Encrypt(desc);

            carregar_tabela("insert into auditoriaA values(0,'" + dataCorreta + "','" + hr + "','" + id + "','" + acao + "','" + desc + "');");


        }

        private String conversorData(String data)
        {
            DateTime dt = Convert.ToDateTime(data);
            return dt.ToString("yyyy/MM/dd");
        }


        

        public DataTable Log()
        {
            DataTable temp = new DataTable();

            carregar_tabela("select aa.* , a.nome1_admin from auditoriaA aa inner join administrador a on aa.id_admin=a.id_admin;");
            temp.Columns.Add("id_audA", typeof(int));
            temp.Columns.Add("nome1_admin", typeof(String));
            temp.Columns.Add("acao_audA", typeof(String));
            temp.Columns.Add("desc_audA", typeof(String));
            temp.Columns.Add("data_audA", typeof(String));
            temp.Columns.Add("hora_audA", typeof(String));


            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = temp.NewRow();
                linha["id_audA"] = tabela_memoria.Rows[i]["id_audA"].ToString();
                linha["nome1_admin"] = cripto.Decrypt(tabela_memoria.Rows[i]["nome1_admin"].ToString());
                linha["data_audA"] = cripto.Decrypt(tabela_memoria.Rows[i]["data_audA"].ToString());
                linha["hora_audA"] = cripto.Decrypt(tabela_memoria.Rows[i]["hora_audA"].ToString());
                linha["acao_audA"] = cripto.Decrypt(tabela_memoria.Rows[i]["acao_audA"].ToString());
                linha["desc_audA"] = cripto.Decrypt(tabela_memoria.Rows[i]["desc_audA"].ToString());
                temp.Rows.Add(linha);
            }

            return temp;
        }

        public DataTable pesqAdmin(string pesq)
        {
            DataTable temp = new DataTable();

            carregar_tabela("select aa.* , a.nome1_admin from auditoriaA aa inner join administrador a on aa.id_admin=a.id_admin;");
            temp.Columns.Add("id_audA", typeof(int));
            temp.Columns.Add("nome1_admin", typeof(String));
            temp.Columns.Add("acao_audA", typeof(String));
            temp.Columns.Add("desc_audA", typeof(String));
            temp.Columns.Add("data_audA", typeof(String));
            temp.Columns.Add("hora_audA", typeof(String));

            temp.DefaultView.RowFilter = "nome1_admin like '" + pesq + "%'";

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = temp.NewRow();
                linha["id_audA"] = tabela_memoria.Rows[i]["id_audA"].ToString();
                linha["nome1_admin"] = cripto.Decrypt(tabela_memoria.Rows[i]["nome1_admin"].ToString());
                linha["data_audA"] = cripto.Decrypt(tabela_memoria.Rows[i]["data_audA"].ToString());
                linha["hora_audA"] = cripto.Decrypt(tabela_memoria.Rows[i]["hora_audA"].ToString());
                linha["acao_audA"] = cripto.Decrypt(tabela_memoria.Rows[i]["acao_audA"].ToString());
                linha["desc_audA"] = cripto.Decrypt(tabela_memoria.Rows[i]["desc_audA"].ToString());
                temp.Rows.Add(linha);
            }

            TabelaFiltro = temp;
            return TabelaFiltro;
        }
    }
}
