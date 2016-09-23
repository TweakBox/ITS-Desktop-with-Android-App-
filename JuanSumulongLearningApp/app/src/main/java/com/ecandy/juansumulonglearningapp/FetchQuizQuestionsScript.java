package com.ecandy.juansumulonglearningapp;

import android.os.AsyncTask;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLEncoder;

/**
 * Created by TweakBox on 21/09/2016.
 */
public class FetchQuizQuestionsScript extends AsyncTask<String, Void, String> {

    private QuizForm _caller;
    FetchQuizQuestionsScript(QuizForm caller) { _caller = caller; }

    @Override
    protected String doInBackground(String... params) {
        String webserver = IPNetwork.IP;

        /*if (params[0] == "Student")*/ {
            try {
                URL url = new URL(webserver + "fetchQuizQuestions.php");
                HttpURLConnection urlConnection = (HttpURLConnection) url.openConnection();
                urlConnection.setRequestMethod("POST");
                urlConnection.setDoOutput(true);
                urlConnection.setDoInput(true);

                OutputStream outstream = urlConnection.getOutputStream();
                BufferedWriter buffwriter = new BufferedWriter(new OutputStreamWriter(outstream, "UTF-8"));

                String postData = URLEncoder.encode("quiz", "UTF-8") + '=' + URLEncoder.encode(params[0], "UTF-8");
                buffwriter.write(postData);
                buffwriter.flush();
                buffwriter.close();
                outstream.close();

                InputStream instream = urlConnection.getInputStream();
                BufferedReader buffreader = new BufferedReader(new InputStreamReader(instream, "iso-8859-1"));
                String result = "", line = "";
                while ((line = buffreader.readLine()) != null)
                    result += line;

                buffreader.close();
                instream.close();
                urlConnection.disconnect();

                return result;
            } catch (MalformedURLException e) {
                return e.getMessage();
            } catch (IOException e) {
                return e.getMessage();
            }
        }

//        return "Error";
    }

    @Override
    protected void onPreExecute() {

    }

    @Override
    protected void onPostExecute(String result) {
        _caller.onFetchQuestionsTaskComplete(result);
    }

    @Override
    protected void onProgressUpdate(Void... values) {
        super.onProgressUpdate(values);
    }
}
