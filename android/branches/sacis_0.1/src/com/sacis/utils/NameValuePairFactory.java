package com.sacis.utils;

import java.util.ArrayList;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;

public class NameValuePairFactory
{
	/**
	 * 
	 * @param names
	 * @param values
	 * @return
	 */
	public static ArrayList<NameValuePair> create(final String[] names, String[] values)
	{
		ArrayList<NameValuePair> nameValuePair = new ArrayList<NameValuePair>(names.length);
		for (int i = 0; i < names.length; i++)
		{
			nameValuePair.add(new BasicNameValuePair(names[i], values[i]));
		}
		return nameValuePair;
	}
}
