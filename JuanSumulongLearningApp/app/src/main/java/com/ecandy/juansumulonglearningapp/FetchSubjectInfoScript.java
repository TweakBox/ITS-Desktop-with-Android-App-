package com.ecandy.juansumulonglearningapp;

import android.os.AsyncTask;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.io.UnsupportedEncodingException;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLEncoder;

/**
 * Created by TweakBox on 20/09/2016.
 */
public class FetchSubjectInfoScript extends AsyncTask<String, Void, String> {

    private SubjectInfo _caller;
    FetchSubjectInfoScript(SubjectInfo caller) { _caller = caller; }
    private String type;

    @Override
    protected String doInBackground(String... params) {
        String webserver = IPNetwork.IP, postData = "";
        URL url;
        type = params[0];

        if (type.equals("Quiz")) {
            try {
                url = new URL(webserver + "fetchQuizzes.php");
                postData = URLEncoder.encode("userid", "UTF-8") + '=' + URLEncoder.encode(params[1], "UTF-8") + "&" +
                        URLEncoder.encode("subject", "UTF-8") + '=' + URLEncoder.encode(params[2], "UTF-8");
            } catch (MalformedURLException e) {
                return null;
            } catch (UnsupportedEncodingException e) {
                return null;
            }
        } else if (type.equals("Handouts")) {
            try {
                url = new URL(webserver + "fetchHandouts.php");
                postData = URLEncoder.encode("userid", "UTF-8") + '=' + URLEncoder.encode(params[1], "UTF-8") + "&" +
                        URLEncoder.encode("subject", "UTF-8") + '=' + URLEncoder.encode(params[2], "UTF-8");
            } catch (MalformedURLException e) {
                return null;
            } catch (UnsupportedEncodingException e) {
                return null;
            }
        } else if (type.equals("Homeworks")) {
            try {
                url = new URL(webserver + "fetchHomeworks.php");
                postData = URLEncoder.encode("userid", "UTF-8") + '=' + URLEncoder.encode(params[1], "UTF-8") + "&" +
                        URLEncoder.encode("subject", "UTF-8") + '=' + URLEncoder.encode(params[2], "UTF-8");
            } catch (MalformedURLException e) {
                return null;
            } catch (UnsupportedEncodingException e) {
                return null;
            }
        } else if (type.equals("Notes")) {
            try {
                url = new URL(webserver + "fetchNotes.php");
                postData = URLEncoder.encode("userid", "UTF-8") + '=' + URLEncoder.encode(params[1], "UTF-8") + "&" +
                        URLEncoder.encode("subject", "UTF-8") + '=' + URLEncoder.encode(params[2], "UTF-8");
            } catch (MalformedURLException e) {
                return null;
            } catch (UnsupportedEncodingException e) {
                return null;
            }
        } else {
            return null;
        }

        try {
            HttpURLConnection urlConnection = (HttpURLConnection) url.openConnection();
            urlConnection.setRequestMethod("POST");
            urlConnection.setDoOutput(true);
            urlConnection.setDoInput(true);

            OutputStream outstream = urlConnection.getOutputStream();
            BufferedWriter buffwriter = new BufferedWriter(new OutputStreamWriter(outstream, "UTF-8"));

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
            return null;
        } catch (IOException e) {
            return null;
        }
    }

    @Override
    protected void onPreExecute() {

    }

    @Override
    protected void onPostExecute(String result) {
        if (type.equals("Quiz")) {
            _caller.onFetchQuizzesComplete(result);
        } else if (type.equals("Handouts")) {
            _caller.onFetchHandoutsComplete(result);
        } else if (type.equals("Homeworks")) {
            _caller.onFetchHomeworksComplete(result);
        } else if (type.equals("Notes")) {
            _caller.onFetchNotesComplete(result);
        }
    }

    @Override
    protected void onProgressUpdate(Void... values) {
        super.onProgressUpdate(values);
    }
}
