package br.com.sacis.crypto;

import java.security.spec.AlgorithmParameterSpec;
import java.util.Random;

import javax.crypto.Cipher;
import javax.crypto.spec.IvParameterSpec;
import javax.crypto.spec.SecretKeySpec;

public class SymmetricCipher
{
	/**
	 * 
	 * @param inputBytes
	 * @param ivBytes
	 * @param keyBytes
	 * @return
	 * @throws Exception
	 */
	public static byte[] encrypt(byte[] inputBytes, byte[] ivBytes,
			byte[] keyBytes, char[] password) throws Exception
	{
		AlgorithmParameterSpec ivSpec = new IvParameterSpec(ivBytes);
		SecretKeySpec newKey = new SecretKeySpec(keyBytes, "AES");
		Cipher cipher = Cipher.getInstance("AES/CBC/PKCS5Padding");
		cipher.init(Cipher.ENCRYPT_MODE, newKey, ivSpec);
		return cipher.doFinal(inputBytes);
	}

	/**
	 * 
	 * @param inputBytes
	 * @param ivBytes
	 * @param keyBytes
	 * @return
	 * @throws Exception
	 */
	public static byte[] decrypt(byte[] inputBytes, byte[] ivBytes,
			byte[] keyBytes) throws Exception
	{
		AlgorithmParameterSpec ivSpec = new IvParameterSpec(ivBytes);
		SecretKeySpec newKey = new SecretKeySpec(keyBytes, "AES");
		Cipher cipher = Cipher.getInstance("AES/CBC/PKCS5Padding");
		cipher.init(Cipher.DECRYPT_MODE, newKey, ivSpec);
		return cipher.doFinal(inputBytes);
	}
	
	/**
	 * Gera uma chave randomica.
	 * @return
	 */
	public static byte[] generateKey()
	{
		Random random = new Random();
		StringBuilder key = new StringBuilder();
		for (int i = 0; i < 32; i++)
		{
			MersenneTwister mt = new MersenneTwister(random.nextLong());
			int genRandom = mt.next(32);
			key.append(genRandom);
		}
		
		return key.toString().getBytes();
	}
	
}
