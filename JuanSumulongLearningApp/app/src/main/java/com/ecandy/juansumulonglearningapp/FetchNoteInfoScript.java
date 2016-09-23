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
 * Created by TweakBox on 24/09/2016.
 */
public class FetchNoteInfoScript extends AsyncTask<String, Void, String> {

    private NoteInfo _caller;
    FetchNoteInfoScript(NoteInfo caller) { _caller = caller; }
    private String type;

    @Override
    protected String doInBackground(String... params) {
        String webserver = IPNetwork.IP, postData = "";
        URL url;
        type = params[0];

        if (type.equals("edit")) {
            try {
                url = new URL(webserver + "fetchNoteInfo.php");
                postData = URLEncoder.encode("type", "UTF-8") + '=' + URLEncoder.encode(params[0], "UTF-8") + "&" +
                        URLEncoder.encode("title", "UTF-8") + '=' + URLEncoder.encode(params[1], "UTF-8") + "&" +
                        URLEncoder.encode("content", "UTF-8") + '=' + URLEncoder.encode(params[2], "UTF-8") + "&" +
                        URLEncoder.encode("quiz", "UTF-8") + '=' + URLEncoder.encode(params[3], "UTF-8");
            } catch (MalformedURLException e) {
                return null;
            } catch (UnsupportedEncodingException e) {
                return null;
            }
        } else {
            try {
                url = new URL(webserver + "fetchNoteInfo.php");
                postData = URLEncoder.encode("type", "UTF-8") + '=' + URLEncoder.encode(params[0], "UTF-8") + "&" +
                        URLEncoder.encode("title", "UTF-8") + '=' + URLEncoder.encode(params[1], "UTF-8") + "&" +
                        URLEncoder.encode("content", "UTF-8") + '=' + URLEncoder.encode(params[2], "UTF-8") + "&" +
                        URLEncoder.encode("userid", "UTF-8") + '=' + URLEncoder.encode(params[3], "UTF-8") + "&" +
                        URLEncoder.encode("subject", "UTF-8") + '=' + URLEncoder.encode(params[4], "UTF-8");
            } catch (MalformedURLException e) {
                return null;
            } catch (UnsupportedEncodingException e) {
                return null;
            }
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
        }
    }

    @Override
    protected void onProgressUpdate(Void... values) {
        super.onProgressUpdate(values);
    }
}
