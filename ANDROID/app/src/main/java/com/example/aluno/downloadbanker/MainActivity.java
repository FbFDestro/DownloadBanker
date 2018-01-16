package com.example.aluno.downloadbanker;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import model.usuario;
import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;

import java.util.concurrent.ExecutionException;

import dao.loginBD;

public class MainActivity extends AppCompatActivity implements OnClickListener{

    EditText txtUser, txtSenha;
    Button btnEntrar;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        txtUser = (EditText) findViewById(R.id.txtUser);
        txtSenha = (EditText) findViewById(R.id.txtSenha);
        btnEntrar = (Button) findViewById(R.id.btnEntrar);

        btnEntrar.setOnClickListener(this);
    }

    @Override
    public void onClick(View view) {


        loginBD logBD = new loginBD(this);

            usuario usuTela = new usuario();

            usuTela.setLogin_user(txtUser.getText().toString());
            usuTela.setPass_user(txtSenha.getText().toString());

            logBD.setUsuClasse(usuTela);
        try {
        logBD.execute().get();


        if(logBD.getLogado() == true)
        {
            Intent tela = new Intent(MainActivity.this,
                    WalletActivity.class);
            startActivity(tela);


        }
        else
        {
            // erro no login
        }

        } catch (InterruptedException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        } catch (ExecutionException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }

    }
}
