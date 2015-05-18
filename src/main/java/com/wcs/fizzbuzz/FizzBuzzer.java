package com.wcs.fizzbuzz;

public class FizzBuzzer {

    public String execute(int number) {
        String output = "";

        if (number % 3 == 0 || String.valueOf(number).contains("3")) {
            output += "fizz";
        }
        if (number % 5 == 0 || String.valueOf(number).contains("5")) {
            output += "buzz";
        }
        if (number % 7 == 0 || String.valueOf(number).contains("7")) {
            output += "wizz";
        }
        if (output.isEmpty()) {
            output += Integer.toString(number);
        }

        return output;
    }

}
