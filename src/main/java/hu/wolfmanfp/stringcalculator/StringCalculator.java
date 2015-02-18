package hu.wolfmanfp.stringcalculator;

public class StringCalculator {
    int add(String numbers) {
        int sum = 0;
        
        if(!numbers.isEmpty()) {
            String[] input;
            int[] numberArray;
            int i = 0;
            
            input = numbers.split(",");
            numberArray = new int[input.length];
            for (String s : input) {
                numberArray[i] = Integer.parseInt(s);
                i++;
            }
            i=0;
            for (int number : numberArray) {
                sum+=numberArray[i];
                i++;
            }
        }
        else sum = 0;
        
        return sum;
    }
}
