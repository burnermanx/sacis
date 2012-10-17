package br.com.sacis.crypto;

import java.security.MessageDigest;
import java.security.spec.AlgorithmParameterSpec;

import javax.crypto.Cipher;
import javax.crypto.spec.IvParameterSpec;
import javax.crypto.spec.SecretKeySpec;

public class SymmetricCipher
{
	private static final String CIPHER_TRANSFORMATION = "AES/CBC/PKCS5Padding";
	
	private static final String CIPHER_ALGORITHM = "AES";
	
	private static final String MESSAGE_DIGEST_ALGORITHM = "SHA-256";
	
	// http://stackoverflow.com/questions/2090765/encryption-compatable-between-android-and-c-sharp
	/**
	 * 
	 * @param inputBytes
	 * @param ivBytes
	 * @param passphrase
	 * @return
	 * @throws Exception
	 */
	public static byte[] encrypt(byte[] inputBytes, byte[] ivBytes,
			String passphrase) throws Exception
	{
		byte[] keyBytes = digest(passphrase);
		SecretKeySpec secretKey = new SecretKeySpec(keyBytes, CIPHER_ALGORITHM);
		AlgorithmParameterSpec ivSpec = new IvParameterSpec(ivBytes);
		
		Cipher cipher = Cipher.getInstance(CIPHER_TRANSFORMATION);
		cipher.init(Cipher.ENCRYPT_MODE, secretKey, ivSpec);
		return cipher.doFinal(inputBytes);
	}

	/**
	 * 
	 * @param inputBytes
	 * @param ivBytes
	 * @param passphrase
	 * @return
	 * @throws Exception
	 */
	public static byte[] decrypt(byte[] inputBytes, byte[] ivBytes,
			String passphrase) throws Exception
	{
		byte[] keyBytes = digest(passphrase);
		SecretKeySpec secretKey = new SecretKeySpec(keyBytes, CIPHER_ALGORITHM);
		AlgorithmParameterSpec ivSpec = new IvParameterSpec(ivBytes);

		Cipher cipher = Cipher.getInstance(CIPHER_TRANSFORMATION);
		cipher.init(Cipher.DECRYPT_MODE, secretKey, ivSpec);
		return cipher.doFinal(inputBytes);
	}
	
	/**
	 * 
	 * @param text
	 * @return
	 * @throws Exception
	 */
	public static byte[] digest(String text) throws Exception
	{
		MessageDigest digest = MessageDigest.getInstance(MESSAGE_DIGEST_ALGORITHM);
		return digest.digest(text.getBytes());
	}
	
}
