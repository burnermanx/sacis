package br.com.sacis.activity;

import br.com.sacis.R;
import greendroid.app.GDActivity;
import greendroid.graphics.drawable.ActionBarDrawable;
import greendroid.widget.NormalActionBarItem;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;

public class SacisMainActivity extends GDActivity
{
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		addActionBarItem(getActionBar().newActionBarItem(
				NormalActionBarItem.class).setDrawable(
				new ActionBarDrawable(this, R.drawable.ic_action_bar_info)));
		setActionBarContentView(R.layout.main);
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
