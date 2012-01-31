package com.project.sacis.utils;

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

public class DBConnectorUtils {
	private final static String SERVER_URL = "http://www.sacis.com.br/";

	public DBConnectorUtils() {

	}

	/**
	 * M�todo para enviar o request http para o site e obter o resultado de
	 * acordo com o filename passado.
	 * 
	 * @param data
	 * @param fileName
	 * @return {@link JSONArray}
	 * 
	 * */
	public static InputStream sendData(ArrayList<NameValuePair> data,
			final String fileName) throws IOException {
		try {
			String server = SERVER_URL + fileName;
			HttpClient httpClient = new DefaultHttpClient();
			HttpPost httpPost = new HttpPost(server);
			httpPost.setEntity(new UrlEncodedFormEntity(data));
			HttpResponse response = httpClient.execute(httpPost);
			return response.getEntity().getContent();
		} catch (IOException ex) {
			throw ex;
		} 
	}

	/**
	 * M�todo para converter um {@link InputStream} em {@link JSONArray}
	 * @param is
	 * @return {@link JSONArray}
	 * */
	public static JSONArray inputStreamToJson(final InputStream is)
			throws IOException, JSONException {
		BufferedReader reader = new BufferedReader(new InputStreamReader(is,
				"iso-8859-1"), 8);
		StringBuilder sb = new StringBuilder();

		sb.append(reader.readLine() + "\n");

		String line = "0";
		while ((line = reader.readLine()) != null) {
			sb.append(line + "\n");
		}
		is.close();
		return new JSONArray(sb.toString());
	}
}
