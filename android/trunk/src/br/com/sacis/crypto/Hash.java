package br.com.sacis.crypto;

import java.io.UnsupportedEncodingException;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;

public class Hash
{
	private static final String EMPTY_STRING = "";
	
	public Hash()
	{
	}
	
	public String makeHash(final String text)
	{
		try
		{
			MessageDigest digester = MessageDigest.getInstance("SHA-512");
			digester.update(text.getBytes("UTF-8"));
			byte messageDigest[] = digester.digest();
			StringBuffer hexString = new StringBuffer();
			for (byte b : messageDigest)
			{
				hexString.append(String.format("%02X", b));
			}
			return hexString.toString();
		} catch (NoSuchAlgorithmException e)
		{
			e.printStackTrace();
		} catch (UnsupportedEncodingException e)
		{
			e.printStackTrace();
		}
		return EMPTY_STRING;
	}
}
