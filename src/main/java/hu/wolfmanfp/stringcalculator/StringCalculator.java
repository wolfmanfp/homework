package hu.wolfmanfp.stringcalculator;

public class StringCalculator {
    public int add(String numbers){
        int sum = 0;
        
        if(!numbers.isEmpty()) {
            String[] input;
            int[] numberArray;
            int i = 0;
            
            input = numbers.split("[,;\\n|]");
            numberArray = new int[input.length];
            for (String s : input) {              
                if (Integer.parseInt(s)<0) {
//                    try {
//                        throw new IllegalArgumentException("Negative numbers are not allowed: "+Integer.parseInt(s));
//                    } catch (Exception ex) {
//                        Logger.getLogger(StringCalculator.class.getName()).log(Level.SEVERE, null, ex);
//                    }
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
