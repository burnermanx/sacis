package com.project.sacis;

import java.io.File;
import java.net.URI;

import com.project.sacis.utils.DBConnector;
import com.project.sacis.utils.ToastUtils;

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
	 * Ação ao clicar no botão de enviar os dados.
	 * */
	public void sendInfoToServer(View view)
	{
		if (isDataValid())
		{
			boolean existUser = new DBConnector().isUserExist(getLoginEditText().getText().toString());
			if (existUser)
			{
				ToastUtils.makeToast(this, "Login já existe!");
			}
		}
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
	
	/**
	 * Ao receber o resultado de uma atividade
	 * */
	protected void onActivityResult(int requestCode, int resultCode,
			Intent intent) {
		if (isFileChooseOk(requestCode, resultCode)) {
			Uri uri = intent.getData();
			if (uri != null) {
				String path = uri.getPath();
				getKeyEditText().setText(path);
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
	
	private EditText getLoginEditText()
	{
		return (EditText) this.findViewById(R.id.loginEditText);
	}
	
	/**
	 * Método para validar os dados dos campos do formulário.
	 * @return true se os dados estão válidos.
	 * */
	private boolean isDataValid()
	{
		return true;
	}
}
