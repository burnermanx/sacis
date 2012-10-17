package br.com.sacis.activity;

import java.io.File;
import java.util.ArrayList;
import java.util.List;

import org.apache.commons.io.FileUtils;

import android.app.ListActivity;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import br.com.sacis.R;
import br.com.sacis.crypto.SymmetricCipher;
import br.com.sacis.service.ToastService;

public class FileChooserActivity extends ListActivity
{
	private final int AttachFileRequestCode = 0;

	private ArrayAdapter<String> arrayAdapter;

	private List<String> listViewItems = new ArrayList<String>();

	private boolean isCrypt;

	private static byte[] ivBytes = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

	private static final String TEST_PASS_PHRASE = "testeDaviSacistesteDaviSacisQuat";

	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		ListView listView = getListView();
		arrayAdapter = new ArrayAdapter<String>(this,
				android.R.layout.simple_list_item_multiple_choice,
				listViewItems);
		setListAdapter(arrayAdapter);
		listView.setItemsCanFocus(false);
		listView.setChoiceMode(ListView.CHOICE_MODE_MULTIPLE);
		isCrypt = getIntent().getBooleanExtra("isCrypt", true);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu)
	{
		getMenuInflater().inflate(R.menu.filechooser_menu, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item)
	{
		switch (item.getItemId())
		{
		case R.id.menu_file_chooser:
			chooseFile();
			return true;
		case R.id.menu_file_chooser_save:
			saveFiles();
			return true;
		default:
			return super.onOptionsItemSelected(item);
		}

	}

	/**
	 * Acao ao clicar em escolher arquivo
	 */
	private void chooseFile()
	{
		// Por agora ira escolher um arquivo, sera implementada uma fileDialog
		// para contornar esse problema
		Intent fileChooserIntent = new Intent();
		fileChooserIntent.setAction(Intent.ACTION_GET_CONTENT);
		fileChooserIntent.setType("text/plain");
		startActivityForResult(
				Intent.createChooser(fileChooserIntent, "Selecione um arquivo"),
				AttachFileRequestCode);
	}

	/**
	 * Ao receber o resultado de uma atividade
	 * */
	protected void onActivityResult(int requestCode, int resultCode,
			Intent intent)
	{
		if (isFileChooseOk(requestCode, resultCode))
		{
			Uri uri = intent.getData();
			if (uri != null)
			{
				String path = uri.getPath();
				listViewItems.add(path);
				arrayAdapter.notifyDataSetChanged();
			}
		}
	}

	/**
	 * Verifica se a requisição para escolher o arquivo foi concluida com
	 * sucesso.
	 * 
	 * @param requestCode
	 * @param resultCode
	 * @return {@link Boolean}
	 * */
	private boolean isFileChooseOk(final int requestCode, final int resultCode)
	{
		return (requestCode == AttachFileRequestCode && resultCode == RESULT_OK);
	}

	/**
	 * Ação ao clicar em Salvar.
	 */
	private void saveFiles()
	{
		try
		{
			for (String filePath : listViewItems)
			{
				byte[] fileBytes = FileUtils.readFileToByteArray(new File(
						filePath));
				if (isCrypt)
				{
					encryptFile(fileBytes);
				} else
				{
					decryptFile(fileBytes);
				}
			}
		} catch (Exception ex)
		{
			Log.e("[FileChooser]", ex.getMessage(), ex);
		}
		ToastService.makeToast(getApplicationContext(), createToastText());
		listViewItems.clear();
		arrayAdapter.notifyDataSetChanged();
	}

	/**
	 * 
	 * @return
	 */
	private String createToastText()
	{
		StringBuilder builder = new StringBuilder("Arquivos ");
		builder.append(isCrypt ? "criptografados" : "descriptografados");
		builder.append(" com sucesso!");
		return builder.toString();
	}

	/**
	 * 
	 * @param fileBytes
	 * @throws Exception
	 */
	private void encryptFile(byte[] fileBytes) throws Exception
	{
		byte[] encryptedFile = SymmetricCipher.encrypt(fileBytes, ivBytes,
				TEST_PASS_PHRASE);
		FileUtils.writeByteArrayToFile(new File(Environment
				.getExternalStorageDirectory().getPath()
				+ "/backups/fileTesteCrypted"), encryptedFile);
	}

	/**
	 * 
	 * @param fileBytes
	 * @throws Exception
	 */
	private void decryptFile(byte[] fileBytes) throws Exception
	{
		byte[] decryptedFile = SymmetricCipher.decrypt(fileBytes, ivBytes,
				TEST_PASS_PHRASE);
		FileUtils.writeByteArrayToFile(new File(Environment
				.getExternalStorageDirectory().getPath()
				+ "/backups/fileTesteDecrypted"), decryptedFile);
	}
}
