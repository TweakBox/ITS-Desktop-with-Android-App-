package com.ecandy.juansumulonglearningapp;

import android.os.Bundle;
import android.provider.ContactsContract;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v4.app.Fragment;
import android.view.View;
import android.support.design.widget.NavigationView;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.ImageView;
import android.widget.TextView;

public class Dashboard extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener {
    private String _id;

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
        String type = data.getString("type");
        _id = data.getString("id");

        View header = (View) navigationView.inflateHeaderView(R.layout.nav_header_dashboard);

        tvwFullname = (TextView) header.findViewById(R.id.tvwFullname);
        tvwId = (TextView) header.findViewById(R.id.tvwID);
        tvwId.setText(_id);
        ivwAvatar = (ImageView) header.findViewById(R.id.imgAvatar);

        ai = new AccountInfo(this, type, _id);
    }

    public void onBackgroundProccessFinished() {
        tvwFullname.setText(ai.GetLastname() + ", " + ai.GetFirstname() + ' ' + ai.GetMiddlename().substring(0, 1) + '.');
        ivwAvatar.setImageBitmap(ai.GetAvatar());
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
        Fragment fragment = null;

        if (id == R.id.nav_announcements) {

        } else if (id == R.id.nav_subjects) {

        } else if (id == R.id.nav_changepassword) {

        } else if (id == R.id.nav_logout) {

        }

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        drawer.closeDrawer(GravityCompat.START);
        return true;
    }
}
