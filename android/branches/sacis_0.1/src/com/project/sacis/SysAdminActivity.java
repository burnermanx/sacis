package com.project.sacis;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Intent;
import android.net.Uri;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.view.View;
import android.widget.EditText;

import com.project.sacis.utils.AdminFormUtils;
import com.project.sacis.utils.ToastUtils;

/**
 * Proposito da classe: TODO: explicar proposito da classe
 * 
 * @author Davi - since 25/01/2012
 */
public class SysAdminActivity extends Activity {

	private final int AttachFileRequestCode = 0;

	private ProgressDialog progressDialog;

	private SendDataTask sendData;

	/** Called when the activity is first created. */
	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.sys_admin);
		getKeyEditText().setKeyListener(null);
	}

	/** Called when the activity is going to be destroyed. */
	@Override
	public void onPause() {
		super.onPause();
		if (progressDialog != null) {
			progressDialog.dismiss();
		}
		if (sendData != null) {
			sendData.cancel(true);
			sendData = null;
		}
	}

	/**
	 * Ação ao clicar no botão de enviar os dados.
	 * */
	public void sendInfoToServer(View view) {
		if (AdminFormUtils.isDataValid()) {
			String loginText = getLoginEditText().getText().toString();
			progressDialog = ProgressDialog.show(this, "Enviando dados",
					"Enviando...", true);
			//por enquanto so enviando os dados do login e verificando isso
			String[] params = { loginText };
			sendData = new SendDataTask();
			sendData.execute(params);
		}
	}

	private void makeToast(final String toastMessage) {
			ToastUtils.makeToast(this, toastMessage);
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

	/**
	 * Verifica se a requisição para escolher o arquivo foi concluida com
	 * sucesso.
	 * 
	 * @param requestCode
	 * @param resultCode
	 * @return {@link Boolean}
	 * */
	private boolean isFileChooseOk(final int requestCode, final int resultCode) {
		return (requestCode == AttachFileRequestCode && resultCode == RESULT_OK);
	}

	/**
	 * Obtém a editText da chave.
	 * 
	 * @return {@link EditText}
	 * */
	private EditText getKeyEditText() {
		return (EditText) this.findViewById(R.id.keyEditText);
	}

	/**
	 * Obtém a editText do login.
	 * 
	 * @return {@link EditText}
	 * */
	private EditText getLoginEditText() {
		return (EditText) this.findViewById(R.id.loginEditText);
	}

	private class SendDataTask extends AsyncTask<String, Void, Boolean> {
		@Override
		protected Boolean doInBackground(String... params) {
			// Por enquanto só testou checando se existe o usuário mas aqui
			// deveria ficar a lógica de checar
			// o usuário, e se não existir, enviar os dados e a chave pro banco
			// provavel que mude o retorno desse metodo tambem
			return AdminFormUtils.isUserExist(params[0]);
		}

		@Override
		protected void onPostExecute(Boolean isUserExist) {
			progressDialog.dismiss();
			progressDialog = null;
			if (isUserExist) {
				makeToast("Login já existe, tente novamente!");
			}
			else
			{
				makeToast("Login não existe!");
			}
		}
	}
}
