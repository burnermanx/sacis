package com.sacis.utils;

import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
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

public class DBConnector {
	private final static String SERVER_URL = "http://www.sacis.com.br/php/";

	public DBConnector() {

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
	 * Método para converter um {@link InputStream} em {@link JSONArray}
	 * 
	 * @param is
	 * @return {@link JSONArray}
	 * */
	public static JSONArray inputStreamToJson(final InputStream is)
			throws IOException, JSONException {
		String fromSb = inputStreamToString(is);
		return (fromSb.equalsIgnoreCase("null") ? null : new JSONArray(fromSb));
	}

	/**
	 * Converte InputStream pra String.
	 * */
	public static String inputStreamToString(final InputStream is)
			throws IOException {
		InputStreamReader isReader = new InputStreamReader(is, "iso-8859-1");
		BufferedReader reader = new BufferedReader(isReader, 8);
		StringBuilder sb = new StringBuilder();
		sb.append(reader.readLine() + "\n");

		String line = "0";
		while ((line = reader.readLine()) != null) {
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

	public static String fileUpload(final String login, final String filePath) {
		HttpURLConnection connection = null;
		DataOutputStream outputStream = null;
		FileInputStream fileInputStream = null;

		String urlServer = SERVER_URL + "fileUpload.php";
		String lineEnd = "\r\n";
		String twoHyphens = "--";
		String boundary = "*****";

		int bytesRead, bytesAvailable, bufferSize;
		byte[] buffer;
		int maxBufferSize = 1 * 1024 * 1024;

		try {
			fileInputStream = new FileInputStream(new File(filePath));

			URL url = new URL(urlServer);
			connection = (HttpURLConnection) url.openConnection();

			// Allow Inputs & Outputs
			connection.setDoInput(true);
			connection.setDoOutput(true);
			connection.setUseCaches(false);
			connection.setChunkedStreamingMode(0);

			// Enable POST method
			connection.setRequestMethod("POST");

			connection.setRequestProperty("Connection", "Keep-Alive");
			connection.setRequestProperty("Content-Type",
					"multipart/form-data;boundary=" + boundary);

			outputStream = new DataOutputStream(connection.getOutputStream());
			outputStream.writeBytes(twoHyphens + boundary + lineEnd);
			String res = "Content-Disposition: form-data; name=\"login\"" + login + boundary + lineEnd +
					"Content-Disposition: form-data; name=\"uploadedfile\";filename=\""
					+ filePath + "\"" + lineEnd;
			outputStream.writeBytes(res);
			outputStream.writeBytes(lineEnd);

			bytesAvailable = fileInputStream.available();
			bufferSize = Math.min(bytesAvailable, maxBufferSize);
			buffer = new byte[bufferSize];

			// Read file
			bytesRead = fileInputStream.read(buffer, 0, bufferSize);

			while (bytesRead > 0) {
				outputStream.write(buffer, 0, bufferSize);
				bytesAvailable = fileInputStream.available();
				bufferSize = Math.min(bytesAvailable, maxBufferSize);
				bytesRead = fileInputStream.read(buffer, 0, bufferSize);
			}

			outputStream.writeBytes(lineEnd);
			outputStream.writeBytes(twoHyphens + boundary + twoHyphens
					+ lineEnd);

			// Responses from the server (code and message)
			connection.getResponseCode();
			String serverResponseMessage = connection.getResponseMessage();

			return serverResponseMessage;
		} catch (Exception ex) {
			// Exception handling
		} finally {
			try {
				fileInputStream.close();
				outputStream.flush();
				outputStream.close();
			} catch (IOException ex) {
				// TODO proper handle exception
			}
			connection.disconnect();
		}

		return null;
	}

}
