package com.project.sacis.utils;

import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONArray;
import org.json.JSONException;

import android.util.Log;

/**
 * Proposito da classe: Classe respons�vel por validar os dados do formul�rio do
 * administrador
 * 
 * @author Davi - since 30/01/2012
 */
public class AdminFormUtils
{

	public AdminFormUtils()
	{

	}

	/**
	 * M�todo para validar os dados dos campos do formul�rio.
	 * 
	 * @return true se os dados est�o v�lidos.
	 * */
	public static boolean isDataValid()
	{
		return true;
	}

	/**
	 * M�todo para verificar se o usu�rio j� existe no banco de dados.
	 * 
	 * @param userName
	 *            - login do usu�rio
	 * @return {@link Boolean} se o usuario existe ou nao.
	 * @throws IOException 
	 * @throws JSONException 
	 * */
	public static boolean isUserExist(final String userName) throws IOException, JSONException
	{
		ArrayList<NameValuePair> dataToSend = new ArrayList<NameValuePair>(1);
		dataToSend.add(new BasicNameValuePair("username", userName));
		try
		{
			InputStream inputStreamFromCheckUser = DBConnectorUtils.sendData(
					dataToSend, "checkUser.php");
			if (inputStreamFromCheckUser != null)
			{
				JSONArray jsonArray = DBConnectorUtils
						.inputStreamToJson(inputStreamFromCheckUser);
				return (jsonArray == null ? false : true);
			}
		} catch (IOException ex)
		{
			Log.e("[AdminFormUtils]", ex.getMessage(), ex);
			throw ex;
		} catch (JSONException ex)
		{
			Log.e("[AdminFormUtils]", ex.getMessage(), ex);
			throw ex;
		}
		return false;
	}

	/**
	 * M�todo para inserir o usu�rio no banco de dados.
	 * 
	 * @param login
	 * @param password
	 * @param keyPath
	 * @param name
	 * @param expiration
	 * @return {@link Boolean} se ocorreu erro ou nao.
	 * */
	public static String insertUser(String login, String password,
			String keyPath, String name, String expiration)
	{
		/* { loginText, password, key, name, expiration } */
		ArrayList<NameValuePair> dataToSend = new ArrayList<NameValuePair>(4);
		dataToSend.add(new BasicNameValuePair("login", login));
		dataToSend.add(new BasicNameValuePair("password", password));
		dataToSend.add(new BasicNameValuePair("name", name));
		dataToSend.add(new BasicNameValuePair("expiration", expiration));

		try
		{
			InputStream is = DBConnectorUtils.sendData(dataToSend,
					"insertUser.php");
			return DBConnectorUtils.inputStreamToString(is);
		} catch (IOException ex)
		{
			Log.e("[DBConnector]", ex.getMessage(), ex);
		}
		return null;
	}
}
