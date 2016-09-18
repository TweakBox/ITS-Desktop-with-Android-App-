package com.ecandy.juansumulonglearningapp;

import android.app.AlertDialog;
import android.content.Context;
import android.content.Intent;
import android.os.AsyncTask;
import android.webkit.HttpAuthHandler;
import android.widget.Toast;

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
        String webserver = "http://192.168.0.13/its/";

        if (params[0] == "login") {
            try {
                URL url = new URL(webserver + "login.php");
                HttpURLConnection urlConnection = (HttpURLConnection) url.openConnection();
                urlConnection.setRequestMethod("POST");
                urlConnection.setDoOutput(true);
                urlConnection.setDoInput(true);

                OutputStream outstream = urlConnection.getOutputStream();
                BufferedWriter buffwriter = new BufferedWriter(new OutputStreamWriter(outstream, "UTF-8"));

                String postData = URLEncoder.encode("userid", "UTF-8") + '=' + URLEncoder.encode(params[1], "UTF-8");
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

                if (!result.startsWith("!")) {
                    String[] array = result.split(",");
                    if (Integer.parseInt(array[1]) < 5) {
                        if (array[0] == params[2]) {
                            return new String[] { array[2], array[3] };
                        }
                        else {
                            //update
                        }
                    }
                } else {
                    return null;
                }


            } catch (MalformedURLException e) {
                return null;
            } catch (IOException e) {
                return null;
            }
        }

        return "Error";
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
            Toast.makeText(((Login)context), "Wrong input! Check your User ID and/or Password!", Toast.LENGTH_LONG).show();
        }

    }

    @Override
    protected void onProgressUpdate(Void... values) {
        super.onProgressUpdate(values);
    }
}
