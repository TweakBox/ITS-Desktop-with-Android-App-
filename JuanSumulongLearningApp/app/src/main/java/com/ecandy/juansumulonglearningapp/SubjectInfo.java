package com.ecandy.juansumulonglearningapp;

import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.graphics.Color;
import android.os.Environment;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.google.android.gms.appindexing.AppIndex;
import com.google.android.gms.common.api.GoogleApiClient;

import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;

public class SubjectInfo extends AppCompatActivity {
    private String _id, _subject;
    /**
     * ATTENTION: This was auto-generated to implement the App Indexing API.
     * See https://g.co/AppIndexing/AndroidStudio for more information.
     */
    private GoogleApiClient client;

    private int timesOpened = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_subject_info);
        // ATTENTION: This was auto-generated to implement the App Indexing API.
        // See https://g.co/AppIndexing/AndroidStudio for more information.
        client = new GoogleApiClient.Builder(this).addApi(AppIndex.API).build();

        Bundle data = getIntent().getExtras();
        _id = data.getString("id");
        _subject = data.getString("subject");

        new FetchSubjectInfoScript(this).execute("Homeworks", _id, _subject);
    }

    public void onFetchHomeworksComplete(String result) {
        LinearLayout vllHomeworkList = (LinearLayout) findViewById(R.id.vllHomeworkList);

        vllHomeworkList.removeAllViews();
        if (!result.startsWith("!")) {
            if (result.length() > 0) {
                String[] lines = result.split(";");
                for (int i = 0; i < lines.length; i++) {

                    Button btn = new Button(this);
                    btn.setBackgroundColor(getResources().getColor(R.color.colorAccent));
                    btn.setTextColor(Color.WHITE);
                    btn.setText(lines[i].split(",")[1]);
                    btn.setTag(lines[i].split(",")[0]);
                    btn.setLayoutParams(new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.WRAP_CONTENT));

                    btn.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View v) {
                            onHomeworkClick(((Button)v).getText().toString() , v.getTag());
                        }
                    });

                    vllHomeworkList.addView(btn);
                }
            } else {
                TextView tvw = new TextView(this);
                tvw.setText("Yay! No homeworks! :D");

                tvw.setLayoutParams(new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.WRAP_CONTENT));

                vllHomeworkList.addView(tvw);
            }

            new FetchSubjectInfoScript(this).execute("Quiz", _id, _subject);
        }
    }

    public void onFetchQuizzesComplete(String result) {
        LinearLayout vllQuizList = (LinearLayout) findViewById(R.id.vllQuizList);

        vllQuizList.removeAllViews();
        if (!result.startsWith("!")) {
            if (result.length() > 0) {
                String[] lines = result.split(";");
                for (int i = 0; i < lines.length; i++) {

                    Button btn = new Button(this);
                    btn.setBackgroundColor(getResources().getColor(R.color.colorAccent));
                    btn.setTextColor(Color.WHITE);
                    btn.setText(lines[i].split(",")[0] + " - " + lines[i].split(",")[3] + "pts.");
                    btn.setTag(lines[i].split(",")[1]);
                    btn.setLayoutParams(new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.WRAP_CONTENT));

                    btn.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View v) {
                            onQuizClick(v.getTag());
                        }
                    });

                    vllQuizList.addView(btn);
                }
            } else {
                TextView tvw = new TextView(this);
                tvw.setText("Yay! No quizzes! :D");

                tvw.setLayoutParams(new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.WRAP_CONTENT));

                vllQuizList.addView(tvw);
            }

            new FetchSubjectInfoScript(this).execute("Handouts", _id, _subject);
        }
    }

    public void onFetchHandoutsComplete(String result) {
        LinearLayout vllHandoutsList = (LinearLayout) findViewById(R.id.vllHandoutList);

        vllHandoutsList.removeAllViews();
        if (!result.startsWith("!")) {
            if (result.length() > 0) {
                String[] lines = result.split(";");
                for (int i = 0; i < lines.length; i++) {

                    Button btn = new Button(this);
                    btn.setBackgroundColor(getResources().getColor(R.color.colorAccent));
                    btn.setTextColor(Color.WHITE);
                    btn.setText(lines[i].split(",")[1] + " - " + lines[i].split(",")[2]);
                    btn.setTag(lines[i].split(",")[0]);
                    btn.setLayoutParams(new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.WRAP_CONTENT));

                    btn.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View v) {
                            onHandoutClick(v.getTag());
                        }
                    });

                    vllHandoutsList.addView(btn);
                }
            } else {
                TextView tvw = new TextView(this);
                tvw.setText("No handouts... :/");

                tvw.setLayoutParams(new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.WRAP_CONTENT));

                vllHandoutsList.addView(tvw);
            }

            new FetchSubjectInfoScript(this).execute("Notes", _id, _subject);
        }
    }

    public void onFetchNotesComplete(String result) {
        LinearLayout vllNotesList = (LinearLayout) findViewById(R.id.vllNotesList);

        vllNotesList.removeAllViews();
        if (!result.startsWith("!")) {
            if (result.length() > 0) {
                String[] lines = result.split(";");
                for (int i = 0; i < lines.length; i++) {

                    Button btn = new Button(this);
                    btn.setBackgroundColor(getResources().getColor(R.color.colorAccent));
                    btn.setTextColor(Color.WHITE);
                    btn.setText(lines[i].split(",")[0]);
                    btn.setTag(lines[i].split(",")[1]);
                    btn.setLayoutParams(new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.WRAP_CONTENT));

                    btn.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View v) {
                            onNoteClick(v.getTag());
                        }
                    });

                    vllNotesList.addView(btn);
                }
            } else {
                TextView tvw = new TextView(this);
                tvw.setText("No notes? Try making one!");

                tvw.setLayoutParams(new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.WRAP_CONTENT));

                vllNotesList.addView(tvw);
            }
        }
    }

    private void onHomeworkClick(String title, Object tag) {
        new AlertDialog.Builder(this)
                .setTitle(title)
                .setMessage(tag.toString())
                .show();
    }

    private void onQuizClick(Object tag) {
        Intent i = new Intent(this, QuizForm.class);
        i.putExtra("id", _id);
        i.putExtra("quiz", tag.toString());
        startActivity(i);
    }

    private void onHandoutClick(Object tag) {
//        SQLiteDatabase db = openOrCreateDatabase("jsla", MODE_PRIVATE, null);
//        Cursor c = db.rawQuery("select File, Filename from tbl_handouts where _id = " + tag.toString(), null);
//        if (c.getCount() > 0) {
//            byte[] file =  c.getBlob(0);
//            byte[] part1 = new byte[file.length / 2];
//            byte[] part2 = new byte[file.length / 2 + (file.length % 2 == 0 ? 0 : 1)];
//
//            try {
//                FileOutputStream fos = openFileOutput(Environment.getDataDirectory() + c.getString(1) + ".1", Context.MODE_PRIVATE);
//                fos.write(part1);
//                fos = openFileOutput(Environment.getDataDirectory() + c.getString(1) + ".2", Context.MODE_PRIVATE);
//                fos.write(part2);
//            } catch (FileNotFoundException e) {
//                return;
//            } catch (IOException e) {
//                return;
//            }
//        } else {
//            //id, subject
//            Toast.makeText(this, "No", Toast.LENGTH_LONG).show();
//        }
    }

    private void onNoteClick(Object tag) {
        Intent i = new Intent(this, QuizForm.class);
        i.putExtra("id", tag.toString());
        i.putExtra("studId", _id);
        i.putExtra("subject", _subject);
        startActivity(i);
    }

    @Override
    protected void onResume() {
        super.onResume();

        if (timesOpened++ > 0) {
            FetchSubjectInfoScript fqs = new FetchSubjectInfoScript(this);
            fqs.execute(_id, _subject);
        }
    }
}
