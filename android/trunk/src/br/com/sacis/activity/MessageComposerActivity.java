package br.com.sacis.activity;

import greendroid.app.GDActivity;
import android.os.Bundle;
import android.view.Menu;
import br.com.sacis.R;

public class MessageComposerActivity extends GDActivity {

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setActionBarContentView(R.layout.activity_message_composer);
        setTitle("Nova Mensagem");
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.activity_message_composer, menu);
        return true;
    }
}
