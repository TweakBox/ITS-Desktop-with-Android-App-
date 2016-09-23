package com.ecandy.juansumulonglearningapp;

import android.app.AlertDialog;
import android.content.Context;
import android.content.Intent;
import android.os.AsyncTask;
import android.webkit.HttpAuthHandler;
import android.widget.Toast;

import com.ecandy.juansumulonglearningapp.Dashboard;
import com.ecandy.juansumulonglearningapp.Login;

import java.io.BufferedOutputStream;
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
import java.net.URLDecoder;
import java.net.URLEncoder;

/**
 * Created by TweakBox on 17/09/2016.
 */
public class LoginScript extends AsyncTask<String, Void, Object> {

    Context context;
    LoginScript(Context cx) {
        context = cx;
    }

    AlertDialog alertDialog;

    @Override
    protected Object doInBackground(String... params) {
        String webserver = IPNetwork.IP;

        if (params[0].equals("login")) {
            try {
                URL url = new URL(webserver + "login.php");
                HttpURLConnection urlConnection = (HttpURLConnection) url.openConnection();
                urlConnection.setRequestMethod("POST");
                urlConnection.setDoOutput(true);
                urlConnection.setDoInput(true);

                OutputStream outstream = urlConnection.getOutputStream();
                BufferedWriter buffwriter = new BufferedWriter(new OutputStreamWriter(outstream, "UTF-8"));

                String postData = URLEncoder.encode("userid", "UTF-8") + '=' + URLEncoder.encode(params[1], "UTF-8") + '&' +
                        URLEncoder.encode("pass", "UTF-8") + '=' + URLEncoder.encode(params[2], "UTF-8");
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

//                if (result != null && !result.startsWith("!")) { //check for error
//                    String[] array = result.split(",");
//                    if (Integer.parseInt(array[1]) < 5) { //check attempts
//                        if (array[0] == params[2]) { //check pass
//                            return new String[] { array[2], array[3] };
//                        }
//                        else { //update attempts
//                            //update
//                            String attempts = Integer.toString(Integer.parseInt(array[1]) + 1);
//
//                            url = new URL(webserver + "updateAttempts.php");
//                            urlConnection = (HttpURLConnection) url.openConnection();
//                            urlConnection.setRequestMethod("POST");
//                            urlConnection.setDoOutput(true);
//                            urlConnection.setDoInput(true);
//
//                            outstream = urlConnection.getOutputStream();
//                            buffwriter = new BufferedWriter(new OutputStreamWriter(outstream, "UTF-8"));
//
//                            postData = URLEncoder.encode("userid", "UTF-8") + '=' + URLEncoder.encode(params[1], "UTF-8") + '&' +
//                                    URLEncoder.encode("attempts", "UTF-8") + '=' + URLEncoder.encode(attempts, "UTF-8");
//                            buffwriter.write(postData);
//                            buffwriter.flush();
//                            buffwriter.close();
//                            outstream.close();
//                        }
//                    } else { //user blocked
//                        Toast.makeText(((Login)context), "Sorry, this account is locked! This account has attempted five (5) login attempts with wrong password! Please contact your adviser.", Toast.LENGTH_LONG).show();
//                    }
//                } else {
//                    return null;
//                }
                if (result != "") {
                    String[] array = result.split(",");
                    return new String[] { array[2], array[3] };
                } else {
                    return null;
                }
            } catch (MalformedURLException e) {
                return null;
            } catch (IOException e) {
                return null;
            }
        }

        return null;
    }

    @Override
    protected void onPreExecute() {
//        alertDialog = new AlertDialog.Builder(context).create();
//        alertDialog.setTitle("Login status");
    }

    @Override
    protected void onPostExecute(Object result) {
        if (result != null) {
            String[] array = (String[]) result;
            Intent i = new Intent(context, Dashboard.class);
            i.putExtra("type", array[0]);
            i.putExtra("id", array[1]);
            context.startActivity(i);
            ((Login)context).finish();
        }
        else {
            Toast.makeText(((Login)context), "Wrong input! Please try again!", Toast.LENGTH_LONG).show();
            ((Login) context).onTaskFinished();
        }

    }

    @Override
    protected void onProgressUpdate(Void... values) {
        super.onProgressUpdate(values);
    }
}
