package hu.wolfmanfp.stringcalculator;

public class StringCalculator {
    public String delimiter;

    public StringCalculator() {
    }
    
    public int add(String numbers){
        int sum = 0;
        
        if (numbers.isEmpty()) return 0;
        String[] numberArray = numbers.split(delimiter);
        
        for (String num : numberArray) {
            sum += Integer.valueOf(num);
        }
        
        return sum;
    }

    public void setDelimiter(String delimiter) {
        this.delimiter = delimiter;
    }
    
}
