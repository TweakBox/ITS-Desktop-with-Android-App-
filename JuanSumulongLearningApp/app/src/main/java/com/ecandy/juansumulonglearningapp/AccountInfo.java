package com.ecandy.juansumulonglearningapp;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;

/**
 * Created by TweakBox on 18/09/2016.
 */
public class AccountInfo {
    private  String _id;
    public void SetId(String id) {
        _id = id;
    }
    public String GetId() {
        return _id;
    }

    private  String _lastname;
    public void SetLastname(String lastname) {
        _lastname = lastname;
    }
    public String GetLastname() {
        return _lastname;
    }

    private  String _firstname;
    public void SetFirstname(String firstname) {
        _firstname = firstname;
    }
    public String GetFirstname() {
        return _firstname;
    }

    private  String _middlename;
    public void SetMiddlename(String middlename) {
        _middlename = middlename;
    }
    public String GetMiddlename() {
        return _middlename;
    }

    private Bitmap _avatar;
    public void SetAvatar(Bitmap avatar) { _avatar = avatar; }
    public Bitmap GetAvatar() { return _avatar; }

    private Dashboard _caller;

    public AccountInfo(Dashboard caller, String type, String id) {
        _caller = caller;
        FetchUserInfoScript fui = new FetchUserInfoScript(this);
        fui.execute(type, id);
        SetId(id);
    }

    public void onBackgroundTaskComplete(String result) {
        if (result != "Error") {
            String[] array = result.split(",");

            SetLastname(array[0]);
            SetFirstname(array[1]);
            SetMiddlename(array[2]);
            byte[] data = array[3].getBytes();
            SetAvatar(BitmapFactory.decodeByteArray(data, 0, data.length));

            _caller.onBackgroundProccessFinished();
        }
    }
}
