package br.com.sacis.activity;

import java.io.IOException;

import org.json.JSONException;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Intent;
import android.net.ConnectivityManager;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.EditText;
import br.com.sacis.R;
import br.com.sacis.service.ConnectionService;
import br.com.sacis.service.ToastService;
import br.com.sacis.service.UserService;

public class UserLoginActivity extends Activity
{
	private ProgressDialog progressDialog;
	
	private SendDataTask sendData;
	
	/** Called when the activity is first created. */
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.user_login);
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
	
	private String getLoginEditText()
	{
		return ((EditText) this.findViewById(R.id.userLoginEditText)).getText().toString();
	}
	
	private String getPasswordEditText()
	{
		return ((EditText) this.findViewById(R.id.userPasswordEditText)).getText().toString();
	}
	
	
	
	private void makeToast(final String toastMessage)
	{
		ToastService.makeToast(this, toastMessage);
	}
	
	/**
	 * Ação ao clicar no botão de enviar dados.
	 * @param view
	 */
	public void sendLoginInfoToServer(View view)
	{
		//callFileChooserActivity(view);
		String login = getLoginEditText(), password = getPasswordEditText();
		ConnectivityManager cm = (ConnectivityManager) getSystemService(CONNECTIVITY_SERVICE);
		if (new ConnectionService().isOnline(cm))
		{
			String[] params = { login, password };
			sendData = new SendDataTask();
			sendData.execute(params);
		}
		else
		{
			makeToast("Sem conexão com a internet!");
		}
	}
	
	@SuppressWarnings("unused")
	private void callFileChooserActivity(View view)
	{
		Intent intent = new Intent(view.getContext(),
				FileChooserActivity.class);
		startActivityForResult(intent, 0);
	}
	
	private class SendDataTask extends AsyncTask<String, String, Boolean>
	{
		@Override
		protected void onPreExecute()
		{
			progressDialog = ProgressDialog.show(UserLoginActivity.this,
					"Enviando dados", "Verificando login...", true);
		}
		
		
		@Override
		protected Boolean doInBackground(String... arg)
		{
			try
			{
				return new UserService().isLoginDataValid(arg[0], arg[1]);
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
		protected void onPostExecute(Boolean userExist)
		{
			progressDialog.dismiss();
			progressDialog = null;
			if (!userExist)
			{
				makeToast("Login não existente ou senha incorreta!");
			}
		}
		
	}
}
