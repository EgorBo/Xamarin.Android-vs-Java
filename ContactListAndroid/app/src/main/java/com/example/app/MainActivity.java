package com.example.app;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class MainActivity extends Activity {

    final String ATTRIBUTE_NAME_NAME = "name";
    final String ATTRIBUTE_NAME_PHONE = "phone";
    final String ATTRIBUTE_NAME_IMAGE = "image";

    private long startTime = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // FILLING LIST
        String[] texts = new String[1000];
        String[] numbers = new String[texts.length];
        for (int i =0; i<texts.length; i++) {
            texts[i] = "Ivan Ivanov" + i;
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


    public void Test1(View view) {
        String result = new TestExecuter().Run(new Test1());
        PrintResults(result);
    }

    public void Test2(View view) {
        String result = new TestExecuter().Run(new Test2());
        PrintResults(result);
    }

    public void Test3(View view) {
        String result = new TestExecuter().Run(new Test3(this));
        PrintResults(result);
    }

    private void PrintResults(String result) {
        TextView resultTv = (TextView)findViewById(R.id.result);
        resultTv.setText(result);
    }
}
