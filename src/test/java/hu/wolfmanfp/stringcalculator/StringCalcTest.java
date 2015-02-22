/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hu.wolfmanfp.stringcalculator;

import java.util.logging.Level;
import java.util.logging.Logger;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author wolfman
 */
public class StringCalcTest {
    
    public StringCalcTest() {
    }
 
    @Test
    public void test() throws Exception {
        int sum;
        StringCalculator calculator = new StringCalculator();      
            
        sum = calculator.add("");
        assertTrue(sum==0);

        sum = calculator.add("1");
        assertTrue(sum==1);

        sum = calculator.add("2");
        assertTrue(sum==2);

        sum = calculator.add("1,3");
        assertTrue(sum==4);

        sum = calculator.add("10,4");
        assertTrue(sum==14);

        sum = calculator.add("1,3,1,5");
        assertTrue(sum==10);

        sum = calculator.add("10,4,5,12,4");
        assertTrue(sum==35);

        sum = calculator.add("1;2");
        assertTrue(sum==3);

        sum = calculator.add("3\n5");
        assertTrue(sum==8);

        sum = calculator.add("4|2");
        assertTrue(sum==6);

        sum = calculator.add("1,3,2,-5");
        fail();
        
    }
}
