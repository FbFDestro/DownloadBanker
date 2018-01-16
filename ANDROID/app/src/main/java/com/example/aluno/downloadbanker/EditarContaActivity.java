package com.example.aluno.downloadbanker;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import model.usuario;
import utils.dadosLogado;
import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.RadioButton;
import dao.alterarBD;
import java.util.concurrent.ExecutionException;

public class EditarContaActivity extends AppCompatActivity implements OnClickListener {

    EditText txtLoginEdit, txtNomeEdit, txtEmailEdit, txtCpfEdit;
    RadioButton rdM, rdF;
    Button btnCancelar, btnSalvar;
    usuario userTela;



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_editar_conta);

        txtLoginEdit = (EditText) findViewById(R.id.txtLoginEdit);
        txtNomeEdit = (EditText) findViewById(R.id.txtNomeEdit);
        txtEmailEdit = (EditText) findViewById(R.id.txtEmailEdit);
        txtCpfEdit = (EditText) findViewById(R.id.txtCpfEdit);

        rdM = (RadioButton) findViewById(R.id.rdM);
        rdF = (RadioButton) findViewById(R.id.rdF);

        btnCancelar = (Button) findViewById(R.id.btnCancelar);
        btnSalvar = (Button) findViewById(R.id.btnSalvar);


        btnCancelar.setOnClickListener(this);
        btnSalvar.setOnClickListener(this);

        txtNomeEdit.setText(dadosLogado.getNomeUsuario());
        txtLoginEdit.setText(dadosLogado.getLoginUsuario());
        txtEmailEdit.setText(dadosLogado.getEmailUsuario());
        txtCpfEdit.setText(dadosLogado.getCpfUsuario());

        if(dadosLogado.getSexoUsuario() == "M"){
            rdM.setChecked(true);

        } else {
            rdF.setChecked(true);
        }
    }

    @Override
    public void onClick(View v) {
        switch (v.getId()) {
            case R.id.btnCancelar:

                finish();

                break;

            case R.id.btnSalvar:
                usuario usuTela = new usuario();
                usuTela.setLogin_user(txtLoginEdit.getText().toString());
                dadosLogado.setLoginUsuario(txtLoginEdit.getText().toString());
                dadosLogado.setNomeUsuario(txtNomeEdit.getText().toString());
                dadosLogado.setEmailUsuario(txtEmailEdit.getText().toString());
                dadosLogado.setCpfUsuario(txtCpfEdit.getText().toString());

                if(rdM.isChecked() == true){

                    dadosLogado.setSexoUsuario("M");

                } else {

                    dadosLogado.setSexoUsuario("F");

                }

                alterarBD altBD = new alterarBD(this);

                try {
                    altBD.execute().get();
                } catch (InterruptedException e) {
                    // TODO Auto-generated catch block
                    e.printStackTrace();
                } catch (ExecutionException e) {
                    // TODO Auto-generated catch block
                    e.printStackTrace();
                }

                Intent tela = new Intent(EditarContaActivity.this,
                        WalletActivity.class);
                startActivity(tela);



                break;
        }
    }
}
