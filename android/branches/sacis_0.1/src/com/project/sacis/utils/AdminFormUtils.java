package com.project.sacis.utils;

import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;

import android.util.Log;

/**
 * Proposito da classe: Classe respons�vel por validar os dados do formul�rio do
 * administrador
 * 
 * @author Davi - since 30/01/2012
 */
public class AdminFormUtils {

	public AdminFormUtils() {

	}

	/**
	 * M�todo para validar os dados dos campos do formul�rio.
	 * 
	 * @return true se os dados est�o v�lidos.
	 * */
	public static boolean isDataValid() {
		return true;
	}

	/**
	 * M�todo para verificar se o usu�rio j� existe no banco de dados.
	 * @param userName - login do usu�rio
	 * @return {@link Boolean}
	 * */
	public static boolean isUserExist(final String userName) {
		ArrayList<NameValuePair> dataToSend = new ArrayList<NameValuePair>(1);
		dataToSend.add(new BasicNameValuePair("username", userName));
		try {
			InputStream inputStreamFromCheckUser = DBConnectorUtils.sendData(
					dataToSend, "checkUser.php");
			if (inputStreamFromCheckUser != null) {
				return true;
			}
		} catch (IOException ex) {
			Log.e("[DBConnector]", ex.getMessage(), ex);
		}
		return false;
	}
}
