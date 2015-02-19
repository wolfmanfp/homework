package hu.wolfmanfp.stringcalculator;

import java.util.logging.Level;
import java.util.logging.Logger;


public class Main {

    public static void main(String[] args) {
        StringCalculator calc = new StringCalculator();
        int test;
        try {
            test = calc.add("10,4,5,12,-4");
            System.out.println(test);
        } catch (Exception ex) {
            Logger.getLogger(Main.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

}
