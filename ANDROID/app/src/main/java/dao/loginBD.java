package dao;

import android.app.ProgressDialog;
import android.content.Context;
import android.os.AsyncTask;
import android.widget.Toast;
import model.usuario;
import utils.criptografia;
import utils.dadosLogado;
import utils.dadosTransacao;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

/**
 * Created by aluno on 23/09/2016.
 */

public class loginBD extends AsyncTask<Object, Object, Boolean> {

    Connection conexao;

    Context tela;

    ProgressDialog dialogo;

    criptografia cripto;

    private Boolean logado;

    public usuario getUsuClasse() {
        return usuClasse;
    }

    public void setUsuClasse(usuario usuClasse) {
        this.usuClasse = usuClasse;
    }

    private usuario usuClasse;



    public Boolean getLogado() {
        return logado;
    }

    public void setLogado(Boolean logado) {
        this.logado = logado;
    }
    ///////////////////////////////////////////

    public loginBD(Context tela) {
        super();
        this.tela = tela;

        cripto = new criptografia("ETEP");
    }

    //////////////////////////////////////////



    public Boolean connect() {

        try {
            Class.forName("com.mysql.jdbc.Driver").newInstance();

            conexao = DriverManager.getConnection(
                    "jdbc:mysql://172.16.55.176:3306/DownloadBankerCripto", "root", "ALUNOS");
            return true;
        } catch (Exception e) {
            e.printStackTrace();
            return false;
        }
    }

    public void disconnect(){
        try {
            conexao.close();
        } catch (SQLException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
    }

    @Override
    protected void onPreExecute() {
        // TODO Auto-generated method stub
        super.onPreExecute();

        dialogo = new ProgressDialog(tela);
        dialogo.setMessage("Aguarde ...");
        dialogo.show();
    }

    @Override
    protected Boolean doInBackground(Object... params) {
        // TODO Auto-generated method stub

        Boolean resp;

        connect();

        resp = logar();

        return resp;
    }



    @Override
    protected void onPostExecute(Boolean result) {
        // TODO Auto-generated method stub
        super.onPostExecute(result);

        if(result == false)
            Toast.makeText(tela,
                    "Usuario ou senha incorretos!!!",
                    Toast.LENGTH_SHORT).show();

        dialogo.dismiss();

        disconnect();
    }

    //new new new new new new

    public Boolean logar(){

        try {

            ResultSet tabelaMemoria;
            String sql = "select * from usuario where login_user=? and pass_user=? and status_user=1";
            PreparedStatement comando = conexao.prepareStatement(sql);
            comando.setString(1,cripto.encrypt(usuClasse.getLogin_user().getBytes()).replace("\n",""));
            comando.setString(2,cripto.encrypt(usuClasse.getPass_user().getBytes()).replace("\n",""));
            tabelaMemoria = comando.executeQuery();


            if(tabelaMemoria.next())
            {
                setLogado(true);
                dadosLogado.setIdUser(tabelaMemoria.getInt("id_user"));
                dadosLogado.setNomeUsuario(cripto.decrypt(tabelaMemoria.getString("nome_user")));
                dadosLogado.setEmailUsuario(cripto.decrypt(tabelaMemoria.getString("email_user")));
                dadosLogado.setCpfUsuario(cripto.decrypt(tabelaMemoria.getString("cpf_user")));
                dadosLogado.setSexoUsuario(cripto.decrypt(tabelaMemoria.getString("sexo_user")));
                dadosLogado.setLoginUsuario(cripto.decrypt(tabelaMemoria.getString("login_user")));

                try{

                    ResultSet tabelaM;
                    String sqlM = "select * from transacao where id_user=?";
                    PreparedStatement comandoM =conexao.prepareStatement(sqlM);
                    comandoM.setInt(1,dadosLogado.getIdUser());
                    tabelaM = comandoM.executeQuery();
                    double somavalor = 0;

                    while(tabelaM.next()){

                        dadosTransacao.setValor_transacao(Double.parseDouble(cripto.decrypt(tabelaM.getString("valor_transacao")).replace(',','.')));

                        somavalor += dadosTransacao.getValor_transacao();

                    }

                    dadosTransacao.setVal(somavalor);


                } catch(SQLException e){
                    e.printStackTrace();
                }

                return true;
            }
            else
            {
                setLogado(false);
                usuClasse = null;
                return false;
            }


        } catch (SQLException e) {
            e.printStackTrace();
            return false;

        }
    }

}
