package br.com.sacis;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;

import org.json.JSONArray;
import org.json.JSONException;

/**
 * Proposito da classe: TODO: explicar proposito da classe
 * 
 * @author Davi - since 02/07/2012
 */
public class InputStreamParser
{
	/**
	 * 
	 */
	public InputStreamParser()
	{
	}

	/**
	 * Método para converter um {@link InputStream} em {@link JSONArray}
	 * 
	 * @param is
	 * @return {@link JSONArray}
	 * */
	public JSONArray inputStreamToJson(final InputStream is)
			throws IOException, JSONException
	{
		String fromSb = inputStreamToString(is);
		return (fromSb.equalsIgnoreCase("null") ? null : new JSONArray(fromSb));
	}

	/**
	 * Converte InputStream pra String.
	 * */
	public String inputStreamToString(final InputStream is) throws IOException
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
}
