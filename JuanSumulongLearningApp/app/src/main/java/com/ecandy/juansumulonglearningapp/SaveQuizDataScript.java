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
 * Created by TweakBox on 22/09/2016.
 */
public class SaveQuizDataScript extends AsyncTask<String, Void, Boolean> {

    private QuizForm _caller;
    public SaveQuizDataScript(QuizForm caller) { _caller = caller; }

    private String state;

    @Override
    protected Boolean doInBackground(String... params) {
        String webserver = IPNetwork.IP;
        state = params[0];

        try {
            URL url = new URL(webserver + "saveToTable.php");
            HttpURLConnection urlConnection = (HttpURLConnection) url.openConnection();
            urlConnection.setRequestMethod("POST");
            urlConnection.setDoOutput(true);
            urlConnection.setDoInput(true);

            OutputStream outstream = urlConnection.getOutputStream();
            BufferedWriter buffwriter = new BufferedWriter(new OutputStreamWriter(outstream, "UTF-8"));

            String postData = URLEncoder.encode("table", "UTF-8") + '=' + URLEncoder.encode(params[1], "UTF-8") + "&" +
                    URLEncoder.encode("values", "UTF-8") + '=' + URLEncoder.encode(params[2], "UTF-8");
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

            return result.startsWith("!") ? false : true;
        } catch (MalformedURLException e) {
            return false;
        } catch (IOException e) {
            return false;
        }
    }

    @Override
    protected void onPreExecute() {

    }

    @Override
    protected void onPostExecute(Boolean result) {
        if (state.equals("answer")) {
            _caller.onSaveAnswersTaskComplete(result);
        } else if (state.equals("done")) {
            _caller.onQuizInfoComplete(result);
        }
    }

    @Override
    protected void onProgressUpdate(Void... values) {
        super.onProgressUpdate(values);
    }
}
