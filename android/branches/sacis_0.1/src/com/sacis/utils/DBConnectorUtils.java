package com.sacis.utils;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;

import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.HttpClient;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.json.JSONArray;
import org.json.JSONException;

import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.util.Log;

public class DBConnectorUtils
{
	private final static String SERVER_URL = "http://www.sacis.com.br/";

	public DBConnectorUtils()
	{

	}

	/**
	 * Método para enviar o request http para o site e obter o resultado de
	 * acordo com o filename passado.
	 * 
	 * @param data
	 * @param fileName
	 * @return {@link JSONArray}
	 * 
	 * */
	public static InputStream sendData(ArrayList<NameValuePair> data,
			final String fileName) throws IOException
	{
		try
		{
			String server = SERVER_URL + fileName;
			HttpClient httpClient = new DefaultHttpClient();
			HttpPost httpPost = new HttpPost(server);
			httpPost.setEntity(new UrlEncodedFormEntity(data));
			HttpResponse response = httpClient.execute(httpPost);
			return response.getEntity().getContent();
		} catch (IOException ex)
		{
			throw ex;
		}
	}

	/**
	 * Método para converter um {@link InputStream} em {@link JSONArray}
	 * 
	 * @param is
	 * @return {@link JSONArray}
	 * */
	public static JSONArray inputStreamToJson(final InputStream is)
			throws IOException, JSONException
	{
		String fromSb = inputStreamToString(is);
		return (fromSb.equalsIgnoreCase("null") ? null : new JSONArray(fromSb));
	}

	/**
	 * Converte InputStream pra String.
	 * */
	public static String inputStreamToString(final InputStream is)
			throws IOException
	{
		InputStreamReader isReader = new InputStreamReader(is, "iso-8859-1");
		BufferedReader reader = new BufferedReader(isReader, 8);
		StringBuilder sb = new StringBuilder();
		sb.append(reader.readLine() + "\n");

		String line = "0";
		while ((line = reader.readLine()) != null)
		{
			sb.append(line + "\n");
		}
		is.close();
		reader.close();
		isReader.close();
		return sb.toString().trim();		
	}
	
	/**
	 * Método para verificar se existe conexão com a internet.
	 * */
	public static boolean isOnline(ConnectivityManager cm) {
	    NetworkInfo netInfo = cm.getActiveNetworkInfo();
	    if (netInfo != null && netInfo.isConnectedOrConnecting()) {
	        return true;
	    }
	    return false;
	}	
	
}
