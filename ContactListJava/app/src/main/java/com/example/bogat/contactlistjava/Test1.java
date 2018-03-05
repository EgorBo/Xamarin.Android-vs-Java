package com.example.bogat.contactlistjava;

/**
 * Created by bogat on 3/5/2018.
 */

public class Test1 implements Test {
    @Override
    public void Run() {
        int pans = 0;
        int primes = 0;
        double foo = 0;
        for (int i=0; i<12345; i++)
        {
            if (isPandigital(i))
                pans++;

            if (isPrime(i))
                primes++;

            foo += calculateFoo(i);
        }
    }

    private boolean isPrime(int n) {
        if (n%2==0) return false;
        for(int i=3;i*i<=n;i+=2) {
            if(n%i==0)
                return false;
        }
        return true;
    }

    private Boolean isPandigital(int n){
        int count = 0;
        int digits = 0;
        int digit;
        int bit;
        do {
            digit = n % 10;
            if (digit == 0){
                return false;
            }
            bit = 1 << digit;

            if (digits == (digits |= bit)){
                return false;
            }

            count++;
            n /= 10;
        } while (n > 0);
        return (1<<count)-1 == digits>>1;
    }

    private double calculateFoo(int n){
        double a = 1.0;
        for (int i = 0; i < n; i ++){
            a = a * 1.123456789101112 / n;
        }
        return a;
    }

}
