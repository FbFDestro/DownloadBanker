package dao;

import android.app.ProgressDialog;
import android.content.Context;
import android.os.AsyncTask;
import android.widget.Toast;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;

import model.fundos;
import model.usuario;
import utils.criptografia;
import utils.dadosLogado;
import utils.dadosTransacao;

/**
 * Created by aluno on 04/11/2016.
 */

public class fundosBD extends AsyncTask<Object, Object, Boolean> {

    Connection conexao;

    Context tela;

    ProgressDialog dialogo;

    criptografia cripto;

    private Boolean statusqr;

    private fundos fundClasse;

    public usuario getUsuClasse() {
        return usuClasse;
    }

    public void setUsuClasse(usuario usuClasse) {
        this.usuClasse = usuClasse;
    }

    private usuario usuClasse;


    ///////////////////////////////////////////

    public fundosBD(Context tela) {
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

    public void disconnect() {
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

        resp = fundos();

        return resp;
    }


    @Override
    protected void onPostExecute(Boolean result) {
        // TODO Auto-generated method stub
        super.onPostExecute(result);

        if (result == false)
            Toast.makeText(tela,
                    "Cartão Invalido!!!",
                    Toast.LENGTH_SHORT).show();

        dialogo.dismiss();

        disconnect();
    }

    //new new new new new new

    public Boolean fundos() {

        try {
            ResultSet tabelaMemoria;
            String sql = "select * from QrCode where id_qr=? and status_qr=1";
            PreparedStatement comando = conexao.prepareStatement(sql);
            comando.setInt(1, fundClasse.getId_qr());
            tabelaMemoria = comando.executeQuery();

            if (tabelaMemoria.next()) {
                setStatusqr(true);
                fundClasse.setValor_qr(Double.parseDouble(cripto.decrypt(tabelaMemoria.getString("valor_qr"))));


                try {


                    String sqlM = "update QrCode set status_qr=? where id_qr=?";
                    PreparedStatement comandoM = conexao.prepareStatement(sqlM);
                    comandoM.setInt(1, 0);
                    comandoM.setInt(2, fundClasse.getId_qr());
                    comandoM.executeUpdate();


                } catch (SQLException e) {
                    e.printStackTrace();
                }


                try {

                    Date now = new Date(System.currentTimeMillis());
                    SimpleDateFormat formatador = new SimpleDateFormat("dd/MM/yyyy");

                    Double valor = fundClasse.getValor_qr();

                    String valorF = (valor.toString()).replace(",",".");

                    String sqlT = "insert into transacao values(0,?,?,?,?)";
                    PreparedStatement comandoT = conexao.prepareStatement(sqlT);
                    comandoT.setInt(1, dadosLogado.getIdUser());
                    comandoT.setInt(2, 1);
                    comandoT.setString(3, cripto.encrypt(valorF.toString().getBytes()).replace("\n", ""));
                    comandoT.setString(4, cripto.encrypt(formatador.format(now).toString().getBytes()).replace("\n", ""));
                    comandoT.executeUpdate();


                } catch (SQLException e) {
                    e.printStackTrace();
                }

                try {

                    Date now = new Date(System.currentTimeMillis());
                    SimpleDateFormat formatador = new SimpleDateFormat("dd/MM/yyyy");

                    SimpleDateFormat sdf = new SimpleDateFormat("HH:mm:ss");
                    Date hora = Calendar.getInstance().getTime(); // Ou qualquer outra forma que tem
                    String dataFormatada = sdf.format(hora);

                    String sqlT = "insert into auditoriaU values(0,?,?,?,?,?)";
                    PreparedStatement comandoT = conexao.prepareStatement(sqlT);
                    comandoT.setString(1, cripto.encrypt(formatador.format(now).toString().getBytes()).replace("\n", ""));
                    comandoT.setString(2, cripto.encrypt(dataFormatada.toString().getBytes()).replace("\n", ""));
                    comandoT.setInt(3, dadosLogado.getIdUser());
                    comandoT.setString(4, cripto.encrypt("INSERT".getBytes()).replace("\n", ""));
                    comandoT.setString(5, cripto.encrypt("ADICAO DE FUNDO".getBytes()).replace("\n", ""));

                    comandoT.executeUpdate();

                } catch (SQLException e) {
                    e.printStackTrace();
                }

                try {

                    ResultSet tabelaS;
                    String sqlS = "select * from transacao where id_user=?";
                    PreparedStatement comandoS = conexao.prepareStatement(sqlS);
                    comandoS.setInt(1, dadosLogado.getIdUser());
                    tabelaS = comandoS.executeQuery();
                    double somavalor = 0;

                    while (tabelaS.next()) {

                        dadosTransacao.setValor_transacao(Double.parseDouble(cripto.decrypt(tabelaS.getString("valor_transacao")).replace(',','.')));

                        somavalor += dadosTransacao.getValor_transacao();

                    }

                    dadosTransacao.setVal(somavalor);

                    return true;

                } catch (SQLException e) {
                    setStatusqr(false);
                    e.printStackTrace();
                    return false;
                }



            } else {
                setStatusqr(false);
                fundClasse = null;
                return false;
            }


        } catch (SQLException e) //java.sql
        {
            setStatusqr(false);
            e.printStackTrace();
            return false;
        }
    }







    public Boolean getStatusqr() {
        return statusqr;
    }

    public void setStatusqr(Boolean statusqr) {
        this.statusqr = statusqr;
    }

    public fundos getFundClasse() {
        return fundClasse;
    }

    public void setFundClasse(fundos fundClasse) {
        this.fundClasse = fundClasse;
    }
}
