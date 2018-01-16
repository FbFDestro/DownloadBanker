using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DownloadBanker
{
    class acessoCEP
    {
        String tipo_logradouro, logradouro, bairro, cidade, uf, cep, status;

        #region variaveis encapsuladas
        public String Status
        {
            get { return status; }
            set { status = value; }
        }

        public String Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        public String Uf
        {
            get { return uf; }
            set { uf = value; }
        }

        public String Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        public String Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        public String Logradouro
        {
            get { return logradouro; }
            set { logradouro = value; }
        }

        public String Tipo_logradouro
        {
            get { return tipo_logradouro; }
            set { tipo_logradouro = value; }
        }
        #endregion

        int bai_nu_sequencial, loc_nu_sequencial;
        String ufe_sg, bai_no;

        #region Variaveis encapsuladas
        public int Loc_nu_sequencial
        {
            get { return loc_nu_sequencial; }
            set { loc_nu_sequencial = value; }
        }

        public int Bai_nu_sequencial
        {
            get { return bai_nu_sequencial; }
            set { bai_nu_sequencial = value; }
        }

        public String Bai_no
        {
            get { return bai_no; }
            set { bai_no = value; }
        }

        public String Ufe_sg
        {
            get { return ufe_sg; }
            set { ufe_sg = value; }
        }
        #endregion

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comado;
        DataTable tabela_memoria;


        private void carregar_tabela(String comando)
        {
            Conexao2.fechar();
            Conexao2.criar_Conexao();
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao2.Conectar);
            executar_comado = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);

        }

        public DataTable tipoLogradouro()
        {
            carregar_tabela("select * from log_tipo_logr");
            return tabela_memoria;
        }

        public Boolean buscaEndereco(String info_cep)
        {

            carregar_tabela("SELECT log_logradouro.log_tipo_logradouro, log_logradouro.log_nome as logradouro,log_bairro.bai_no as bairro," +
                            "log_localidade.loc_no as cidade, log_localidade.ufe_sg as uf, log_logradouro.cep, log_logradouro.log_status_tipo_log FROM log_logradouro," +
                            "log_localidade,log_bairro WHERE log_logradouro.loc_nu_sequencial = log_localidade.loc_nu_sequencial" +
                            " AND log_logradouro.bai_nu_sequencial_ini = log_bairro.bai_nu_sequencial AND log_logradouro.cep = '" + info_cep + "'");

            try
            {
                tipo_logradouro = tabela_memoria.Rows[0]["log_tipo_logradouro"].ToString();
                logradouro      = tabela_memoria.Rows[0]["logradouro"].ToString();
                bairro          = tabela_memoria.Rows[0]["bairro"].ToString();
                cidade          = tabela_memoria.Rows[0]["cidade"].ToString();
                uf              = tabela_memoria.Rows[0]["uf"].ToString();
                status          = tabela_memoria.Rows[0]["log_status_tipo_log"].ToString();
                cep             = tabela_memoria.Rows[0]["cep"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable listaCidade(String uf)
        {
            carregar_tabela("select * from log_localidade where ufe_sg='" + uf + "'");
            return tabela_memoria;
        }

        public DataTable listaBairro(String cidade)
        {
            carregar_tabela("select * from log_bairro where loc_nu_sequencial=" + cidade + " order by bai_no");
            return tabela_memoria;
        }

        public DataTable buscaCEP(String bairro, String cidade, String tipo_log)
        {

            carregar_tabela("SELECT * FROM log_logradouro where bai_nu_sequencial_ini=" + bairro + " and loc_nu_sequencial=" + cidade +
                            " and log_tipo_logradouro='" + tipo_log + "' order by log_no");

            return tabela_memoria;
        }

        public DataTable filtroEndereco(String bairro, String cidade, String tipo_log, String rua)
        {

            carregar_tabela("SELECT * FROM log_logradouro where bai_nu_sequencial_ini=" + bairro + " and loc_nu_sequencial=" + cidade +
                            " and log_tipo_logradouro='" + tipo_log + "' and log_no like '" + rua + "%' order by log_no");

            return tabela_memoria;
        }

        public void cepEncontrado(String bairro, String cidade, String tipo_log, String rua)
        {

            carregar_tabela("SELECT * FROM log_logradouro where bai_nu_sequencial_ini=" + bairro + " and loc_nu_sequencial=" + cidade +
                            " and log_tipo_logradouro='" + tipo_log + "' and log_no = '" + rua + "'");

            cep = tabela_memoria.Rows[0]["cep"].ToString();
            status = tabela_memoria.Rows[0]["log_status_tipo_log"].ToString();
        }

        public void cadastrarCEP(String ufe_sg, String loc_nu_sequencial, String log_no, String log_nome, String bai_nu_sequencial_ini,
            String cep, String log_tipo_logradouro, String log_status_tipo_log, String log_no_sem_acento)
        {
            int num;
            num = Convert.ToInt32(buscarNumCep()) + 1;

            carregar_tabela("insert into log_logradouro (log_nu_sequencial,ufe_sg,loc_nu_sequencial,log_no,log_nome,bai_nu_sequencial_ini,cep,log_tipo_logradouro,log_status_tipo_log,log_no_sem_acento)" +
                                               " values (" + num + ",'" + ufe_sg + "'," + loc_nu_sequencial + ",'" + log_no + "','" + log_nome + "'," + bai_nu_sequencial_ini + ",'" + cep + "','" + log_tipo_logradouro + "','" + log_status_tipo_log + "','" + log_no_sem_acento + "')");
        }

        public void cadastrarCEPZonaRural(String ufe_sg, String loc_nu_sequencial, String log_no, String log_nome, String bai_nu_sequencial_ini,
            String log_tipo_logradouro, String log_status_tipo_log, String log_no_sem_acento)
        {
            int num;
            num = Convert.ToInt32(buscarNumCep()) + 1;

            carregar_tabela("insert into log_logradouro (log_nu_sequencial,ufe_sg,loc_nu_sequencial,log_no,log_nome,bai_nu_sequencial_ini,cep,log_tipo_logradouro,log_status_tipo_log,log_no_sem_acento)" +
                                               " values (" + num + ",'" + ufe_sg + "'," + loc_nu_sequencial + ",'" + log_no + "','" + log_nome + "'," + bai_nu_sequencial_ini + ",'" + num + "','" + log_tipo_logradouro + "','" + log_status_tipo_log + "','" + log_no_sem_acento + "')");
        }

        public String buscarNumCep()
        {
            carregar_tabela("select max(log_nu_sequencial) as num from log_logradouro");

            return tabela_memoria.Rows[0]["num"].ToString();
        }

        public Boolean buscarBairro(String uf, String cidade, String bairro)
        {
            carregar_tabela("select * from log_bairro where ufe_sg='" + uf + "' and loc_nu_sequencial='" + cidade + "' and bai_no='" + bairro + "'");

            try
            {
                bai_nu_sequencial = Convert.ToInt32(tabela_memoria.Rows[0]["bai_nu_sequencial"].ToString());
                ufe_sg = tabela_memoria.Rows[0]["ufe_sg"].ToString();
                loc_nu_sequencial = Convert.ToInt32(tabela_memoria.Rows[0]["loc_nu_sequencial"].ToString());
                bai_no = tabela_memoria.Rows[0]["bai_no"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void cadastrarBairro(String uf, String cidade, String bairro)
        {
            int num;
            num = Convert.ToInt32(buscarNumBairro()) + 1;

            carregar_tabela("insert into log_bairro values(" + num + ",'" + uf + "'," + cidade + ",'" + bairro + "',null)");
        }

        public String buscarNumBairro()
        {
            carregar_tabela("select max(bai_nu_sequencial) as num from log_bairro");

            return tabela_memoria.Rows[0]["num"].ToString();
        }

        public String buscarNumeroBairro(String bairro)
        {
            carregar_tabela("select * from log_bairro where bai_no='" + bairro + "' and loc_nu_sequencial='9660'");

            return tabela_memoria.Rows[0]["bai_nu_sequencial"].ToString();
        }

        public DataTable buscarFaixaCEP(String NumBairro)
        {
            carregar_tabela("select * from log_faixa_bairro where bai_nu_sequencial='" + NumBairro + "'");

            return tabela_memoria;
        }
    }
}
