package com.wcs.fizzbuzz;

public class FizzBuzzer {
    
    public String execute(int number) {
        if (number%3==0) return "fizz";
        return Integer.toString(number);
    }
    
}
