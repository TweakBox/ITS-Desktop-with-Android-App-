package com.ecandy.juansumulonglearningapp;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class SplashScreen extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_splash_screen);

        EditText txtUserID = (EditText) findViewById(R.id.txtUserID);
        EditText txtPassword = (EditText) findViewById(R.id.txtPassword);
        Button btnSubmit = (Button) findViewById(R.id.btnSubmit);
        btnSubmit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                onLogin();
            }
        });

        BackgroundWorker bgw = new BackgroundWorker(this);
        bgw.execute("login", txtUserID.getText().toString(), txtPassword.getText().toString());
    }

    private void onLogin() {

    }
}
