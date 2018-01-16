using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DownloadBanker
{
    class acessoAdmin
    {

        Criptografia cripto = new Criptografia("ETEP");

        int cod_admin;

        #region Variaveis INT

        public int Cod_Admin
        {
            get { return cod_admin; }
            set { cod_admin = value; }
        }

        #endregion

        string login_admin, pass_admin, pass1_admin, pass2_admin, pass3_admin, nome1_admin, nome2_admin, cpf_admin, email_admin, perg_admin, resp_admin, acesso1_admin, status_admin;
        string dataCad, dataRecad;
        

        #region Variaveis STRING
        public string Cpf_admin
        {
            get { return cpf_admin; }
            set { cpf_admin = value; }
        }
        public string Login_admin
        {
            get { return login_admin; }
            set { login_admin = value; }
        }

        public string Pass_admin
        {
            get { return pass_admin; }
            set { pass_admin = value; }
        }

        public string Pass1_admin
        {
            get { return pass1_admin; }
            set { pass1_admin = value; }
        }
        public string Pass2_admin
        {
            get { return pass2_admin; }
            set { pass2_admin = value; }
        }
        public string Pass3_admin
        {
            get { return pass3_admin; }
            set { pass3_admin = value; }
        }

        public string Nome1_admin
        {
            get { return nome1_admin; }
            set { nome1_admin = value; }
        }

        public string Nome2_admin
        {
            get { return nome2_admin; }
            set { nome2_admin = value; }
        }

        public string Email_admin
        {
            get { return email_admin; }
            set { email_admin = value; }
        }

        public string Acesso1_admin
        {
            get { return acesso1_admin; }
            set { acesso1_admin = value; }
        }

        public string Resp_admin
        {
            get { return resp_admin; }
            set { resp_admin = value; }
        }

        public string Perg_admin
        {
            get { return perg_admin; }
            set { perg_admin = value; }
        }




        #endregion

        DateTime dataCad_admin, dataRecad_admin;

        public DateTime DataCad_admin
        {
            get { return dataCad_admin; }
            set { dataCad_admin = value; }
        }

        public DateTime DataRecad_admin
        {
            get { return dataRecad_admin; }
            set { dataRecad_admin = value; }
        }


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

        public bool verificarLogin(string loginV)
        {
            carregar_tabela("select * from administrador where login_admin'" + loginV + "'");

            if (tabela_memoria.Rows.Count > 0)
            {
                return false;
            }
            else
            {

                return true;
            }
        }

        public void cadastrarAdmin(string login, string pass, string pass1, string pass2, string pass3, string nome1, string nome2, string cpf, string email, string perg, string resp, string dataCad, string dataRecad, string acesso1, string status)
        {
            string dataCorretaCad = conversorData(dataCad);
            string dataCorretaRecad = conversorData(dataRecad);

            login = cripto.Encrypt(login);
            pass = cripto.Encrypt(pass);
            pass1 = cripto.Encrypt(pass1);
            pass2 = cripto.Encrypt(pass2);
            pass3 = cripto.Encrypt(pass3);
            nome1 = cripto.Encrypt(nome1);
            nome2 = cripto.Encrypt(nome2);
            cpf = cripto.Encrypt(cpf);
            email = cripto.Encrypt(email);
            perg = cripto.Encrypt(perg);
            resp = cripto.Encrypt(resp);
            dataCad = cripto.Encrypt(dataCorretaCad);
            dataRecad = cripto.Encrypt(dataCorretaRecad);

            carregar_tabela("insert into administrador values (0,'" + login + "','" + pass + "','" + pass1 + "','" + pass2 + "','" + pass3 + "','" + nome1 + "','" + nome2 + "','" + cpf + "','" + email + "','" + perg + "','" + resp + "','" + dataCad + "','" + dataRecad + "','" + acesso1 + "','" + status + "');");
        }

        public DataTable listarAdmin()
        {

            carregar_tabela("select * from administrador where status_admin = 1;");
            return tabela_memoria;

        }

        public Boolean pesquisaNomeFiltro(String Pesq)
        {
            carregar_tabela("select * from administrador where nome1_admin like '" + Pesq + "%'");

            try
            {
                cod_admin = Convert.ToInt32(tabela_memoria.Rows[0]["id_admin"].ToString());
                login_admin = cripto.Decrypt(tabela_memoria.Rows[0]["login_admin"].ToString());
                pass_admin = cripto.Decrypt(tabela_memoria.Rows[0]["pass_admin"].ToString());
                pass1_admin = cripto.Decrypt(tabela_memoria.Rows[0]["pass1_admin"].ToString());
                pass2_admin = cripto.Decrypt(tabela_memoria.Rows[0]["pass2_admin"].ToString());
                pass3_admin = cripto.Decrypt(tabela_memoria.Rows[0]["pass3_admin"].ToString());
                nome1_admin = cripto.Decrypt(tabela_memoria.Rows[0]["nome1_admin"].ToString());
                nome2_admin = cripto.Decrypt(tabela_memoria.Rows[0]["nome2_admin"].ToString());
                cpf_admin = cripto.Decrypt(tabela_memoria.Rows[0]["cpf_admin"].ToString());
                email_admin = cripto.Decrypt(tabela_memoria.Rows[0]["email_admin"].ToString());
                perg_admin = cripto.Decrypt(tabela_memoria.Rows[0]["perg_admin"].ToString());
                resp_admin = cripto.Decrypt(tabela_memoria.Rows[0]["resp_admin"].ToString());
                dataCad_admin = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataCad_admin"].ToString()));
                dataRecad_admin = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataRecad_admin"].ToString()));
                acesso1_admin = (tabela_memoria.Rows[0]["acesso1_admin"].ToString());
                status_admin = (tabela_memoria.Rows[0]["status_admin"].ToString());

                status_admin = cripto.Decrypt(tabela_memoria.Rows[0]["status_admin"].ToString());


                if (tabela_memoria.Rows.Count >= 1)
                {
                    tabelaFiltro = tabela_memoria;
                }
                else
                {
                    tabelaFiltro = null;
                }


                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean pesquisa(String Pesq)
        {
            carregar_tabela("select * from administrador where id_admin = '" + Pesq + "'");

            try
            {
                cod_admin = Convert.ToInt32(tabela_memoria.Rows[0]["id_admin"].ToString());
                login_admin = cripto.Decrypt(tabela_memoria.Rows[0]["login_admin"].ToString());
                pass_admin = cripto.Decrypt(tabela_memoria.Rows[0]["pass_admin"].ToString());
                pass1_admin = cripto.Decrypt(tabela_memoria.Rows[0]["pass1_admin"].ToString());
                pass2_admin = cripto.Decrypt(tabela_memoria.Rows[0]["pass2_admin"].ToString());
                pass3_admin = cripto.Decrypt(tabela_memoria.Rows[0]["pass3_admin"].ToString());
                nome1_admin = cripto.Decrypt(tabela_memoria.Rows[0]["nome1_admin"].ToString());
                nome2_admin = cripto.Decrypt(tabela_memoria.Rows[0]["nome2_admin"].ToString());
                cpf_admin = cripto.Decrypt(tabela_memoria.Rows[0]["cpf_admin"].ToString());
                email_admin = cripto.Decrypt(tabela_memoria.Rows[0]["email_admin"].ToString());
                perg_admin = cripto.Decrypt(tabela_memoria.Rows[0]["perg_admin"].ToString());
                resp_admin = cripto.Decrypt(tabela_memoria.Rows[0]["resp_admin"].ToString());
                dataCad_admin = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataCad_admin"].ToString()));
                dataRecad_admin = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataRecad_admin"].ToString()));
                acesso1_admin = (tabela_memoria.Rows[0]["acesso1_admin"].ToString());
                status_admin = (tabela_memoria.Rows[0]["status_admin"].ToString());

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void alterar(string login, string pass,  string nome1, string nome2, string cpf, string email, string cod)
        {
            login = cripto.Encrypt(login);
            pass = cripto.Encrypt(pass);
            nome1 = cripto.Encrypt(nome1);
            nome2 = cripto.Encrypt(nome2);
            cpf = cripto.Encrypt(cpf);
            email = cripto.Encrypt(email);
  

            carregar_tabela("update administrador set login_admin='" + login + "',pass_admin='" + pass + "',nome1_admin='" + nome1 +
                 "',nome2_admin='" + nome2 + "', cpf_admin='" + cpf + "', email_admin='" + email + "' where id_admin=" + cod + ";");
        }

        

        public Boolean emailPesq(string email)
        {
            email = cripto.Encrypt(email);

            carregar_tabela("select * from administrador where email_admin='" + email + "'");

            if (tabela_memoria.Rows.Count > 0)
            {
                cod_admin = Convert.ToInt32(tabela_memoria.Rows[0]["id_admin"].ToString());
                login_admin = cripto.Decrypt(tabela_memoria.Rows[0]["login_admin"].ToString());
                pass_admin = cripto.Decrypt(tabela_memoria.Rows[0]["pass_admin"].ToString());
                pass1_admin = cripto.Decrypt(tabela_memoria.Rows[0]["pass1_admin"].ToString());
                pass2_admin = cripto.Decrypt(tabela_memoria.Rows[0]["pass2_admin"].ToString());
                pass3_admin = cripto.Decrypt(tabela_memoria.Rows[0]["pass3_admin"].ToString());
                nome1_admin = cripto.Decrypt(tabela_memoria.Rows[0]["nome1_admin"].ToString());
                nome2_admin = cripto.Decrypt(tabela_memoria.Rows[0]["nome2_admin"].ToString());
                cpf_admin = cripto.Decrypt(tabela_memoria.Rows[0]["cpf_admin"].ToString());
                email_admin = cripto.Decrypt(tabela_memoria.Rows[0]["email_admin"].ToString());
                perg_admin = cripto.Decrypt(tabela_memoria.Rows[0]["perg_admin"].ToString());
                resp_admin = cripto.Decrypt(tabela_memoria.Rows[0]["resp_admin"].ToString());
                dataCad_admin = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataCad_admin"].ToString()));
                dataRecad_admin = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataRecad_admin"].ToString()));
                acesso1_admin = (tabela_memoria.Rows[0]["acesso1_admin"].ToString());
                status_admin = (tabela_memoria.Rows[0]["status_admin"].ToString());
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean cpfPesq(string cpf)
        {
            cpf = cripto.Encrypt(cpf);

            carregar_tabela("select * from administrador where cpf_admin='" + cpf + "'");

            if (tabela_memoria.Rows.Count > 0)
            {
                cod_admin = Convert.ToInt32(tabela_memoria.Rows[0]["id_admin"].ToString());
                login_admin = cripto.Decrypt(tabela_memoria.Rows[0]["login_admin"].ToString());
                pass_admin = cripto.Decrypt(tabela_memoria.Rows[0]["pass_admin"].ToString());
                pass1_admin = cripto.Decrypt(tabela_memoria.Rows[0]["pass1_admin"].ToString());
                pass2_admin = cripto.Decrypt(tabela_memoria.Rows[0]["pass2_admin"].ToString());
                pass3_admin = cripto.Decrypt(tabela_memoria.Rows[0]["pass3_admin"].ToString());
                nome1_admin = cripto.Decrypt(tabela_memoria.Rows[0]["nome1_admin"].ToString());
                nome2_admin = cripto.Decrypt(tabela_memoria.Rows[0]["nome2_admin"].ToString());
                cpf_admin = cripto.Decrypt(tabela_memoria.Rows[0]["cpf_admin"].ToString());
                email_admin = cripto.Decrypt(tabela_memoria.Rows[0]["email_admin"].ToString());
                perg_admin = cripto.Decrypt(tabela_memoria.Rows[0]["perg_admin"].ToString());
                resp_admin = cripto.Decrypt(tabela_memoria.Rows[0]["resp_admin"].ToString());
                dataCad_admin = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataCad_admin"].ToString()));
                dataRecad_admin = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataRecad_admin"].ToString()));
                acesso1_admin = (tabela_memoria.Rows[0]["acesso1_admin"].ToString());
                status_admin = (tabela_memoria.Rows[0]["status_admin"].ToString());
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean esqueceu(string email, string cpf)
        {
            carregar_tabela("select * from administrador where status_admin=1 and email_admin = '" + cripto.Encrypt(email) + "' and cpf_admin = '" + cripto.Encrypt(cpf) + "'");

            if (tabela_memoria.Rows.Count > 0)
            {
                Nome1_admin = cripto.Decrypt(tabela_memoria.Rows[0]["nome1_admin"].ToString());
                Login_admin = cripto.Decrypt(tabela_memoria.Rows[0]["login_admin"].ToString());
                Pass_admin = cripto.Decrypt(tabela_memoria.Rows[0]["pass_admin"].ToString());
                return true;
            }
            else
            {
                return false;
            }
        }

        public void mudarSenha(string novasenha, string novasenha1, string novasenha2, string novasenha3, string novaData, string novaRedata, string cod)
        {
            string dataCorreta = conversorData(novaData);
            string dataCorreta1 = conversorData(novaRedata);

            novasenha = cripto.Encrypt(novasenha);
            novasenha1 = cripto.Encrypt(novasenha1);
            novasenha2 = cripto.Encrypt(novasenha2);
            novasenha3 = cripto.Encrypt(novasenha3);
            dataCorreta = cripto.Encrypt(dataCorreta);
            dataCorreta1 = cripto.Encrypt(dataCorreta1);

            carregar_tabela("update administrador set pass_admin = '" + novasenha + "',pass1_admin = '" + novasenha1 + "',pass2_admin = '" + novasenha2 + "',pass3_admin = '" + novasenha3 + "',dataCad_admin = '" + dataCorreta + "',dataRecad_admin = '" + dataCorreta1 + "',acesso1_admin = 1  where id_admin = '" + cod + "'");
        }

        public Boolean checa6meses(string codAdmin)
        {
            DateTime datacad, datarecad;

            carregar_tabela("select * from administrador where id_admin = '" + codAdmin + "'");

            if (tabela_memoria.Rows.Count > 0)
            {
                datacad = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataCad_admin"].ToString()));
                datarecad = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataRecad_admin"].ToString()));

                if (datacad.CompareTo(datarecad) >= 0)
                {
                    return true;
                }
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        public Boolean FirstTime(string ft)
        {
            carregar_tabela("select * from administrador where acesso1_admin= 0 and id_admin = '" + ft + "'");

            if (tabela_memoria.Rows.Count > 0)
            {
                cod_admin = Convert.ToInt32((tabela_memoria.Rows[0]["id_admin"].ToString()));
                login_admin = cripto.Decrypt(tabela_memoria.Rows[0]["login_admin"].ToString());
                pass_admin = cripto.Decrypt(tabela_memoria.Rows[0]["pass_admin"].ToString());
                pass1_admin = cripto.Decrypt(tabela_memoria.Rows[0]["pass1_admin"].ToString());
                pass2_admin = cripto.Decrypt(tabela_memoria.Rows[0]["pass2_admin"].ToString());
                pass3_admin = cripto.Decrypt(tabela_memoria.Rows[0]["pass3_admin"].ToString());
                nome1_admin = cripto.Decrypt(tabela_memoria.Rows[0]["nome1_admin"].ToString());
                nome2_admin = cripto.Decrypt(tabela_memoria.Rows[0]["nome2_admin"].ToString());
                cpf_admin = cripto.Decrypt(tabela_memoria.Rows[0]["cpf_admin"].ToString());  
                email_admin = cripto.Decrypt(tabela_memoria.Rows[0]["email_admin"].ToString());
                perg_admin = cripto.Decrypt(tabela_memoria.Rows[0]["perg_admin"].ToString());
                resp_admin = cripto.Decrypt(tabela_memoria.Rows[0]["resp_admin"].ToString());
                //dataCad_admin = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataCad_admin"].ToString()));
                //dataCad_admin = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataRecad_admin"].ToString()));          
                acesso1_admin = (tabela_memoria.Rows[0]["acesso1_admin"].ToString());                
                status_admin = (tabela_memoria.Rows[0]["status_admin"].ToString());
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean PergRespPesq(string perg, string resp, string cod)
        {
            perg = cripto.Encrypt(perg);
            resp = cripto.Encrypt(resp);

            carregar_tabela("select * from administrador where perg_admin='" + perg + "' and resp_admin='" + resp  + "' and id_admin = '" + cod + "'");

            if (tabela_memoria.Rows.Count > 0)
            {
                cod_admin = Convert.ToInt32(tabela_memoria.Rows[0]["id_admin"].ToString());
                login_admin = cripto.Decrypt(tabela_memoria.Rows[0]["login_admin"].ToString());
                pass_admin = cripto.Decrypt(tabela_memoria.Rows[0]["pass_admin"].ToString());
                pass1_admin = cripto.Decrypt(tabela_memoria.Rows[0]["pass1_admin"].ToString());
                pass2_admin = cripto.Decrypt(tabela_memoria.Rows[0]["pass2_admin"].ToString());
                pass3_admin = cripto.Decrypt(tabela_memoria.Rows[0]["pass3_admin"].ToString());
                nome1_admin = cripto.Decrypt(tabela_memoria.Rows[0]["nome1_admin"].ToString());
                nome2_admin = cripto.Decrypt(tabela_memoria.Rows[0]["nome2_admin"].ToString());
                cpf_admin = cripto.Decrypt(tabela_memoria.Rows[0]["cpf_admin"].ToString());
                email_admin = cripto.Decrypt(tabela_memoria.Rows[0]["email_admin"].ToString());
                perg_admin = cripto.Decrypt(tabela_memoria.Rows[0]["perg_admin"].ToString());
                resp_admin = cripto.Decrypt(tabela_memoria.Rows[0]["resp_admin"].ToString());
                dataCad_admin = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataCad_admin"].ToString()));
                dataRecad_admin = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataRecad_admin"].ToString()));
                acesso1_admin = (tabela_memoria.Rows[0]["acesso1_admin"].ToString());
                status_admin = (tabela_memoria.Rows[0]["status_admin"].ToString());
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
