package com.ecandy.juansumulonglearningapp;


import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.LinearLayout;

/**
 * A simple {@link Fragment} subclass.
 */
public class Subjects extends Fragment {
    private String _id;
    private String _type;

    private View view;

    public Subjects() {
        // Required empty public constructor
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        Bundle data = getArguments();
        _id = data.getString("id");

        FetchSubjectsScript fss = new FetchSubjectsScript(this);
        fss.execute("Quiz", _id);

        // Inflate the layout for this fragment
        return view = inflater.inflate(R.layout.fragment_subjects, container, false);
    }

    public void onTaskComplete(String result) {
        if (result != "") {
            String[] lines = result.split(";");

            for (int i = 0; i < lines.length; i++) {
                Button btn = new Button(view.getContext());
                btn.setBackgroundColor(getResources().getColor(R.color.colorAccent));
                btn.setTextColor(Color.WHITE);
                btn.setLayoutParams(new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.WRAP_CONTENT));
                btn.setTag(lines[i].split(",")[0]);
                btn.setText(lines[i].split(",")[1]);

                btn.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        onSubjectClick(v.getTag());
                    }
                });

                LinearLayout vll = ((LinearLayout) view.findViewById(R.id.vllSubjectList));
                vll.addView(btn);
            }
        }
    }

    private void onSubjectClick(Object tag) {
        Intent i = new Intent(view.getContext(), SubjectInfo.class);
        i.putExtra("id", _id);
        i.putExtra("subject", tag.toString());
        view.getContext().startActivity(i);
    }

}
