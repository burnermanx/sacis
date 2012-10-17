package br.com.sacis.activity;

import greendroid.app.GDActivity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import br.com.sacis.R;

public class MessagesInboxActivity extends GDActivity
{

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setActionBarContentView(R.layout.activity_messages_inbox);
		setTitle("Caixa de Entrada");
	}

	public void showComposeActivity(View view)
	{
		Intent intent = new Intent(view.getContext(),
				MessageComposerActivity.class);
		startActivityForResult(intent, 0);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu)
	{
		getMenuInflater().inflate(R.menu.activity_messages_inbox, menu);
		return true;
	}
}
