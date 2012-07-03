package br.com.sacis.model;

/**
 * Proposito da classe:
 * TODO: explicar proposito da classe
 *
 * @author Davi - since 02/07/2012
 */
public class Header
{
	private String from;
	
	private String to;
	
	private String subject;

	/**
	 * 
	 */
	public Header()
	{
	}

	/**
	 * @param from
	 * @param to
	 * @param subject
	 */
	public Header(String from, String to, String subject)
	{
		this.from = from;
		this.to = to;
		this.subject = subject;
	}

	/**
	 * @return the from
	 */
	public String getFrom()
	{
		return from;
	}

	/**
	 * @param from the from to set
	 */
	public void setFrom(String from)
	{
		this.from = from;
	}

	/**
	 * @return the to
	 */
	public String getTo()
	{
		return to;
	}

	/**
	 * @param to the to to set
	 */
	public void setTo(String to)
	{
		this.to = to;
	}

	/**
	 * @return the subject
	 */
	public String getSubject()
	{
		return subject;
	}

	/**
	 * @param subject the subject to set
	 */
	public void setSubject(String subject)
	{
		this.subject = subject;
	}
	
}
