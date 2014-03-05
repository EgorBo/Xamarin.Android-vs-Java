package com.example.app;

/**
 * Created by Egorbo on 04.03.14.
 */
public class FooContainer {
    private final int x;
    private final int y;

    public FooContainer (int x, int y){
        this.x = x;
        this.y = y;
    }

    public int getSum(){
        return x + y;
    }
}
