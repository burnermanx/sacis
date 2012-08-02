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
		Intent intent = new Intent(getApplicationContext(), FileChooserActivity.class);
		addTab(TAB1, "Criptografia", intent);
		addTab(TAB2, "Descriptografia", intent);
	}
}
