package utils;

/**
 * Created by aluno on 24/10/2016.
 */

abstract public class dadosLogado {

    private static int idUser;
    private static String nomeUsuario;
    private static String emailUsuario;
    private static String cpfUsuario;
    private static String sexoUsuario;
    private static String loginUsuario;


    public static int getIdUser() {
        return idUser;
    }

    public static void setIdUser(int idUser) {
        dadosLogado.idUser = idUser;
    }

    public static String getNomeUsuario() {
        return nomeUsuario;
    }

    public static void setNomeUsuario(String nomeUsuario) {
        dadosLogado.nomeUsuario = nomeUsuario;
    }

    public static String getEmailUsuario() {
        return emailUsuario;
    }

    public static void setEmailUsuario(String emailUsuario) {
        dadosLogado.emailUsuario = emailUsuario;
    }

    public static String getCpfUsuario() {
        return cpfUsuario;
    }

    public static void setCpfUsuario(String cpfUsuario) {
        dadosLogado.cpfUsuario = cpfUsuario;
    }

    public static String getSexoUsuario() {
        return sexoUsuario;
    }

    public static void setSexoUsuario(String sexoUsuario) {
        dadosLogado.sexoUsuario = sexoUsuario;
    }

    public static String getLoginUsuario() {
        return loginUsuario;
    }

    public static void setLoginUsuario(String loginUsuario) {
        dadosLogado.loginUsuario = loginUsuario;
    }
}