package br.com.sacis.activity;

import android.content.Intent;
import android.os.Bundle;
import greendroid.app.GDTabActivity;

public class UserSystemActivity extends GDTabActivity
{
	private static final String TAB1 = "crypt";
    private static final String TAB2 = "decrypt";
    private static final String TAB3 = "messages";
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setTitle("Sistema do Usuario");
		Intent intent = new Intent(this, FileChooserActivity.class);
		addTab(TAB1, "Criptografar", intent);
		addTab(TAB2, "Descriptografar", intent);
		addTab(TAB3, "Mensagens", intent);
	}
}

