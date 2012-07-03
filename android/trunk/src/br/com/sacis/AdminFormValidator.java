package br.com.sacis;

import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONArray;
import org.json.JSONException;

import br.com.sacis.model.InsertUserParameter;
import br.com.sacis.service.DataSender;

import android.util.Log;

/**
 * Proposito da classe: Classe respons�vel por validar os dados do formul�rio do
 * administrador
 * 
 * @author Davi - since 30/01/2012
 */
public class AdminFormValidator
{
	private DataSender dataSender;

	private InputStreamParser parser;

	public AdminFormValidator()
	{
		this.dataSender = new DataSender();
		this.parser = new InputStreamParser();
	}

	/**
	 * M�todo para validar os dados dos campos do formul�rio.
	 * 
	 * @return true se os dados est�o v�lidos.
	 * */
	public boolean isDataValid()
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
	public boolean isUserRegistered(final String userName) throws IOException,
			JSONException
	{
		ArrayList<NameValuePair> dataToSend = createUserRegisteredData(userName);
		try
		{
			InputStream inputStreamFromCheckUser = dataSender.sendData(
					dataToSend, "checkUser.php");
			if (inputStreamFromCheckUser != null)
			{
				JSONArray jsonArray = parser
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
	 * @param userName
	 * @return
	 */
	private ArrayList<NameValuePair> createUserRegisteredData(
			final String userName)
	{
		ArrayList<NameValuePair> dataToSend = new ArrayList<NameValuePair>(1);
		dataToSend.add(new BasicNameValuePair("username", userName));
		return dataToSend;
	}

	/**
	 * M�todo para inserir o usu�rio no banco de dados.
	 * 
	 * @param parameterObject
	 *            TODO
	 * 
	 * @return {@link Boolean} se ocorreu erro ou nao.
	 * */
	public String insertUser(InsertUserParameter parameterObject)
	{
		ArrayList<NameValuePair> dataToSend = createInsertUserData(parameterObject);

		try
		{
			InputStream is = dataSender.sendData(dataToSend, "insertUser.php");
			return parser.inputStreamToString(is);
		} catch (IOException ex)
		{
			Log.e("[DBConnector]", ex.getMessage(), ex);
		}
		return null;
	}

	/**
	 * @param parameterObject
	 * @return
	 */
	private ArrayList<NameValuePair> createInsertUserData(
			InsertUserParameter parameterObject)
	{
		ArrayList<NameValuePair> dataToSend = new ArrayList<NameValuePair>(4);
		dataToSend.add(new BasicNameValuePair("login", parameterObject
				.getLogin()));
		dataToSend.add(new BasicNameValuePair("password", parameterObject
				.getPassword()));
		dataToSend
				.add(new BasicNameValuePair("name", parameterObject.getName()));
		dataToSend.add(new BasicNameValuePair("expiration", parameterObject
				.getExpiration()));
		return dataToSend;
	}
}
