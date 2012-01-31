package com.project.sacis.utils;

import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;

import android.util.Log;

/**
 * Proposito da classe: Classe responsável por validar os dados do formulário do
 * administrador
 * 
 * @author Davi - since 30/01/2012
 */
public class AdminFormUtils {

	public AdminFormUtils() {

	}

	/**
	 * Método para validar os dados dos campos do formulário.
	 * 
	 * @return true se os dados estão válidos.
	 * */
	public static boolean isDataValid() {
		return true;
	}

	/**
	 * Método para verificar se o usuário já existe no banco de dados.
	 * @param userName - login do usuário
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
