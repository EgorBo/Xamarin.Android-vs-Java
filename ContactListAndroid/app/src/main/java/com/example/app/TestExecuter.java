package com.example.app;

import java.util.ArrayList;

/**
 * Created by Egorbo on 05.03.14.
 */
public class TestExecuter {

    private long startTime = 0;
    private final int TestsCount = 5;

    public String Run(Test test){
        ArrayList<Long> durationsList = new ArrayList<Long>(TestsCount);
        for (int i = 0; i < TestsCount; i++){
            StartTimer();
            test.Run();
            durationsList.add(GetElapsedTime());
        }
        long first = durationsList.get(0);
        long fastest = first;
        long slowest = first;
        long sum = 0;

        for (int i = 0; i < durationsList.size(); i++){
            long current = durationsList.get(i);
            if (current < fastest){
                fastest = current;
            }
            if (current > slowest){
                slowest = current;
            }
            sum += current;
        }

        double average = (double)(sum - fastest - slowest) / (durationsList.size() - 2.0);

        return String.format("First: %d, Fastest: %d, Slowest: %d, Average: %d", first, fastest, slowest, (long)average);
    }

    private void StartTimer() {
        startTime = System.currentTimeMillis();
    }

    private long GetElapsedTime() {
        long stopTime = System.currentTimeMillis();
        long elapsedTime = stopTime - startTime;
        return elapsedTime;
    }
}
