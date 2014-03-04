package com.example.app;

import android.app.Activity;
import android.os.Bundle;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class MainActivity extends Activity {

    final String ATTRIBUTE_NAME_NAME = "name";
    final String ATTRIBUTE_NAME_PHONE = "phone";
    final String ATTRIBUTE_NAME_IMAGE = "image";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        String[] texts = LoadData("data.dat").split("\n");
        String[] numbers = new String[texts.length];
        for (int i =0; i<texts.length; i++) {
            numbers[i] = "+375(55)1112222 " + i;
        }

        ArrayList<Map<String, Object>> data = new ArrayList<Map<String, Object>>(texts.length);
        Map<String, Object> m;
        for (int i = 0; i < texts.length; i++) {
            m = new HashMap<String, Object>();
            m.put(ATTRIBUTE_NAME_NAME, texts[i]);
            m.put(ATTRIBUTE_NAME_PHONE, numbers[i]);
            m.put(ATTRIBUTE_NAME_IMAGE, i % 2 == 0 ? R.drawable.xamarin : R.drawable.ic_launcher);
            data.add(m);
        }

        String[] from = { ATTRIBUTE_NAME_NAME, ATTRIBUTE_NAME_PHONE, ATTRIBUTE_NAME_IMAGE };
        int[] to = { R.id.tvName, R.id.tvNumber, R.id.tvImage };

        SimpleAdapter adapter = new SimpleAdapter(this, data, R.layout.item_row, from, to);
        ListView list = (ListView) findViewById(R.id.list);
        list.setAdapter(adapter);
    }

    public String LoadData(String inFile) {
        String tContents = "";
        try {
            InputStream stream = getAssets().open(inFile);
            int size = stream.available();
            byte[] buffer = new byte[size];
            stream.read(buffer);
            stream.close();
            tContents = new String(buffer);
        } catch (IOException e) {
            // Handle exceptions here
        }
        return tContents;
    }
}
