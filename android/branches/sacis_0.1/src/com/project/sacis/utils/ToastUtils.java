package com.project.sacis.utils;

import android.app.Activity;
import android.widget.Toast;

public class ToastUtils {
	
	public static void makeToast(final Activity activity,final String message)
	{
		Toast.makeText(activity, message, Toast.LENGTH_LONG).show();
	}
}
