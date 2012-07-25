package br.com.sacis.service;

import android.content.Context;
import android.widget.Toast;

public class ToastService {
	
	public static void makeToast(final Context context, final String message)
	{
		Toast.makeText(context, message, Toast.LENGTH_LONG).show();
	}
}
