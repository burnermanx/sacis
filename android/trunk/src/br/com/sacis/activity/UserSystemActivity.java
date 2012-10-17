package br.com.sacis.activity;

import br.com.sacis.R;
import greendroid.app.GDActivity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;

public class UserSystemActivity extends GDActivity
{
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setTitle("Sistema do Usuario");
		setActionBarContentView(R.layout.user_system);
	}
	
	public void showFileActivity(View view)
	{
		Intent intent = new Intent(view.getContext(), FileTabActivity.class);
		startActivityForResult(intent, 0);
	}
	
	public void showMessageActivity(View view)
	{
		Intent intent = new Intent(view.getContext(), MessagesInboxActivity.class);
		startActivityForResult(intent, 0);
	}
}

