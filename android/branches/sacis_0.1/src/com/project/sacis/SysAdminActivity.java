package com.project.sacis;

import java.io.File;
import java.net.URI;

import android.app.Activity;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;

/**
 * Proposito da classe: TODO: explicar proposito da classe
 * 
 * @author Davi - since 25/01/2012
 */
public class SysAdminActivity extends Activity {

	final int AttachFileRequestCode = 0;

	/** Called when the activity is first created. */
	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.sys_admin);
		getKeyEditText().setKeyListener(null);
	}

	/**
	 * Ação ao clicar no botão de escolher a chave.
	 * */
	public void getKeyFile(View view) {
		Intent fileChooserIntent = new Intent();
		fileChooserIntent.setAction(Intent.ACTION_GET_CONTENT);
		fileChooserIntent.setType("text/plain");
		startActivityForResult(
				Intent.createChooser(fileChooserIntent, "Selecione a chave"),
				AttachFileRequestCode);
	}

	protected void onActivityResult(int requestCode, int resultCode,
			Intent intent) {
		if (isFileChooseOk(requestCode, resultCode)) {
			Uri uri = intent.getData();
			if (uri != null) {
				String path = uri.getPath();
				EditText keyEditText = getKeyEditText();
				keyEditText.setText(path);
			}
		}
	}

	private boolean isFileChooseOk(final int requestCode, final int resultCode) {
		return (requestCode == AttachFileRequestCode && resultCode == RESULT_OK);
	}
	
	private EditText getKeyEditText()
	{
		return (EditText) this.findViewById(R.id.keyEditText);
	}
}
