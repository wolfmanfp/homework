package hu.wolfmanfp.stringcalculator;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class StringCalculator {
    public String delimiter;

    public StringCalculator() {
    }
    
    public int add(String numbers) throws Exception{
        int sum = 0;
        List<Integer> negativeList = new ArrayList<>();
        
        if (numbers.isEmpty()) return 0;
        String[] numberArray = numbers.split(delimiter);
        
        for (String numStr : numberArray) {
            int num = Integer.valueOf(numStr);
            
            sum += num;
            if (num<0) negativeList.add(num);
        }
        
        if (!negativeList.isEmpty()) throw new Exception("Negatives are not allowed: "+
                Arrays.toString(negativeList.toArray()));
        
        return sum;
    }

    public void setDelimiter(String delimiter) {
        this.delimiter = delimiter;
    }
    
}
