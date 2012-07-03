package br.com.sacis.service;

import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;

import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.HttpClient;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.json.JSONArray;

public class DataSender
{
	private final static String SERVER_URL = "http://www.sacis.com.br/";

	public DataSender()
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
	public InputStream sendData(ArrayList<NameValuePair> data,
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

}
