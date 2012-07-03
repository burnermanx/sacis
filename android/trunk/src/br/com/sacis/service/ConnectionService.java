package br.com.sacis.service;

import android.net.ConnectivityManager;
import android.net.NetworkInfo;

public class ConnectionService
{
	/**
	 * 
	 */
	public ConnectionService()
	{
	}

	/**
	 * M�todo para verificar se existe conex�o com a internet.
	 * */
	public boolean isOnline(ConnectivityManager cm)
	{
		NetworkInfo netInfo = cm.getActiveNetworkInfo();
		if (netInfo != null && netInfo.isConnectedOrConnecting())
		{
			return true;
		}
		return false;
	}
}
