package com.sacis.activity;

import android.app.Activity;
import android.app.ProgressDialog;
import android.net.ConnectivityManager;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;

import com.sacis.utils.DBConnector;
import com.sacis.utils.ToastUtils;
import com.sacis.utils.UserDAO;

public class UserActivity extends Activity
{

	private ProgressDialog progressDialog;

	private SendDataTask sendData;

	/** Called when the activity is first created. */
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.user);
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
	 * 
	 * @param view
	 */
	public void sendLoginInfoToServer(View view)
	{
		String login = this.getLoginText();
		String password = this.getPasswordText();
		ConnectivityManager cm = (ConnectivityManager) getSystemService(CONNECTIVITY_SERVICE);
		if (DBConnector.isOnline(cm))
		{
			String[] params = { login, password };
			new SendDataTask().execute(params);
		}
		else
		{
			makeToast("Sem conexão com a internet!");
		}
	}

	/**
	 * 
	 * @param toastMessage
	 */
	private void makeToast(final String toastMessage)
	{
		ToastUtils.makeToast(this, toastMessage);
	}

	/**
	 * 
	 * @return
	 */
	private String getPasswordText()
	{
		return getPasswordEditText().getText().toString();
	}

	/**
	 * 
	 * @return
	 */
	private String getLoginText()
	{
		return getLoginEditText().getText().toString();
	}

	/**
	 * 
	 * @return
	 */
	private EditText getLoginEditText()
	{
		return (EditText) this.findViewById(R.id.userLoginEditText);
	}

	/**
	 * 
	 * @return
	 */
	private EditText getPasswordEditText()
	{
		return (EditText) this.findViewById(R.id.userPasswordEditText);
	}

	/**
	 * Classe para executar em paralelo o envio.
	 **/
	private class SendDataTask extends AsyncTask<String, String, Boolean>
	{
		@Override
		protected void onPreExecute()
		{
			progressDialog = ProgressDialog.show(UserActivity.this,
					"Enviando dados", "Verificando login...", true);
		}

		@Override
		protected Boolean doInBackground(String... params)
		{
			/* { login, password } */
			String login = params[0];
			String password = params[1];
			return UserDAO.checkUserAndPass(login, password);
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
				makeToast("Login não existente, tente novamente!");
			}
			else
			{
				//TODO: ir activity arquivos
			}
		}

		private void updateDialogMessage(final String message)
		{
			progressDialog.setMessage(message);
		}
	}
}
