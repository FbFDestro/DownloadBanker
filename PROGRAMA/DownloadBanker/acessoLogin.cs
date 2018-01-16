using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DownloadBanker
{
    class acessoLogin
    {
        Criptografia cripto = new Criptografia("ETEP");

        int cod_admin;
        string nome1_admin, nome2_admin, login_admin, senha_admin;

        int cod_func;
        string nome1_func, nome2_func, login_func, senha_func;

        #region Variaveis Funcionario
        public int Cod_func
        {
            get { return cod_func; }
            set { cod_func = value; }
        }
        public string Senha_func
        {
            get { return senha_func; }
            set { senha_func = value; }
        }

        public string Login_func
        {
            get { return login_func; }
            set { login_func = value; }
        }

        public string Nome1_func
        {
            get { return nome1_func; }
            set { nome1_func = value; }
        }
        #endregion
        #region Variaveis ADMIN
        public int Cod_admin
        {
            get { return cod_admin; }
            set { cod_admin = value; }
        }
        public string Senha_admin
        {
            get { return senha_admin; }
            set { senha_admin = value; }
        }

        public string Login_admin
        {
            get { return login_admin; }
            set { login_admin = value; }
        }

        public string Nome1_admin
        {
            get { return nome1_admin; }
            set { nome1_admin = value; }
        }

        #endregion


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


        public bool loginAdmin(string login, string senha)
        {

            carregar_tabela("select * from administrador where login_admin='" + login + "'");

            try
            {

                cod_admin = Convert.ToInt32(tabela_memoria.Rows[0]["id_admin"].ToString());
                nome1_admin = cripto.Decrypt(tabela_memoria.Rows[0]["nome1_admin"].ToString());
                login_admin = cripto.Decrypt(tabela_memoria.Rows[0]["login_admin"].ToString());
                senha_admin = cripto.Decrypt(tabela_memoria.Rows[0]["pass_admin"].ToString());

                //cod_admin = Convert.ToInt32((tabela_memoria.Rows[0]["id_admin"].ToString()));
                //nome_admin = (tabela_memoria.Rows[0]["nome_admin"].ToString());
                //login_admin = (tabela_memoria.Rows[0]["login_admin"].ToString());
                //senha_admin = (tabela_memoria.Rows[0]["pass_admin"].ToString());

                return true;

            }
            catch
            {
                return false;
            }

        }

        public bool loginFuncionario(string login, string senha)
        {
            carregar_tabela("select * from funcionario where status_func=1 and login_func='" + login + "'");

            try
            {

                cod_func = Convert.ToInt32(tabela_memoria.Rows[0]["id_func"].ToString());
                nome1_func = cripto.Decrypt(tabela_memoria.Rows[0]["nome1_func"].ToString());
                login_func = cripto.Decrypt(tabela_memoria.Rows[0]["login_func"].ToString());
                senha_func = cripto.Decrypt(tabela_memoria.Rows[0]["pass_func"].ToString());

                return true;

            }
            catch
            {
                return false;
            }


        }
    }
}
