package hu.wolfmanfp.stringcalculator;

public class StringCalculator {
    int add(String numbers) {
        if(numbers.isEmpty()) return 0;
        else return Integer.parseInt(numbers);
    }
}
