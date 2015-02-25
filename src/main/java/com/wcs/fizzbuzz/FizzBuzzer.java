package com.wcs.fizzbuzz;

public class FizzBuzzer {
    
    public String execute(int number) {
        if (number%3==0) return "fizz";
        if (number%5==0) return "buzz";
        return Integer.toString(number);
    }
    
}
