package hu.wolfmanfp.stringcalculator;

public class StringCalculator {
    
    public int add(String numbers){   
        if (numbers.isEmpty()) return 0;
        String[] numberArray = numbers.split(",");
        if (numberArray.length==1) return Integer.valueOf(numberArray[0]);
        return Integer.valueOf(numberArray[0])+Integer.valueOf(numberArray[1]);
    }
    
}
