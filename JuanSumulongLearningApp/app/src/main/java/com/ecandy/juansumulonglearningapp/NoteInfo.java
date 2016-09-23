package com.ecandy.juansumulonglearningapp;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class NoteInfo extends AppCompatActivity {
    String id, subject, studId, type;
    EditText txtTitle, txtContent;
    Button btnPositive, btnNegative;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_note_info);

        txtTitle = (EditText) findViewById(R.id.txtTitle);
        txtContent = (EditText) findViewById(R.id.txtContent);
        btnPositive = (Button) findViewById(R.id.btnPositive);
        btnPositive.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

            }
        });
        btnNegative = (Button) findViewById(R.id.btnNegative);

        Bundle data  = getIntent().getExtras();
        if (data != null) {
            setTitle("Edit Note");
            type = "edit";

            id = data.getString("id");
            studId = data.getString("studId");
            subject = data.getString("subject");


        } else {
            setTitle("Add Note");
            type = "add";
        }
    }

    private void onPositiveClick() {
        FetchNoteInfoScript fnis = new FetchNoteInfoScript(this);
        if (type.equals("edit")) {

        }
    }

    private void edit() {

    }

    private void onNegativeClick() {

    }
}
