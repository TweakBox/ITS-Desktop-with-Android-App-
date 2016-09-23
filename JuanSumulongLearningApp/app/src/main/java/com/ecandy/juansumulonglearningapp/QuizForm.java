package com.ecandy.juansumulonglearningapp;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.RelativeLayout;
import android.widget.TextView;
import android.widget.Toast;

import java.util.Calendar;

public class QuizForm extends AppCompatActivity {
    TextView tvwQuestion;
    RelativeLayout rlAnswer;
    ProgressBar pbrLoad;
    EditText txtAnswer;
    RadioGroup rgChoices;
    RadioButton rbnChoiceA, rbnChoiceB, rbnChoiceC, rbnChoiceD;
    Button btnStart, btnNext, btnPrevious;
    View.OnClickListener next, submit;
    private String _id, _quiz, _questionType;
    private String[][] _questions;
    private String[] _answers;
    private int _index = 0, _questionCount;
    private boolean _hasStarted = false;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_quiz_form);

        pbrLoad = (ProgressBar) findViewById(R.id.pbrLoad);

        //get extras
        Bundle data = getIntent().getExtras();
        _id = data.getString("id");
        _quiz = data.getString("quiz");

        //fetch questions
        FetchQuizQuestionsScript fqqs = new FetchQuizQuestionsScript(this);
        fqqs.execute(_quiz);

        btnStart = (Button) findViewById(R.id.btnStart);
        btnStart.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                onBtnStart_Clicked();
            }
        });

        tvwQuestion = (TextView) findViewById(R.id.tvwQuestion);
        rlAnswer = (RelativeLayout) findViewById(R.id.rlAnswer);
        txtAnswer = (EditText) findViewById(R.id.txtAnswer);
        rgChoices = (RadioGroup) findViewById(R.id.rgChoices);
        rbnChoiceA = (RadioButton) findViewById(R.id.rbnChoiceA);
        rbnChoiceB = (RadioButton) findViewById(R.id.rbnChoiceB);
        rbnChoiceC = (RadioButton) findViewById(R.id.rbnChoiceC);
        rbnChoiceD = (RadioButton) findViewById(R.id.rbnChoiceD);

        next = new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                onBtnNext_Clicked();
            }
        };
        submit = new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                new AlertDialog.Builder(v.getContext())
                        .setTitle("Warning")
                        .setMessage("Are you sure your finished with the quiz? Answers can't be modified afterwards.")
                        .setPositiveButton("Yes", new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {
                                submitAnswer();
                            }
                        })
                        .setNegativeButton("No", new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {

                            }
                        })
                        .setIcon(android.R.drawable.ic_dialog_alert)
                        .show();
            }
        };

        btnNext = (Button) findViewById(R.id.btnNext);
        btnNext.setOnClickListener(next);
        btnPrevious = (Button) findViewById(R.id.btnPrevious);
        btnPrevious.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                onBtnPrevious_Clicked();
            }
        });
    }

    public void onFetchQuestionsTaskComplete(String result) { //populate question array
        String[] lines = result.split(";");
        _questionCount = lines.length;
        _questions = new String[_questionCount][5];
        _answers = new String[_questionCount];
        for (int i = 0; i < _questionCount; i++) {
            String[] values = lines[i].split("#");
            for (int i2 = 0; i2 < values.length; i2++) {
                _questions[i][i2] = values[i2];
            }

            _answers[i] = "";
        }

        btnStart.setEnabled(true);
        btnStart.setBackgroundColor(getResources().getColor(R.color.colorAccent));
        pbrLoad.setVisibility(View.INVISIBLE);

}
    private void onBtnStart_Clicked() {
        setQuestion();

        btnStart.setVisibility(View.INVISIBLE);
        tvwQuestion.setVisibility(View.VISIBLE);
        rlAnswer.setVisibility(View.VISIBLE);
        btnNext.setVisibility(View.VISIBLE);

        _hasStarted = true;
    }

    private void setQuestion() {
        tvwQuestion.setText(_questions[_index][1]);
        clearFields();

        _questionType = _questions[_index][4];
        switch (_questionType) {
            case "Identification":
                txtAnswer.setVisibility(View.VISIBLE);
                txtAnswer.setText(_answers[_index]);
                rgChoices.setVisibility(View.INVISIBLE);

                break;
            case "Boolean":
                txtAnswer.setVisibility(View.INVISIBLE);
                rgChoices.setVisibility(View.VISIBLE);
                rbnChoiceC.setVisibility(View.INVISIBLE);
                rbnChoiceD.setVisibility(View.INVISIBLE);

                rbnChoiceA.setText("True");
                rbnChoiceB.setText("False");

                if (_answers[_index].equals("True")) {
                    rgChoices.check(rbnChoiceA.getId());
                } else if (_answers[_index].equals("False")) {
                    rgChoices.check(rbnChoiceB.getId());
                }

                break;
            case "Multiple":
                txtAnswer.setVisibility(View.INVISIBLE);
                rgChoices.setVisibility(View.VISIBLE);
                rbnChoiceA.setVisibility(View.VISIBLE);
                rbnChoiceB.setVisibility(View.VISIBLE);
                rbnChoiceC.setVisibility(View.VISIBLE);
                rbnChoiceD.setVisibility(View.VISIBLE);

                String[] choices = _questions[_index][2].split("&");
                rbnChoiceA.setText(choices[0]);
                rbnChoiceB.setText(choices[1]);
                rbnChoiceC.setText(choices[2]);
                rbnChoiceD.setText(choices[3]);

                if (rbnChoiceA.getText().toString().equals(_answers[_index])) {
                    rgChoices.check(rbnChoiceA.getId());
                } else if (rbnChoiceB.getText().toString().equals(_answers[_index])) {
                    rgChoices.check(rbnChoiceB.getId());
                } else if (rbnChoiceC.getText().toString().equals(_answers[_index])) {
                    rgChoices.check(rbnChoiceC.getId());
                } else if (rbnChoiceD.getText().toString().equals(_answers[_index])){
                    rgChoices.check(rbnChoiceD.getId());
                }

            break;
        }

        if (_index == 0) {
            btnPrevious.setVisibility(View.INVISIBLE);
        } else {
            btnPrevious.setVisibility(View.VISIBLE);
        }

        if (_index == _questionCount - 1) {
            btnNext.setText("Submit");
            btnNext.setOnClickListener(submit);
        } else {
            btnNext.setText("Next");
            btnNext.setOnClickListener(next);
        }
    }

    private String getAnswer() {
        switch (_questionType) {
            case "Identification":
                return txtAnswer.getText().toString();
            case "Boolean":
                return rbnChoiceA.isChecked() ? "True" : rbnChoiceB.isChecked() ? "False" : "";
            case "Multiple":
                return rbnChoiceA.isChecked() ? rbnChoiceA.getText().toString() :
                        rbnChoiceB.isChecked() ? rbnChoiceB.getText().toString() :
                                rbnChoiceC.isChecked() ? rbnChoiceC.getText().toString() :
                                        rbnChoiceD.isChecked() ? rbnChoiceD.getText().toString() : "";
        }
        return "";
    }

    private void clearFields() {
        txtAnswer.setText("");
        rgChoices.clearCheck();
    }

    private  void onBtnNext_Clicked() {
        _answers[_index] = getAnswer();
        _index++;
        setQuestion();
    }

    private void onBtnPrevious_Clicked() {
        _answers[_index] = getAnswer();
        _index--;
        setQuestion();
    }

    @Override
    public void onBackPressed() {
        if (!_hasStarted) {
            super.onBackPressed();
        } else if (_index > 0) {
            _index--;
            setQuestion();
        }
    }

    private void submitAnswer() {
        pbrLoad.setVisibility(View.VISIBLE);
        _answers[_index] = getAnswer();

        String values = "";
        for (int i = 0; i < _answers.length; i++) {
            values += '(' + _quiz + ", '" + _id + "', "  + _questions[i][0] + ", '"  + _answers[i] + "'),";
        }
        new SaveQuizDataScript(this).execute("answer", "tbl_quizanswer(Quiz_id, Student_id, Question_id, Answers)", values.substring(0, values.length() - 1));
    }

    public void onSaveAnswersTaskComplete(Boolean result) {
        if (result) {
            Toast.makeText(this, "answers uploaded!", Toast.LENGTH_SHORT).show();
            new SaveQuizDataScript(this).execute("done", "tbl_quiztaken(Quiz_id, Student_id)", '(' + _quiz + ", '" + _id + "')");
        } else {
            new AlertDialog.Builder(this).setTitle("Connection error!").setMessage("Try submiting your answers again...").show();
        }
    }

    public void onQuizInfoComplete(Boolean result) {
        if (result) {
            finish();
        }
    }
}
