package com.ecandy.juansumulonglearningapp;

import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.view.View;
import android.support.design.widget.NavigationView;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.MenuItem;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

public class Dashboard extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener {
    private String _id;
    private String type;

    private TextView tvwFullname, tvwId;
    private ImageView ivwAvatar;
    private AccountInfo ai;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_dashboard);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
                this, drawer, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close);
        drawer.setDrawerListener(toggle);
        toggle.syncState();

        NavigationView navigationView = (NavigationView) findViewById(R.id.nav_view);
        navigationView.setNavigationItemSelectedListener(this);

        Bundle data = getIntent().getExtras();
        type = data.getString("type");
        _id = data.getString("id");

        View header = (View) navigationView.inflateHeaderView(R.layout.nav_header_dashboard);

        tvwFullname = (TextView) header.findViewById(R.id.tvwFullname);
        tvwId = (TextView) header.findViewById(R.id.tvwID);
        tvwId.setText(_id);
        ivwAvatar = (ImageView) header.findViewById(R.id.imgAvatar);

        Fragment fragment = null;
        try {
            fragment = (Fragment) Announcements.class.newInstance();
        } catch (Exception e) {
            e.printStackTrace();
        }

        fragment.setArguments(data);
        FragmentManager fm = getSupportFragmentManager();
        fm.beginTransaction().replace(R.id.flContent, fragment).commit();

        ai = new AccountInfo(this, type, _id);
    }

    public void onBackgroundProccessFinished() {
        if (ai.GetLastname() != null) {
            tvwFullname.setText(ai.GetLastname() + ", " + ai.GetFirstname() + ' ' + ai.GetMiddlename().substring(0, 1) + '.');
            ivwAvatar.setImageBitmap(ai.GetAvatar());
        }
        else {
            Toast.makeText(this, "Error fetching user info!", Toast.LENGTH_SHORT).show();
        }
    }

    @Override
    public void onBackPressed() {
        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        if (drawer.isDrawerOpen(GravityCompat.START)) {
            drawer.closeDrawer(GravityCompat.START);
        } else {
            super.onBackPressed();
        }
    }

    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(MenuItem item) {
        // Handle navigation view item clicks here.
        int id = item.getItemId();
        boolean startActivity = false;

        Fragment fragment = null;
        Class _class = null;
        Intent i = new Intent();
        Bundle data = new Bundle();
        data.putString("id", _id);

        switch (id) {
            case R.id.nav_announcements: {
                _class = Announcements.class;
                setTitle("Announcements");
                break;
            }
            case R.id.nav_subjects: {
                _class = Subjects.class;
                data.putString("type", type);
                setTitle("Subjects");
                break;
            }
            case R.id.nav_changepassword: {
                startActivity = true;
                _class = ChangePasswordActivity.class;
                break;
            }
            case R.id.nav_logout: {
                i = new Intent(this, Login.class);
                i.putExtra("id", _id);
                startActivity(i);
                finish();

                DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
                drawer.closeDrawer(GravityCompat.START);
                return true;
            }
        }

        if (!startActivity) {
            try {
                fragment = (Fragment) _class.newInstance();
            } catch (Exception e) {
                e.printStackTrace();
            }

            fragment.setArguments(data);
            FragmentManager fm = getSupportFragmentManager();
            fm.beginTransaction().replace(R.id.flContent, fragment).commit();
        } else {
            i = new Intent(this, _class);
            i.putExtra("id", _id);
            startActivity(i);
        }

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        drawer.closeDrawer(GravityCompat.START);
        return true;
    }
}
