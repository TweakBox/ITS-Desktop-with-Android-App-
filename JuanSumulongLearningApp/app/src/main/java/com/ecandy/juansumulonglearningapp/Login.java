package com.ecandy.juansumulonglearningapp;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class Login extends AppCompatActivity {

    private EditText txtUserID;
    private EditText txtPassword;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        txtUserID = (EditText) findViewById(R.id.txtUserID);
        txtPassword = (EditText) findViewById(R.id.txtPassword);
        Button btnSubmit = (Button) findViewById(R.id.btnSubmit);
        btnSubmit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                onLogin();
            }
        });

//        Intent i = new Intent(this, Dashboard.class);
//        i.putExtra("type", "Student");
//        i.putExtra("id", "0003211831");
//        this.startActivity(i);
//        finish();
    }

    private void onLogin() {
        LoginScript bgw = new LoginScript(this);
        bgw.execute("login", txtUserID.getText().toString(), txtPassword.getText().toString());
    }
}
