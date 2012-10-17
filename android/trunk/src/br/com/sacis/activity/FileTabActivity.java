package br.com.sacis.activity;

import android.content.Intent;
import android.os.Bundle;
import greendroid.app.GDTabActivity;

public class FileTabActivity extends GDTabActivity
{
	private static final String TAB1 = "crypt";
	private static final String TAB2 = "decrypt";
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setTitle("Sistema de Arquivos");
		Intent encryptIntent = new Intent(getApplicationContext(), FileChooserActivity.class);
		encryptIntent.putExtra("isCrypt", true);
		Intent decryptIntent = new Intent(getApplicationContext(), FileChooserActivity.class);
		decryptIntent.putExtra("isCrypt", false);
		addTab(TAB1, "Criptografia", encryptIntent);
		addTab(TAB2, "Descriptografia", decryptIntent);
	}
}
