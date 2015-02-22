package hu.wolfmanfp.stringcalculator;

public class StringCalculator {
    public int add(String numbers) throws Exception {
        int sum = 0;
        
        if(!numbers.isEmpty()) {
            String[] input;
            int[] numberArray;
            int i = 0;
            
            input = numbers.split(",");
            numberArray = new int[input.length];
            for (String s : input) {              
                if (Integer.parseInt(s)<0) {
                    throw new Exception("Negative numbers are not allowed: "+Integer.parseInt(s));
                } else {
                    numberArray[i]=Integer.parseInt(s);
                }
                i++;
            }
            i=0;
            for (int j = 0; j < numberArray.length; j++) {
				sum+=numberArray[j];
			}
        }
        else sum = 0;
        
        return sum;
    }
}
