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
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONArray;
import org.json.JSONException;

import android.util.Log;

public class DBConnector {
	private final String SERVER_URL = "http://www.sacis.com.br/";

	public DBConnector() {

	}

	public boolean isUserExist(final String userName) {
		ArrayList<NameValuePair> dataToSend = new ArrayList<NameValuePair>(1);
		dataToSend.add(new BasicNameValuePair("username", userName));
		try {
			InputStream is = this.sendData(dataToSend, "checkUser.php");
			if (is == null)
			{
				return false;
			}
			else
			{
				inputStreamToJson(is);
				return true;
			}
			
		} catch (IOException ex) {
			Log.e("[DBConnector]", ex.getMessage(), ex);
		} catch (JSONException ex) {
			Log.e("[DBConnector]", ex.getMessage(), ex);
		}
		return false;
	}

	private InputStream sendData(ArrayList<NameValuePair> data,
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

	private JSONArray inputStreamToJson(final InputStream is) throws IOException, JSONException {
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
