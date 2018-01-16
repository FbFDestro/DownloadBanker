package utils;

/**
 * Created by aluno on 21/10/2016.
 */

abstract public class dadosTransacao {

    private static int id_transacao;
    private static int id_user;
    private static int id_tipoTransacao;
    private static String data_transacao;
    private static Double valor_transacao;





    private static double val = 0;

    public static double getVal() {
        return val;
    }

    public static void setVal(double val) {
        dadosTransacao.val = val;
    }


    public static int getId_transacao() {
        return id_transacao;
    }

    public static void setId_transacao(int id_transacao) {
        dadosTransacao.id_transacao = id_transacao;
    }

    public static int getId_user() {
        return id_user;
    }

    public static void setId_user(int id_user) {
        dadosTransacao.id_user = id_user;
    }

    public static int getId_tipoTransacao() {
        return id_tipoTransacao;
    }

    public static void setId_tipoTransacao(int id_tipoTransacao) {
        dadosTransacao.id_tipoTransacao = id_tipoTransacao;
    }

    public static String getData_transacao() {
        return data_transacao;
    }

    public static void setData_transacao(String data_transacao) {
        dadosTransacao.data_transacao = data_transacao;
    }

    public static Double getValor_transacao() {
        return valor_transacao;
    }

    public static void setValor_transacao(Double valor_transacao) {
        dadosTransacao.valor_transacao = valor_transacao;
    }


}
