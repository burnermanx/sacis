package br.com.sacis.activity;

import java.util.ArrayList;
import java.util.List;

import br.com.sacis.R;
import android.app.Activity;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.ListView;

public class FileChooserActivity extends Activity
{
	private final int AttachFileRequestCode = 0;
	
	private ArrayAdapter<String> arrayAdapter;
	
	private List<String> listViewItems = new ArrayList<String>();
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.file_chooser);
		ListView listView = getListView();
		arrayAdapter = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_multiple_choice, listViewItems);
		listView.setAdapter(arrayAdapter);
		listView.setItemsCanFocus(false);
		listView.setChoiceMode(ListView.CHOICE_MODE_MULTIPLE);
	}
	
	private ListView getListView()
	{
		return (ListView) this.findViewById(R.id.fileChooserListView);
	}
	
	/**
	 * Acao ao clicar no botao de escolher arquivo
	 * @param view
	 */
	public void chooseFile(View view)
	{
		//Por agora ira escolher um arquivo, sera implementada uma fileDialog para contornar esse problema
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
	 * Ação ao clicar no botao de Salvar.
	 * @param view
	 */
	public void saveFiles(View view)
	{
		
	}
}
