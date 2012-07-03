package br.com.sacis.model;

public class FileListView
{
	private int checkbox;
	
	private String fileName;

	/**
	 * 
	 */
	public FileListView()
	{
	}

	/**
	 * @param checkbox
	 * @param fileName
	 */
	public FileListView(int checkbox, String fileName)
	{
		this.checkbox = checkbox;
		this.fileName = fileName;
	}

	/**
	 * @return the checkbox
	 */
	public int getCheckbox()
	{
		return checkbox;
	}

	/**
	 * @param checkbox the checkbox to set
	 */
	public void setCheckbox(int checkbox)
	{
		this.checkbox = checkbox;
	}

	/**
	 * @return the fileName
	 */
	public String getFileName()
	{
		return fileName;
	}

	/**
	 * @param fileName the fileName to set
	 */
	public void setFileName(String fileName)
	{
		this.fileName = fileName;
	}
	
	
}
