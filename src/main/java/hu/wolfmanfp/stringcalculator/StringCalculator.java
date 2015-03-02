package hu.wolfmanfp.stringcalculator;

public class StringCalculator {
    
    public int add(String numbers){
        int sum = 0;
        
        if (numbers.isEmpty()) return 0;
        String[] numberArray = numbers.split(",");
        
        for (String num : numberArray) {
            sum += Integer.valueOf(num);
        }
        
        return sum;
    }
    
}
