using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DownloadBanker
{
    class acessoFunc
    {
        Criptografia cripto = new Criptografia("ETEP");

        int cod_func;

        #region Variaveis INT

        public int Cod_func
        {
            get { return cod_func; }
            set { cod_func = value; }
        }

        #endregion

        string login_func, pass_func, pass1_func, pass2_func, pass3_func, nome1_func, nome2_func, tel_func, email_func, cpf_func, sexo_func, cep_func,
            bairro_func, logradouro_func, numero_func, complemento_func, perg_func, resp_func, acesso1_func, status_func;

        #region Variaveis STRING

        public string Login_func
        {
            get { return login_func; }
            set { login_func = value; }
        }

        public string Pass_func
        {
            get { return pass_func; }
            set { pass_func = value; }
        }

        public string Nome1_func
        {
            get { return nome1_func; }
            set { nome1_func = value; }
        }

        public string Nome2_func
        {
            get { return nome2_func; }
            set { nome2_func = value; }
        }

        public string Tel_func
        {
            get { return tel_func; }
            set { tel_func = value; }
        }

        public string Email_func
        {
            get { return email_func; }
            set { email_func = value; }
        }

        public string Cpf_func
        {
            get { return cpf_func; }
            set { cpf_func = value; }
        }

        public string Sexo_func
        {
            get { return sexo_func; }
            set { sexo_func = value; }
        }

        public string Cep_func
        {
            get { return cep_func; }
            set { cep_func = value; }
        }

        public string Bairro_func
        {
            get { return bairro_func; }
            set { bairro_func = value; }
        }

        public string Logradouro_func
        {
            get { return logradouro_func; }
            set { logradouro_func = value; }
        }

        public string Numero_func
        {
            get { return numero_func; }
            set { numero_func = value; }
        }

        public string Complemento_func
        {
            get { return complemento_func; }
            set { complemento_func = value; }
        }

        public string Acesso1_func
        {
            get { return acesso1_func; }
            set { acesso1_func = value; }
        }

        public string Resp_func
        {
            get { return resp_func; }
            set { resp_func = value; }
        }

        public string Perg_func
        {
            get { return perg_func; }
            set { perg_func = value; }
        }

        public string Pass3_func
        {
            get { return pass3_func; }
            set { pass3_func = value; }
        }

        public string Pass2_func
        {
            get { return pass2_func; }
            set { pass2_func = value; }
        }

        public string Pass1_func
        {
            get { return pass1_func; }
            set { pass1_func = value; }
        }

        #endregion

        double sal_func;

        #region Variaveis DOUBLE

        public double Sal_func
        {
            get { return sal_func; }
            set { sal_func = value; }
        }

        #endregion

        DateTime dataNasc_func, dataCad_func, dataRecad_func;

        public DateTime DataNasc_func
        {
            get { return dataNasc_func; }
            set { dataNasc_func = value; }
        }

        public DateTime DataCad_func
        {
            get { return dataCad_func; }
            set { dataCad_func = value; }
        }

        public DateTime DataRecad_func
        {
            get { return dataRecad_func; }
            set { dataRecad_func = value; }
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
            carregar_tabela("select * from funcionario where login_func='" + loginV + "'");

            if (tabela_memoria.Rows.Count > 0)
            {
                return false;
            }
            else
            {

                return true;
            }
        }

        public void cadastrarFunc(string login, string pass, string pass1, string pass2, string pass3, string nome1, string nome2, string dataNasc, string dataCad, string dataRecad, string tel, string email, string cpf, string sexo, string cep,
                string bairro, string logradouro, string numero, string complemento, string salario, string perg, string resp, string acesso1, string status)
        {
            string dataCorretaNasc = conversorData(dataNasc);
            string dataCorretaCad = conversorData(dataCad);
            string dataCorretaRecad = conversorData(dataRecad);

            login = cripto.Encrypt(login);
            pass = cripto.Encrypt(pass);
            pass1 = cripto.Encrypt(pass1);
            pass2 = cripto.Encrypt(pass2);
            pass3 = cripto.Encrypt(pass3);
            nome1 = cripto.Encrypt(nome1);
            nome2 = cripto.Encrypt(nome2);
            dataCorretaNasc = cripto.Encrypt(dataCorretaNasc);
            dataCorretaCad = cripto.Encrypt(dataCorretaCad);
            dataCorretaRecad = cripto.Encrypt(dataCorretaRecad);
            tel = cripto.Encrypt(tel);
            email = cripto.Encrypt(email);
            cpf = cripto.Encrypt(cpf);
            sexo = cripto.Encrypt(sexo);
            cep = cripto.Encrypt(cep);
            bairro = cripto.Encrypt(bairro);
            logradouro = cripto.Encrypt(logradouro);
            numero = cripto.Encrypt(numero);
            complemento = cripto.Encrypt(complemento);
            perg = cripto.Encrypt(perg);
            resp = cripto.Encrypt(resp);
            salario = cripto.Encrypt(salario);




            carregar_tabela("insert into funcionario values (0,'" + login + "','" + pass + "','" + pass1 + "','" + pass2 + "','" + pass3 + "','" + nome1 + "','" + nome2 + "','" + dataCorretaNasc + "','" + dataCorretaCad + "','" + dataCorretaRecad + "','" + tel + "','" + email + "','" + cpf + "','" + sexo + "','" + cep +
                      "','" + bairro + "','" + logradouro + "','" + numero + "','" + complemento + "','" + salario + "','" + perg + "','" + resp + "','" + acesso1 + "','" + status + "');");
        }

        public DataTable listarFunc()
        {

            DataTable tabelaTemp = new DataTable();

            tabelaTemp.Columns.Add("id_func", typeof(int));
            tabelaTemp.Columns.Add("login_func", typeof(String));
            tabelaTemp.Columns.Add("pass_func", typeof(String));
            tabelaTemp.Columns.Add("pass1_func", typeof(String));
            tabelaTemp.Columns.Add("pass2_func", typeof(String));
            tabelaTemp.Columns.Add("pass3_func", typeof(String));
            tabelaTemp.Columns.Add("nome1_func", typeof(String));
            tabelaTemp.Columns.Add("nome2_func", typeof(String));
            tabelaTemp.Columns.Add("dataNasc_func", typeof(DateTime));
            tabelaTemp.Columns.Add("dataCad_func", typeof(DateTime));
            tabelaTemp.Columns.Add("dataRecad_func", typeof(DateTime));
            tabelaTemp.Columns.Add("tel_func", typeof(String));
            tabelaTemp.Columns.Add("email_func", typeof(String));
            tabelaTemp.Columns.Add("cpf_func", typeof(String));
            tabelaTemp.Columns.Add("sexo_func", typeof(String));
            tabelaTemp.Columns.Add("cep_func", typeof(String));
            tabelaTemp.Columns.Add("bairro_func", typeof(String));
            tabelaTemp.Columns.Add("logradouro_func", typeof(String));
            tabelaTemp.Columns.Add("numero_func", typeof(String));
            tabelaTemp.Columns.Add("complemento_func", typeof(String));
            tabelaTemp.Columns.Add("sal_func", typeof(double));
            tabelaTemp.Columns.Add("perg_func", typeof(String));
            tabelaTemp.Columns.Add("resp_func", typeof(String));
            tabelaTemp.Columns.Add("acesso1_func", typeof(String));
            tabelaTemp.Columns.Add("status_func", typeof(int));

            carregar_tabela("select * from funcionario where status_func=1;");

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = tabelaTemp.NewRow();

                linha["id_func"] = tabela_memoria.Rows[i]["id_func"].ToString();
                linha["login_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["login_func"].ToString());
                linha["pass_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["pass_func"].ToString());
                linha["pass1_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["pass1_func"].ToString());
                linha["pass2_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["pass2_func"].ToString());
                linha["pass3_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["pass3_func"].ToString());
                linha["nome1_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["nome1_func"].ToString());
                linha["nome2_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["nome2_func"].ToString());
                linha["dataNasc_func"] = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[i]["dataNasc_func"].ToString()));
                linha["dataCad_func"] = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[i]["dataCad_func"].ToString()));
                linha["dataRecad_func"] = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[i]["dataRecad_func"].ToString()));
                linha["tel_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["tel_func"].ToString());
                linha["email_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["email_func"].ToString());
                linha["cpf_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["cpf_func"].ToString());
                linha["sexo_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["sexo_func"].ToString());
                linha["cep_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["cep_func"].ToString());
                linha["bairro_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["bairro_func"].ToString());
                linha["logradouro_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["logradouro_func"].ToString());
                linha["numero_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["numero_func"].ToString());
                linha["complemento_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["complemento_func"].ToString());
                linha["sal_func"] = Convert.ToDouble(cripto.Decrypt(tabela_memoria.Rows[i]["sal_func"].ToString()));
                linha["perg_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["perg_func"].ToString());
                linha["resp_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["resp_func"].ToString());
                linha["acesso1_func"] = tabela_memoria.Rows[i]["acesso1_func"].ToString();
                linha["status_func"] = tabela_memoria.Rows[i]["status_func"].ToString();

                tabelaTemp.Rows.Add(linha);
            }
            return tabelaTemp;

        }

        public DataTable pesq(string query)
        {
            DataTable temp = new DataTable();

            temp.Columns.Add("id_func", typeof(int));
            temp.Columns.Add("login_func", typeof(String));
            temp.Columns.Add("pass_func", typeof(String));
            temp.Columns.Add("pass1_func", typeof(String));
            temp.Columns.Add("pass2_func", typeof(String));
            temp.Columns.Add("pass3_func", typeof(String));
            temp.Columns.Add("nome1_func", typeof(String));
            temp.Columns.Add("nome2_func", typeof(String));
            temp.Columns.Add("tel_func", typeof(String));
            temp.Columns.Add("dataNasc_func", typeof(DateTime));
            temp.Columns.Add("dataCad_func", typeof(DateTime));
            temp.Columns.Add("dataRecad_func", typeof(DateTime));
            temp.Columns.Add("email_func", typeof(String));
            temp.Columns.Add("cpf_func", typeof(String));
            temp.Columns.Add("sexo_func", typeof(String));
            temp.Columns.Add("cep_func", typeof(String));
            temp.Columns.Add("bairro_func", typeof(String));
            temp.Columns.Add("logradouro_func", typeof(String));
            temp.Columns.Add("numero_func", typeof(String));
            temp.Columns.Add("complemento_func", typeof(String));
            temp.Columns.Add("sal_func", typeof(Double));
            temp.Columns.Add("perg_func", typeof(String));
            temp.Columns.Add("resp_func", typeof(String));
            temp.Columns.Add("acesso1_func", typeof(String));
            temp.Columns.Add("status_func", typeof(int));

            carregar_tabela("select * from funcionario where status_func=1;");

            temp.DefaultView.RowFilter = "nome1_func like '" + query + "%'";

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = temp.NewRow();
                linha["id_func"] = tabela_memoria.Rows[i]["id_func"].ToString();
                linha["login_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["login_func"].ToString());
                linha["pass_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["pass_func"].ToString());
                linha["pass1_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["pass1_func"].ToString());
                linha["pass2_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["pass2_func"].ToString());
                linha["pass3_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["pass3_func"].ToString());
                linha["nome1_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["nome1_func"].ToString());
                linha["nome2_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["nome2_func"].ToString());
                linha["dataNasc_func"] = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[i]["dataNasc_func"].ToString()));
                linha["dataCad_func"] = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[i]["dataCad_func"].ToString()));
                linha["dataRecad_func"] = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[i]["dataRecad_func"].ToString()));
                linha["tel_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["tel_func"].ToString());
                linha["email_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["email_func"].ToString());
                linha["cpf_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["cpf_func"].ToString());
                linha["sexo_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["sexo_func"].ToString());
                linha["cep_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["cep_func"].ToString());
                linha["bairro_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["bairro_func"].ToString());
                linha["logradouro_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["logradouro_func"].ToString());
                linha["numero_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["numero_func"].ToString());
                linha["complemento_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["complemento_func"].ToString());
                linha["sal_func"] = Convert.ToDouble(cripto.Decrypt(tabela_memoria.Rows[i]["sal_func"].ToString()));
                linha["perg_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["perg_func"].ToString());
                linha["resp_func"] = cripto.Decrypt(tabela_memoria.Rows[i]["resp_func"].ToString());
                linha["acesso1_func"] = tabela_memoria.Rows[i]["acesso1_func"].ToString();
                linha["status_func"] = tabela_memoria.Rows[i]["status_func"].ToString();
                temp.Rows.Add(linha);
            }

            tabelaFiltro = temp;
            return tabelaFiltro;
        }

        //public Boolean pesquisaNomeFiltro(String Pesq)
        //{
        //    carregar_tabela("select * from funcionario where nome1_func like '" + Pesq + "%'");

        //    try
        //    {
        //cod_func = Convert.ToInt32((tabela_memoria.Rows[0]["id_func"].ToString()));
        //        login_func = cripto.Decrypt(tabela_memoria.Rows[0]["login_func"].ToString());
        //        pass_func = cripto.Decrypt(tabela_memoria.Rows[0]["pass_func"].ToString());
        //        pass1_func = cripto.Decrypt(tabela_memoria.Rows[0]["pass1_func"].ToString());
        //        pass2_func = cripto.Decrypt(tabela_memoria.Rows[0]["pass2_func"].ToString());
        //        pass3_func = cripto.Decrypt(tabela_memoria.Rows[0]["pass3_func"].ToString());
        //        nome1_func = cripto.Decrypt(tabela_memoria.Rows[0]["nome1_func"].ToString());
        //        nome2_func = cripto.Decrypt(tabela_memoria.Rows[0]["nome2_func"].ToString());
        //        DataNasc_func = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataNasc_func"].ToString()));
        //        DataCad_func = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataCad_func"].ToString()));
        //        DataRecad_func = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataRecad_func"].ToString()));
        //        tel_func = cripto.Decrypt(tabela_memoria.Rows[0]["tel_func"].ToString());
        //        email_func = cripto.Decrypt(tabela_memoria.Rows[0]["email_func"].ToString());
        //        cpf_func = cripto.Decrypt(tabela_memoria.Rows[0]["cpf_func"].ToString());
        //        sexo_func = cripto.Decrypt(tabela_memoria.Rows[0]["sexo_func"].ToString());
        //        cep_func = cripto.Decrypt(tabela_memoria.Rows[0]["cep_func"].ToString());
        //        bairro_func = cripto.Decrypt(tabela_memoria.Rows[0]["bairro_func"].ToString());
        //        logradouro_func = cripto.Decrypt(tabela_memoria.Rows[0]["logradouro_func"].ToString());
        //        numero_func = cripto.Decrypt(tabela_memoria.Rows[0]["numero_func"].ToString());
        //        complemento_func = cripto.Decrypt(tabela_memoria.Rows[0]["complemento_func"].ToString());
        //        perg_func = cripto.Decrypt(tabela_memoria.Rows[0]["perg_func"].ToString());
        //        resp_func = cripto.Decrypt(tabela_memoria.Rows[0]["resp_func"].ToString());
        //        acesso1_func = cripto.Decrypt(tabela_memoria.Rows[0]["acesso1_func"].ToString());
        //        sal_func = Convert.ToDouble(cripto.Decrypt(tabela_memoria.Rows[0]["sal_func"].ToString()));
        //        status_func = (tabela_memoria.Rows[0]["status_func"].ToString());


        //        if (tabela_memoria.Rows.Count >= 1)
        //        {
        //            tabelaFiltro = tabela_memoria;
        //        }
        //        else
        //        {
        //            tabelaFiltro = null;
        //        }


        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public Boolean pesquisa(String Pesq)
        {
            carregar_tabela("select * from funcionario where id_func = '" + Pesq + "'");

            try
            {
                cod_func = Convert.ToInt32((tabela_memoria.Rows[0]["id_func"].ToString()));
                login_func = cripto.Decrypt(tabela_memoria.Rows[0]["login_func"].ToString());
                pass_func = cripto.Decrypt(tabela_memoria.Rows[0]["pass_func"].ToString());
                pass1_func = cripto.Decrypt(tabela_memoria.Rows[0]["pass1_func"].ToString());
                pass2_func = cripto.Decrypt(tabela_memoria.Rows[0]["pass2_func"].ToString());
                pass3_func = cripto.Decrypt(tabela_memoria.Rows[0]["pass3_func"].ToString());
                nome1_func = cripto.Decrypt(tabela_memoria.Rows[0]["nome1_func"].ToString());
                nome2_func = cripto.Decrypt(tabela_memoria.Rows[0]["nome2_func"].ToString());
                DataNasc_func = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataNasc_func"].ToString()));
                DataCad_func = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataCad_func"].ToString()));
                DataRecad_func = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataRecad_func"].ToString()));
                tel_func = cripto.Decrypt(tabela_memoria.Rows[0]["tel_func"].ToString());
                email_func = cripto.Decrypt(tabela_memoria.Rows[0]["email_func"].ToString());
                cpf_func = cripto.Decrypt(tabela_memoria.Rows[0]["cpf_func"].ToString());
                sexo_func = cripto.Decrypt(tabela_memoria.Rows[0]["sexo_func"].ToString());
                cep_func = cripto.Decrypt(tabela_memoria.Rows[0]["cep_func"].ToString());
                bairro_func = cripto.Decrypt(tabela_memoria.Rows[0]["bairro_func"].ToString());
                logradouro_func = cripto.Decrypt(tabela_memoria.Rows[0]["logradouro_func"].ToString());
                numero_func = cripto.Decrypt(tabela_memoria.Rows[0]["numero_func"].ToString());
                complemento_func = cripto.Decrypt(tabela_memoria.Rows[0]["complemento_func"].ToString());
                perg_func = cripto.Decrypt(tabela_memoria.Rows[0]["perg_func"].ToString());
                resp_func = cripto.Decrypt(tabela_memoria.Rows[0]["resp_func"].ToString());
                acesso1_func = (tabela_memoria.Rows[0]["acesso1_func"].ToString());
                sal_func = Convert.ToDouble(cripto.Decrypt(tabela_memoria.Rows[0]["sal_func"].ToString()));
                status_func = (tabela_memoria.Rows[0]["status_func"].ToString());


                return true;
            }
            catch
            {
                return false;
            }
        }

        public void alterar(string login, string pass, string nome1, string nome2, string dataNasc,  string tel, string email, string cpf, string sexo, string cep, string bairro, string logradouro, string numero, string complemento, string cod)
        {
            login = cripto.Encrypt(login);
            pass = cripto.Encrypt(pass);
            nome1 = cripto.Encrypt(nome1);
            nome2 = cripto.Encrypt(nome2);
            dataNasc = cripto.Encrypt(dataNasc);
            tel = cripto.Encrypt(tel);
            email = cripto.Encrypt(email);
            cpf = cripto.Encrypt(cpf);
            sexo = cripto.Encrypt(sexo);
            cep = cripto.Encrypt(cep);
            bairro = cripto.Encrypt(bairro);
            logradouro = cripto.Encrypt(logradouro);
            numero = cripto.Encrypt(numero);
            complemento = cripto.Encrypt(complemento);
         


            carregar_tabela("update funcionario set login_func='"+ login +"',pass_func='" + pass +  "',nome1_func='" + nome1 + "',nome2_func='" + nome2 + "',dataNasc_func='" + dataNasc +  "',tel_func='" + tel +
                "', email_func='" + email + "', cpf_func='" + cpf + "',sexo_func='" + sexo + "',cep_func='" + cep +
                 "', bairro_func='" + bairro + "',logradouro_func='" + logradouro + "',numero_func='" + numero +
                 "',complemento_func='" + complemento + "' where id_func=" + cod + ";");
        }

        public void desativarFunc(string status)
        {
            carregar_tabela("update funcionario set status_func=0 where id_func = " + status + ";");
        }

        public void alterarSFunc(string novosal, string codfunc)
        {
            novosal = cripto.Encrypt(novosal);

            carregar_tabela("update funcionario set sal_func= '" + novosal + "' where id_func = " + codfunc + ";");
        }

        public Boolean emailPesq(string email)
        {
            email = cripto.Encrypt(email);

            carregar_tabela("select * from funcionario where status_func=1 and email_func='" + email + "'");

            if (tabela_memoria.Rows.Count > 0)
            {
                cod_func = Convert.ToInt32(tabela_memoria.Rows[0]["id_func"].ToString());
                login_func = cripto.Decrypt(tabela_memoria.Rows[0]["login_func"].ToString());
                pass_func = cripto.Decrypt(tabela_memoria.Rows[0]["pass_func"].ToString());
                pass1_func = cripto.Decrypt(tabela_memoria.Rows[0]["pass1_func"].ToString());
                pass2_func = cripto.Decrypt(tabela_memoria.Rows[0]["pass2_func"].ToString());
                pass3_func = cripto.Decrypt(tabela_memoria.Rows[0]["pass3_func"].ToString());
                nome1_func = cripto.Decrypt(tabela_memoria.Rows[0]["nome1_func"].ToString());
                nome2_func = cripto.Decrypt(tabela_memoria.Rows[0]["nome2_func"].ToString());
                
                DataNasc_func = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataNasc_func"].ToString()));
                DataCad_func = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataCad_func"].ToString()));
                DataRecad_func = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataRecad_func"].ToString()));
                tel_func = cripto.Decrypt(tabela_memoria.Rows[0]["tel_func"].ToString());
                email_func = cripto.Decrypt(tabela_memoria.Rows[0]["email_func"].ToString());
                cpf_func = cripto.Decrypt(tabela_memoria.Rows[0]["cpf_func"].ToString());
                sexo_func = cripto.Decrypt(tabela_memoria.Rows[0]["sexo_func"].ToString());
                cep_func = cripto.Decrypt(tabela_memoria.Rows[0]["cep_func"].ToString());
                bairro_func = cripto.Decrypt(tabela_memoria.Rows[0]["bairro_func"].ToString());
                logradouro_func = cripto.Decrypt(tabela_memoria.Rows[0]["logradouro_func"].ToString());
                numero_func = cripto.Decrypt(tabela_memoria.Rows[0]["numero_func"].ToString());
                complemento_func = cripto.Decrypt(tabela_memoria.Rows[0]["complemento_func"].ToString());
                perg_func = cripto.Decrypt(tabela_memoria.Rows[0]["perg_func"].ToString());
                resp_func = cripto.Decrypt(tabela_memoria.Rows[0]["resp_func"].ToString());
                acesso1_func = (tabela_memoria.Rows[0]["acesso1_func"].ToString());
                sal_func = Convert.ToDouble(cripto.Decrypt(tabela_memoria.Rows[0]["sal_func"].ToString()));
                status_func = (tabela_memoria.Rows[0]["status_func"].ToString());
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean cpf_pesq(string cpfpesq)
        {
            cpfpesq = cripto.Encrypt(cpfpesq);

            carregar_tabela("select * from funcionario where cpf_func='" + cpfpesq + "'");

            if (tabela_memoria.Rows.Count > 0)
            {
                cod_func = Convert.ToInt32(tabela_memoria.Rows[0]["id_func"].ToString());
                login_func = cripto.Decrypt(tabela_memoria.Rows[0]["login_func"].ToString());
                pass_func = cripto.Decrypt(tabela_memoria.Rows[0]["pass_func"].ToString());
                pass1_func = cripto.Decrypt(tabela_memoria.Rows[0]["pass1_func"].ToString());
                pass2_func = cripto.Decrypt(tabela_memoria.Rows[0]["pass2_func"].ToString());
                pass3_func = cripto.Decrypt(tabela_memoria.Rows[0]["pass3_func"].ToString());
                nome1_func = cripto.Decrypt(tabela_memoria.Rows[0]["nome1_func"].ToString());
                nome2_func = cripto.Decrypt(tabela_memoria.Rows[0]["nome2_func"].ToString());
                
                DataNasc_func = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataNasc_func"].ToString()));
                DataCad_func = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataCad_func"].ToString()));
                DataRecad_func = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataRecad_func"].ToString()));
                tel_func = cripto.Decrypt(tabela_memoria.Rows[0]["tel_func"].ToString());
                email_func = cripto.Decrypt(tabela_memoria.Rows[0]["email_func"].ToString());
                cpf_func = cripto.Decrypt(tabela_memoria.Rows[0]["cpf_func"].ToString());
                sexo_func = cripto.Decrypt(tabela_memoria.Rows[0]["sexo_func"].ToString());
                cep_func = cripto.Decrypt(tabela_memoria.Rows[0]["cep_func"].ToString());
                bairro_func = cripto.Decrypt(tabela_memoria.Rows[0]["bairro_func"].ToString());
                logradouro_func = cripto.Decrypt(tabela_memoria.Rows[0]["logradouro_func"].ToString());
                numero_func = cripto.Decrypt(tabela_memoria.Rows[0]["numero_func"].ToString());
                complemento_func = cripto.Decrypt(tabela_memoria.Rows[0]["complemento_func"].ToString());
                perg_func = cripto.Decrypt(tabela_memoria.Rows[0]["perg_func"].ToString());
                resp_func = cripto.Decrypt(tabela_memoria.Rows[0]["resp_func"].ToString());
                acesso1_func = (tabela_memoria.Rows[0]["acesso1_func"].ToString());
                sal_func = Convert.ToDouble(cripto.Decrypt(tabela_memoria.Rows[0]["sal_func"].ToString()));
                status_func = (tabela_memoria.Rows[0]["status_func"].ToString());
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean esqueceu(string email, string cpf)
        {
            carregar_tabela("select * from funcionario where status_func=1 and email_func = '" + cripto.Encrypt(email) + "' and cpf_func = '" +cripto.Encrypt(cpf) + "'");

            if (tabela_memoria.Rows.Count > 0)
            {
                Nome1_func = cripto.Decrypt(tabela_memoria.Rows[0]["nome1_func"].ToString());
                Login_func = cripto.Decrypt(tabela_memoria.Rows[0]["login_func"].ToString());
                Pass_func = cripto.Decrypt(tabela_memoria.Rows[0]["pass_func"].ToString());
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

            carregar_tabela("update funcionario set pass_func = '" + novasenha + "',pass1_func = '" + novasenha1 + "',pass2_func = '" + novasenha2 + "',pass3_func = '" + novasenha3 + "',dataCad_func = '" + dataCorreta + "',dataRecad_func = '" + dataCorreta1 + "',acesso1_func = 1  where id_func = '" + cod + "'");
        }

        public Boolean checa6meses(string codFunc)
        {
            DateTime datacad, datarecad;

            carregar_tabela("select * from funcionario where id_func = '" + codFunc + "'");

            if (tabela_memoria.Rows.Count > 0)
            {
                datacad = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataCad_func"].ToString()));
                datarecad = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataRecad_func"].ToString()));

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
            carregar_tabela("select * from funcionario where acesso1_func= 0 and id_func = '" + ft + "'");

            if (tabela_memoria.Rows.Count > 0)
            {
                cod_func = Convert.ToInt32((tabela_memoria.Rows[0]["id_func"].ToString()));
                login_func = cripto.Decrypt(tabela_memoria.Rows[0]["login_func"].ToString());
                pass_func = cripto.Decrypt(tabela_memoria.Rows[0]["pass_func"].ToString());
                pass1_func = cripto.Decrypt(tabela_memoria.Rows[0]["pass1_func"].ToString());
                pass2_func = cripto.Decrypt(tabela_memoria.Rows[0]["pass2_func"].ToString());
                pass3_func = cripto.Decrypt(tabela_memoria.Rows[0]["pass3_func"].ToString());
                nome1_func = cripto.Decrypt(tabela_memoria.Rows[0]["nome1_func"].ToString());
                nome2_func = cripto.Decrypt(tabela_memoria.Rows[0]["nome2_func"].ToString());
                DataNasc_func = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataNasc_func"].ToString()));
                DataCad_func = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataCad_func"].ToString()));
                DataRecad_func = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataRecad_func"].ToString()));
                tel_func = cripto.Decrypt(tabela_memoria.Rows[0]["tel_func"].ToString());
                email_func = cripto.Decrypt(tabela_memoria.Rows[0]["email_func"].ToString());
                cpf_func = cripto.Decrypt(tabela_memoria.Rows[0]["cpf_func"].ToString());
                sexo_func = cripto.Decrypt(tabela_memoria.Rows[0]["sexo_func"].ToString());
                cep_func = cripto.Decrypt(tabela_memoria.Rows[0]["cep_func"].ToString());
                bairro_func = cripto.Decrypt(tabela_memoria.Rows[0]["bairro_func"].ToString());
                logradouro_func = cripto.Decrypt(tabela_memoria.Rows[0]["logradouro_func"].ToString());
                numero_func = cripto.Decrypt(tabela_memoria.Rows[0]["numero_func"].ToString());
                complemento_func = cripto.Decrypt(tabela_memoria.Rows[0]["complemento_func"].ToString());
                perg_func = cripto.Decrypt(tabela_memoria.Rows[0]["perg_func"].ToString());
                resp_func = cripto.Decrypt(tabela_memoria.Rows[0]["resp_func"].ToString());
                acesso1_func = (tabela_memoria.Rows[0]["acesso1_func"].ToString());
                sal_func = Convert.ToDouble(cripto.Decrypt(tabela_memoria.Rows[0]["sal_func"].ToString()));
                status_func = (tabela_memoria.Rows[0]["status_func"].ToString());
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

            carregar_tabela("select * from funcionario where perg_func='" + perg + "' and resp_func='" + resp + "' and id_func = '" + cod + "'");

            if (tabela_memoria.Rows.Count > 0)
            {
                cod_func = Convert.ToInt32((tabela_memoria.Rows[0]["id_func"].ToString()));
                login_func = cripto.Decrypt(tabela_memoria.Rows[0]["login_func"].ToString());
                pass_func = cripto.Decrypt(tabela_memoria.Rows[0]["pass_func"].ToString());
                pass1_func = cripto.Decrypt(tabela_memoria.Rows[0]["pass1_func"].ToString());
                pass2_func = cripto.Decrypt(tabela_memoria.Rows[0]["pass2_func"].ToString());
                pass3_func = cripto.Decrypt(tabela_memoria.Rows[0]["pass3_func"].ToString());
                nome1_func = cripto.Decrypt(tabela_memoria.Rows[0]["nome1_func"].ToString());
                nome2_func = cripto.Decrypt(tabela_memoria.Rows[0]["nome2_func"].ToString());
                DataNasc_func = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataNasc_func"].ToString()));
                DataCad_func = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataCad_func"].ToString()));
                DataRecad_func = Convert.ToDateTime(cripto.Decrypt(tabela_memoria.Rows[0]["dataRecad_func"].ToString()));
                tel_func = cripto.Decrypt(tabela_memoria.Rows[0]["tel_func"].ToString());
                email_func = cripto.Decrypt(tabela_memoria.Rows[0]["email_func"].ToString());
                cpf_func = cripto.Decrypt(tabela_memoria.Rows[0]["cpf_func"].ToString());
                sexo_func = cripto.Decrypt(tabela_memoria.Rows[0]["sexo_func"].ToString());
                cep_func = cripto.Decrypt(tabela_memoria.Rows[0]["cep_func"].ToString());
                bairro_func = cripto.Decrypt(tabela_memoria.Rows[0]["bairro_func"].ToString());
                logradouro_func = cripto.Decrypt(tabela_memoria.Rows[0]["logradouro_func"].ToString());
                numero_func = cripto.Decrypt(tabela_memoria.Rows[0]["numero_func"].ToString());
                complemento_func = cripto.Decrypt(tabela_memoria.Rows[0]["complemento_func"].ToString());
                perg_func = cripto.Decrypt(tabela_memoria.Rows[0]["perg_func"].ToString());
                resp_func = cripto.Decrypt(tabela_memoria.Rows[0]["resp_func"].ToString());
                acesso1_func = (tabela_memoria.Rows[0]["acesso1_func"].ToString());
                sal_func = Convert.ToDouble(cripto.Decrypt(tabela_memoria.Rows[0]["sal_func"].ToString()));
                status_func = (tabela_memoria.Rows[0]["status_func"].ToString());
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
