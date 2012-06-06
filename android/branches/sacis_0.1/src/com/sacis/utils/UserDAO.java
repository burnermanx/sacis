package com.sacis.utils;

import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;

import org.apache.http.NameValuePair;
import org.json.JSONArray;
import org.json.JSONException;

import android.util.Log;

/**
 * 
 * @author Davi - since 30/01/2012
 */
public class UserDAO
{

	public UserDAO()
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
	public static boolean isUserExist(final String userName)
			throws IOException, JSONException
	{
		String[] names = { "username" };
		String[] values = { userName };
		ArrayList<NameValuePair> dataToSend = NameValuePairFactory.create(
				names, values);
		try
		{
			InputStream inputStreamFromCheckUser = DBConnector.sendData(
					dataToSend, "checkUser.php");
			if (inputStreamFromCheckUser != null)
			{
				JSONArray jsonArray = DBConnector
						.inputStreamToJson(inputStreamFromCheckUser);
				return (jsonArray == null ? false : true);
			}
		} catch (IOException ex)
		{
			Log.e("[UserDAO](isUserExist)", ex.getMessage(), ex);
			throw ex;
		} catch (JSONException ex)
		{
			Log.e("[UserDAO](isUserExist)", ex.getMessage(), ex);
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
		String[] names = { "login", "password", "name", "expiration" };
		String[] values = { login, password, name, expiration };
		ArrayList<NameValuePair> dataToSend = NameValuePairFactory.create(
				names, values);

		try
		{
			InputStream is = DBConnector.sendData(dataToSend, "insertUser.php");
			return DBConnector.inputStreamToString(is);
		} catch (IOException ex)
		{
			Log.e("[UserDAO](insertUser)", ex.getMessage(), ex);
		}
		return null;
	}

	/**
	 * Metodo para verificar se o usuario e password passado conferem.
	 * 
	 * @param login
	 * @param password
	 * @return
	 */
	public static boolean checkUserAndPass(final String login,
			final String password)
	{
		String[] names = { "login", "password" };
		String[] values = { login, password };
		ArrayList<NameValuePair> dataToSend = NameValuePairFactory.create(
				names, values);
		try
		{
			InputStream is = DBConnector.sendData(dataToSend,
					"checkUserPass.php");
			if (is != null)
			{
				JSONArray jsonArray = DBConnector.inputStreamToJson(is);
				return (jsonArray == null ? false : true);
			}
		} catch (IOException ex)
		{
			Log.e("[UserDAO](checkUserAndPass)", ex.getMessage(), ex);
		} catch (JSONException ex)
		{
			Log.e("[UserDAO](checkUserAndPass)", ex.getMessage(), ex);
		}
		return false;
	}
}
