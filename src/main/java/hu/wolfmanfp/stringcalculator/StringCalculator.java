package hu.wolfmanfp.stringcalculator;

public class StringCalculator {

    public int add(String numbers) throws Exception {
        int sum = 0;

        if (!numbers.isEmpty()) {
            String[] input;
            String negativeNumbers = null;
            int[] numberArray;

            input = numbers.split("[,;\\n|]");
            numberArray = new int[input.length];
            for (int i = 0; i < input.length; i++) {
                String s = input[i];
                if (Integer.parseInt(s) < 0) {
                    negativeNumbers += s;
                    if (i != input.length-1) {
                        negativeNumbers += ", ";
                    }
                } else {
                    numberArray[i] = Integer.parseInt(s);
                }
            }
            for (int j = 0; j < numberArray.length; j++) {
                sum += numberArray[j];
            }
            if (negativeNumbers != null) {
                throw new Exception("Negatives not allowed: "+negativeNumbers);
            }
        }

        return sum;

    }

}
