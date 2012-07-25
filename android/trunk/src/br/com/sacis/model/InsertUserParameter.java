package br.com.sacis.model;

/**
 * Proposito da classe: TODO: explicar proposito da classe
 * 
 * @author Davi - since 02/07/2012
 */
public class InsertUserParameter
{
	/**
	 * 
	 */
	private String login;
	/**
	 * 
	 */
	private String password;
	/**
	 * 
	 */
	private String keyPath;
	/**
	 * 
	 */
	private String name;
	/**
	 * 
	 */
	/**
	 * 
	 */
	public InsertUserParameter(String login, String password, String keyPath,
			String name)
	{
		this.login = login;
		this.password = password;
		this.keyPath = keyPath;
		this.name = name;
	}

	/**
	 * @return the login
	 */
	public String getLogin()
	{
		return login;
	}

	/**
	 * @param login
	 *            the login to set
	 */
	public void setLogin(String login)
	{
		this.login = login;
	}

	/**
	 * @return the password
	 */
	public String getPassword()
	{
		return password;
	}

	/**
	 * @param password
	 *            the password to set
	 */
	public void setPassword(String password)
	{
		this.password = password;
	}

	/**
	 * @return the keyPath
	 */
	public String getKeyPath()
	{
		return keyPath;
	}

	/**
	 * @param keyPath
	 *            the keyPath to set
	 */
	public void setKeyPath(String keyPath)
	{
		this.keyPath = keyPath;
	}

	/**
	 * @return the name
	 */
	public String getName()
	{
		return name;
	}

	/**
	 * @param name
	 *            the name to set
	 */
	public void setName(String name)
	{
		this.name = name;
	}

}