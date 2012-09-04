package br.com.sacis.activity;

import java.util.ArrayList;
import java.util.List;

import android.app.ListActivity;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import br.com.sacis.R;

public class FileChooserActivity extends ListActivity
{
	private final int AttachFileRequestCode = 0;
	
	private ArrayAdapter<String> arrayAdapter;
	
	private List<String> listViewItems = new ArrayList<String>();
	
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		//setContentView(R.layout.file_chooser);
		ListView listView = getListView();
		arrayAdapter = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_multiple_choice, listViewItems);
		setListAdapter(arrayAdapter);
		listView.setItemsCanFocus(false);
		listView.setChoiceMode(ListView.CHOICE_MODE_MULTIPLE);
	}
	
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
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
	 * Ação ao clicar em Salvar.
	 */
	private void saveFiles()
	{
		
	}
}
