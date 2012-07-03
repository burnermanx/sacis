package br.com.sacis.activity;

import br.com.sacis.R;
import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;

public class SacisActivity extends Activity
{

	/** Called when the activity is first created. */
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.main);
	}

	/**
	 * Ação ao clicar no botão de sistema administrador.
	 * */
	public void showAdminView(View view)
	{
		Intent sysAdminIntent = new Intent(view.getContext(),
				AdminActivity.class);
		startActivityForResult(sysAdminIntent, 0);
	}

	/**
	 * Ação ao clicar no botão de sistema usuario.
	 * 
	 * @param view
	 */
	public void showUserLoginView(View view)
	{
		Intent userLoginIntent = new Intent(view.getContext(),
				UserLoginActivity.class);
		startActivityForResult(userLoginIntent, 0);
	}
}