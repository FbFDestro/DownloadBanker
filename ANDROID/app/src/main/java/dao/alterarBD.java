package dao;

import android.app.ProgressDialog;
import android.content.Context;
import android.os.AsyncTask;
import android.widget.Toast;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.SQLException;

import model.usuario;
import utils.criptografia;
import utils.dadosLogado;

/**
 * Created by aluno on 23/09/2016.
 */

public class alterarBD extends AsyncTask<Object, Object, Boolean> {

    Connection conexao;

    Context tela;

    ProgressDialog dialogo;

    criptografia cripto;

    public alterarBD(Context tela) {
        super();
        this.tela = tela;
        cripto = new criptografia("ETEP");
    }

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

        resp = alterar();

        return resp;
    }



    @Override
    protected void onPostExecute(Boolean result) {
        // TODO Auto-generated method stub
        super.onPostExecute(result);

        if(result == true)
            Toast.makeText(tela,
                    "Dados alterados com sucesso!!!",
                    Toast.LENGTH_SHORT).show();
        else
            Toast.makeText(tela,
                    "ERRO na altera��o!!!",
                    Toast.LENGTH_SHORT).show();

        dialogo.dismiss();

        disconnect();
    }

    public Boolean alterar()
    {
        try
        {


            String sql = "update usuario set nome_user = ?, email_user = ?, cpf_user = ?, sexo_user = ? WHERE id_user = ?";
            PreparedStatement comando = conexao.prepareStatement(sql);

            comando.setString(1,cripto.encrypt(dadosLogado.getNomeUsuario().getBytes()).replace("/n",""));
            comando.setString(2,cripto.encrypt(dadosLogado.getEmailUsuario().getBytes()).replace("/n",""));
            comando.setString(3,cripto.encrypt(dadosLogado.getCpfUsuario().getBytes()).replace("/n",""));
            comando.setString(4, cripto.encrypt(dadosLogado.getSexoUsuario().getBytes()).replace("/n",""));
            comando.setInt(5, dadosLogado.getIdUser());
            comando.executeUpdate();

            return true;
        }
        catch (SQLException e) //java.sql
        {
            e.printStackTrace();
            return false;
        }
    }

}
