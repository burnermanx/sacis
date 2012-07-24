package br.com.sacis.activity;

import br.com.sacis.R;
import android.app.Activity;
import android.os.Bundle;
import android.widget.ArrayAdapter;
import android.widget.ListView;

public class FileChooserActivity extends Activity
{
	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.file_chooser);
		ListView listView = getListView();
		String[] test = { "file1", "file2" };
		listView.setAdapter(new ArrayAdapter<String>(this, android.R.layout.simple_list_item_multiple_choice, test));
		listView.setItemsCanFocus(false);
		listView.setChoiceMode(ListView.CHOICE_MODE_MULTIPLE);
	}
	
	private ListView getListView()
	{
		return (ListView) this.findViewById(R.id.fileChooserListView);
	}
}
