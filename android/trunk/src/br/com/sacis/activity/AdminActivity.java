package br.com.sacis.activity;

import greendroid.app.GDActivity;

import java.io.IOException;

import org.json.JSONException;

import android.app.ProgressDialog;
import android.content.Intent;
import android.net.ConnectivityManager;
import android.net.Uri;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.EditText;
import br.com.sacis.AdminFormValidator;
import br.com.sacis.R;
import br.com.sacis.crypto.Hash;
import br.com.sacis.model.InsertUserParameter;
import br.com.sacis.service.ConnectionService;
import br.com.sacis.service.ToastService;
import br.com.sacis.service.UserService;

/**
 * Proposito da classe: TODO: explicar proposito da classe
 * 
 * @author Davi - since 25/01/2012
 */
public class AdminActivity extends GDActivity
{

	private final int AttachFileRequestCode = 0;

	private ProgressDialog progressDialog;

	private SendDataTask sendData;

	/** Called when the activity is first created. */
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setActionBarContentView(R.layout.sys_admin);
		setTitle("Cadastro de Usuario");
		getKeyEditText().setKeyListener(null);
	}

	/** Called when the activity is going to be destroyed. */
	@Override
	public void onPause()
	{
		super.onPause();
		if (progressDialog != null)
		{
			progressDialog.dismiss();
		}
		if (sendData != null)
		{
			sendData.cancel(true);
			sendData = null;
		}
	}

	/**
	 * A��o ao clicar no bot�o de enviar os dados.
	 * */
	public void sendInfoToServer(View view)
	{
		AdminFormValidator validator = new AdminFormValidator();
		if (validator.isDataValid())
		{
			String loginText = getLoginEditText().getText().toString();
			String password = new Hash().makeHash(getPasswordEditText().getText().toString());
			String key = getKeyEditText().getText().toString();
			String name = getNameEditText().getText().toString();
			ConnectivityManager cm = (ConnectivityManager) getSystemService(CONNECTIVITY_SERVICE);
			if (new ConnectionService().isOnline(cm))
			{
				String[] params = { loginText, password, key, name };
				sendData = new SendDataTask();
				sendData.execute(params);
			} else
			{
				makeToast("Sem conex�o com a internet!");
			}
		} else
		{
			makeToast("Dados inv�lidos!");
		}
	}

	private void makeToast(final String toastMessage)
	{
		ToastService.makeToast(getApplicationContext(), toastMessage);
	}

	/**
	 * A��o ao clicar no bot�o de escolher a chave.
	 * */
	public void getKeyFile(View view)
	{
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
			Intent intent)
	{
		if (isFileChooseOk(requestCode, resultCode))
		{
			Uri uri = intent.getData();
			if (uri != null)
			{
				String path = uri.getPath();
				getKeyEditText().setText(path);
			}
		}
	}

	/**
	 * Verifica se a requisi��o para escolher o arquivo foi concluida com
	 * sucesso.
	 * 
	 * @param requestCode
	 * @param resultCode
	 * @return {@link Boolean}
	 * */
	private boolean isFileChooseOk(final int requestCode, final int resultCode)
	{
		return (requestCode == AttachFileRequestCode && resultCode == RESULT_OK);
	}

	/**
	 * Obt�m a editText da chave.
	 * 
	 * @return {@link EditText}
	 * */
	private EditText getKeyEditText()
	{
		return (EditText) this.findViewById(R.id.keyEditText);
	}

	/**
	 * Obt�m a editText do login.
	 * 
	 * @return {@link EditText}
	 * */
	private EditText getLoginEditText()
	{
		return (EditText) this.findViewById(R.id.loginEditText);
	}

	/**
	 * Obt�m a editText do password.
	 * 
	 * @return {@link EditText}
	 * */
	private EditText getPasswordEditText()
	{
		return (EditText) this.findViewById(R.id.passwordEditText);
	}

	/**
	 * Obt�m a editText do nome.
	 * 
	 * @return {@link EditText}
	 * */
	private EditText getNameEditText()
	{
		return (EditText) this.findViewById(R.id.nameEditText);
	}

	/**
	 * Classe para executar em paralelo o envio.
	 **/
	private class SendDataTask extends AsyncTask<String, String, Boolean>
	{
		@Override
		protected void onPreExecute()
		{
			progressDialog = ProgressDialog.show(AdminActivity.this,
					"Enviando dados", "Verificando login...", true);
		}

		@Override
		protected Boolean doInBackground(String... params)
		{
			/* { loginText, password, key, name } */
			boolean userExist;
			try
			{
				UserService service = new UserService();
				userExist = service.isUserRegistered(params[0]);
				if (userExist)
				{
					return false;
				} else
				{
					publishProgress("Enviando dados...");
					InsertUserParameter p = new InsertUserParameter(params[0],
							params[1], params[2], params[3]);
					String response = service.insertUser(p);
					System.out.println(response);
					return true;
				}
			} catch (IOException ex)
			{
				Log.e("[DBConnector]", ex.getMessage(), ex);
			} catch (JSONException ex)
			{
				Log.e("[DBConnector]", ex.getMessage(), ex);
			}
			return false;
		}

		@Override
		protected void onProgressUpdate(String... value)
		{
			updateDialogMessage(value[0]);
		}

		@Override
		protected void onPostExecute(Boolean response)
		{
			progressDialog.dismiss();
			progressDialog = null;
			if (!response)
			{
				makeToast("Login j� existe, tente novamente!");
			}
		}

		private void updateDialogMessage(final String message)
		{
			progressDialog.setMessage(message);
		}
	}
}
