package br.com.sacis;

import java.util.List;

import br.com.sacis.model.FileListView;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

public class AdapterListView extends BaseAdapter
{
	private LayoutInflater inflater;
	
	private List<FileListView> itens;
	
	public AdapterListView(Context context, List<FileListView> itens)
	{
		this.itens = itens;
		inflater = LayoutInflater.from(context);
	}
	
	@Override
	public int getCount()
	{
		return itens.size();
	}

	@Override
	public Object getItem(int arg0)
	{
		return itens.get(arg0);
	}

	@Override
	public long getItemId(int arg0)
	{
		return arg0;
	}

	@Override
	public View getView(int position, View view, ViewGroup parent)
	{
		FileListView item = itens.get(position);
		view = inflater.inflate(R.layout.file_list, null);
		((TextView) view.findViewById(R.id.fileNameTextView)).setText(item.getFileName());
		return view;
	}

}
