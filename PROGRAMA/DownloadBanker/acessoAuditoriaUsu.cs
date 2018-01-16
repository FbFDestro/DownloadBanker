using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;


namespace DownloadBanker
{
    class acessoAuditoriaUsu
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

            carregar_tabela("insert into auditoriaU values(0,'" + dataCorreta + "','" + hr + "','" + id + "','" + acao + "','" + desc + "');");


        }

        public DataTable Log()
        {
            DataTable temp = new DataTable();

            carregar_tabela("select au.* , u.nome_user from auditoriaU au inner join usuario u on u.id_user=au.id_user;");
            temp.Columns.Add("id_audU", typeof(int));
            temp.Columns.Add("nome_user", typeof(String));
            temp.Columns.Add("acao_audU", typeof(String));
            temp.Columns.Add("desc_audU", typeof(String));
            temp.Columns.Add("data_audU", typeof(String));
            temp.Columns.Add("hora_audU", typeof(String));

           

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = temp.NewRow();
                linha["id_audU"] = tabela_memoria.Rows[i]["id_audU"].ToString();
                linha["nome_user"] = cripto.Decrypt(tabela_memoria.Rows[i]["nome_user"].ToString());
                linha["data_audU"] = cripto.Decrypt(tabela_memoria.Rows[i]["data_audU"].ToString());
                linha["hora_audU"] = cripto.Decrypt(tabela_memoria.Rows[i]["hora_audU"].ToString());
                linha["acao_audU"] = cripto.Decrypt(tabela_memoria.Rows[i]["acao_audU"].ToString());
                linha["desc_audU"] = cripto.Decrypt(tabela_memoria.Rows[i]["desc_audU"].ToString());
                temp.Rows.Add(linha);
            }

            return temp;
        }

        public DataTable pesqUsu(string pesq)
        {
            DataTable temp = new DataTable();

            carregar_tabela("select au.* , u.nome_user from auditoriaU au inner join usuario u on u.id_user=au.id_user;");
            temp.Columns.Add("id_audU", typeof(int));
            temp.Columns.Add("nome_user", typeof(String));
            temp.Columns.Add("acao_audU", typeof(String));
            temp.Columns.Add("desc_audU", typeof(String));
            temp.Columns.Add("data_audU", typeof(String));
            temp.Columns.Add("hora_audU", typeof(String));

            temp.DefaultView.RowFilter = "nome_user like '" + pesq + "%'";

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = temp.NewRow();
                linha["id_audU"] = tabela_memoria.Rows[i]["id_audU"].ToString();
                linha["nome_user"] = cripto.Decrypt(tabela_memoria.Rows[i]["nome_user"].ToString());
                linha["data_audU"] = cripto.Decrypt(tabela_memoria.Rows[i]["data_audU"].ToString());
                linha["hora_audU"] = cripto.Decrypt(tabela_memoria.Rows[i]["hora_audU"].ToString());
                linha["acao_audU"] = cripto.Decrypt(tabela_memoria.Rows[i]["acao_audU"].ToString());
                linha["desc_audU"] = cripto.Decrypt(tabela_memoria.Rows[i]["desc_audU"].ToString());
                temp.Rows.Add(linha);
            }

            tabelaFiltro = temp;
            return tabelaFiltro;
        }

    }
}
