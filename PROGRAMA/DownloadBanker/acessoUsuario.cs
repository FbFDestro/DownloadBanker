using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DownloadBanker
{
    class acessoUsuario
    {
        Criptografia cripto = new Criptografia("ETEP");

        int cod_user;

        #region Variaveis INT

        public int Cod_user
        {
            get { return cod_user; }
            set { cod_user = value; }
        }
        #endregion

        string login_user, pass_user, nome_user, email_user, cpf_user, sexo_user, status_user;


        #region Variaveis STRING

        public string Login_user
        {
            get { return login_user; }
            set { login_user = value; }
        }

        public string Pass_user
        {
            get { return pass_user; }
            set { pass_user = value; }
        }

        public string Nome_user
        {
            get { return nome_user; }
            set { nome_user = value; }
        }

        public string Email_user
        {
            get { return email_user; }
            set { email_user = value; }
        }

        public string Sexo_user
        {
            get { return sexo_user; }
            set { sexo_user = value; }
        }

        public string Status_user
        {
            get { return status_user; }
            set { status_user = value; }
        }

        #endregion


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

        public bool verificarLogin(string loginV)
        {
            carregar_tabela("select * from usuario where login_user='" + loginV + "'");

            if (tabela_memoria.Rows.Count > 0)
            {
                return false;
            }
            else
            {

                return true;
            }
        }

        public DataTable listarTudo()
        {
            // criando uma nova tabela memória para
            // as informações descriptografadas
            DataTable tabelaTemp = new DataTable();

            // criando as colunas da nova tabela memória
            tabelaTemp.Columns.Add("id_user", typeof(int));
            tabelaTemp.Columns.Add("login_user", typeof(String));
            tabelaTemp.Columns.Add("pass_user", typeof(String));
            tabelaTemp.Columns.Add("nome_user", typeof(String));
            tabelaTemp.Columns.Add("email_user", typeof(String));
            tabelaTemp.Columns.Add("cpf_user", typeof(String));
            tabelaTemp.Columns.Add("sexo_user", typeof(String));
            tabelaTemp.Columns.Add("status_user", typeof(String));
            

            // carregando os dados da tabela criptografada
            carregar_tabela("select * from usuario where status_user=1;");

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = tabelaTemp.NewRow();

                linha["id_user"] = tabela_memoria.Rows[i]["id_user"].ToString();
                linha["login_user"] = cripto.Decrypt(tabela_memoria.Rows[i]["login_user"].ToString());
                linha["pass_user"] = cripto.Decrypt(tabela_memoria.Rows[i]["pass_user"].ToString());
                linha["nome_user"] = cripto.Decrypt(tabela_memoria.Rows[i]["nome_user"].ToString());
                linha["email_user"] = cripto.Decrypt(tabela_memoria.Rows[i]["email_user"].ToString());
                linha["cpf_user"] = cripto.Decrypt(tabela_memoria.Rows[i]["cpf_user"].ToString());
                linha["sexo_user"] = cripto.Decrypt(tabela_memoria.Rows[i]["sexo_user"].ToString());
                linha["status_user"] = tabela_memoria.Rows[i]["status_user"].ToString();
                


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
            tabelaTemp.Columns.Add("id_user", typeof(int));
            tabelaTemp.Columns.Add("login_user", typeof(String));
            tabelaTemp.Columns.Add("pass_user", typeof(String));
            tabelaTemp.Columns.Add("nome_user", typeof(String));
            tabelaTemp.Columns.Add("email_user", typeof(String));
            tabelaTemp.Columns.Add("cpf_user", typeof(String));
            tabelaTemp.Columns.Add("sexo_user", typeof(String));
            tabelaTemp.Columns.Add("status_user", typeof(String));


            // carregando os dados da tabela criptografada
            carregar_tabela("select * from usuario where status_user=1;");

            tabelaTemp.DefaultView.RowFilter = "nome_user like '" + Pesq + "%'";

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = tabelaTemp.NewRow();

                linha["id_user"] = tabela_memoria.Rows[i]["id_user"].ToString();
                linha["login_user"] = cripto.Decrypt(tabela_memoria.Rows[i]["login_user"].ToString());
                linha["pass_user"] = cripto.Decrypt(tabela_memoria.Rows[i]["pass_user"].ToString());
                linha["nome_user"] = cripto.Decrypt(tabela_memoria.Rows[i]["nome_user"].ToString());
                linha["email_user"] = cripto.Decrypt(tabela_memoria.Rows[i]["email_user"].ToString());
                linha["cpf_user"] = cripto.Decrypt(tabela_memoria.Rows[i]["cpf_user"].ToString());
                linha["sexo_user"] = cripto.Decrypt(tabela_memoria.Rows[i]["sexo_user"].ToString());
                linha["status_user"] = tabela_memoria.Rows[i]["status_user"].ToString();



                tabelaTemp.Rows.Add(linha);
            }
            tabelaFiltro = tabelaTemp;
            return tabelaFiltro;
        }

        public Boolean pesquisa(String Pesq)
        {
            carregar_tabela("select * from usuario where id_user = '" + Pesq + "'");

            try
            {
                cod_user = Convert.ToInt32(cripto.Decrypt(tabela_memoria.Rows[0]["id_user"].ToString()));
                login_user = cripto.Decrypt(tabela_memoria.Rows[0]["login_user"].ToString());
                pass_user = cripto.Decrypt(tabela_memoria.Rows[0]["pass_user"].ToString());
                nome_user = cripto.Decrypt(tabela_memoria.Rows[0]["nome_user"].ToString());
                email_user = cripto.Decrypt(tabela_memoria.Rows[0]["email_user"].ToString());
                cpf_user = cripto.Decrypt(tabela_memoria.Rows[0]["cpf_user"].ToString());
                sexo_user = cripto.Decrypt(tabela_memoria.Rows[0]["sexo_user"].ToString());
                status_user = cripto.Decrypt(tabela_memoria.Rows[0]["status_user"].ToString());

                return true;
            }
            catch
            {
                return false;
            }
        }

    

        public void desativarUser(string status)
        {
            carregar_tabela("update usuario set status_user=0 where id_user = " + status + ";");
        }
    }
}
