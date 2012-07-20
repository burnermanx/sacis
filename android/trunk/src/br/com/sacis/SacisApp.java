package br.com.sacis;

import br.com.sacis.activity.SacisMainActivity;
import android.content.Intent;
import greendroid.app.GDApplication;

public class SacisApp extends GDApplication
{
	@Override
	public Class<?> getHomeActivityClass()
	{
		return SacisMainActivity.class;
	}
	
	@Override
	public Intent getMainApplicationIntent()
	{
		return super.getMainApplicationIntent();
	}
}
