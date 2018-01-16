package com.example.aluno.downloadbanker;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

import dao.alterarBD;
import dao.fundosBD;
import dao.loginBD;
import model.fundos;
import model.usuario;
import utils.dadosTransacao;
import utils.dadosLogado;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.google.zxing.integration.android.IntentIntegrator;
import com.google.zxing.integration.android.IntentResult;

import java.util.concurrent.ExecutionException;

import static com.example.aluno.downloadbanker.R.id.txtUser;

public class WalletActivity extends AppCompatActivity implements OnClickListener{

    TextView lblNomeV, lblValor;
    Button btnSair, btnEditar;
    private Button scan_btn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_wallet);

        scan_btn = (Button) findViewById(R.id.scan_btn);
        final Activity activity = this;

        scan_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                IntentIntegrator integrator = new IntentIntegrator(activity);
                integrator.setDesiredBarcodeFormats(IntentIntegrator.QR_CODE_TYPES);
                integrator.setPrompt("Scan");
                integrator.setCameraId(0);
                integrator.setBeepEnabled(false);
                integrator.setBarcodeImageEnabled(false);
                integrator.initiateScan();
            }
        });

        lblNomeV = (TextView) findViewById(R.id.lblNomeV);
        lblValor = (TextView) findViewById(R.id.lblValor);

        btnSair = (Button) findViewById(R.id.btnSair);
        btnEditar = (Button) findViewById(R.id.btnEditar);

        btnSair.setOnClickListener(this);
        btnEditar.setOnClickListener(this);





        lblNomeV.setText(dadosLogado.getNomeUsuario());
        lblValor.setText("R$ " + dadosTransacao.getVal());
    }

    @Override
    public void onClick(View v) {
        switch (v.getId()) {
            case R.id.btnSair:

                usuario usuTela = new usuario();
                usuTela.setLogin_user("");
                usuTela.setPass_user("");
                usuTela.setId_user(0);

                dadosLogado.setLoginUsuario("");
                dadosLogado.setCpfUsuario("");
                dadosLogado.setSexoUsuario("");
                dadosLogado.setEmailUsuario("");
                dadosLogado.setNomeUsuario("");
                dadosLogado.setIdUser(0);

                Intent tela1 = new Intent(WalletActivity.this,
                        MainActivity.class);
                startActivity(tela1);


                break;

            case R.id.btnEditar:

                Intent tela = new Intent(WalletActivity.this,
                        EditarContaActivity.class);
                startActivity(tela);

                break;
        }




    }

    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        IntentResult result = IntentIntegrator.parseActivityResult(requestCode, resultCode, data);
        if (result != null){
            if (result.getContents()== null){
                Toast.makeText(this, "Você cancelou o scaneamento!", Toast.LENGTH_LONG).show();

            }
            else {
                fundosBD fundoBD = new fundosBD(this);

                fundos fundTela = new fundos();

                fundTela.setId_qr(Integer.parseInt(result.getContents()));


                fundoBD.setFundClasse(fundTela);
                try {
                    fundoBD.execute().get();


                    if(fundoBD.getStatusqr() == true)
                    {
                        Toast.makeText(this, "Fundos Cadastrados com sucesso!!", Toast.LENGTH_LONG).show();
                        lblValor.setText("R$ " + dadosTransacao.getVal());

                    }
                    else
                    {
                        // erro no cadastro de fundos
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
        else {

            super.onActivityResult(requestCode, resultCode, data);
        }
    }
}
