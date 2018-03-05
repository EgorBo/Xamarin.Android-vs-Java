package com.example.bogat.contactlistjava;

import android.app.Activity;

/**
 * Created by bogat on 3/5/2018.
 */

public class Test3 implements Test {
    private Activity activity;

    public Test3(Activity activity) {
        this.activity = activity;
    }

    @Override
    public void Run() {
        String result = "";
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < 100000; i++) {
            //result += String.valueOf(i); -- this performs 3x times slower than in xamarin O_o
            builder.append(i);
        }
        result = builder.toString();
        result = result.substring(1000); //don't know how it works but if it just sets offset to 1000 it will be cheating ;)
        result = result.replaceAll("10", "");
        boolean containsSubstring = result.contains("123");
        String[] parts = result.split("2");
        int length = parts.length;
    }

    /*private byte[] LoadData(String inFile) {
        byte[] buffer = new byte[0];
        try {
            InputStream stream = activity.getAssets().open(inFile);
            int size = stream.available();
            buffer = new byte[size];
            stream.read(buffer);
            stream.close();
        } catch (IOException e) {
            // Handle exceptions here
        }
        return buffer;
    }*/
}