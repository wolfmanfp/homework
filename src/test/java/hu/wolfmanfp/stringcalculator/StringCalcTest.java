/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hu.wolfmanfp.stringcalculator;

import org.junit.Before;
import org.junit.Test;
import static org.junit.Assert.*;
import org.junit.Rule;
import org.junit.rules.ExpectedException;

/**
 *
 * @author wolfman
 */
public class StringCalcTest {
    int sum;
    StringCalculator calculator;
    
    @Rule
    public ExpectedException exception = ExpectedException.none();
    
    @Before
    public void setUp() {
        sum=0;
        calculator = new StringCalculator();
    }
    
    public StringCalcTest() {
    }
 
    @Test
    public void test1() throws Exception {      
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
    }
    
    @Test
    public void test2() throws Exception {
        sum = calculator.add("1,3,1,5");
        assertTrue(sum==10);

        sum = calculator.add("10,4,5,12,4");
        assertTrue(sum==35);
    }
    
    @Test
    public void test3() throws Exception {
        sum = calculator.add("1;2");
        assertTrue(sum==3);

        sum = calculator.add("3\n5");
        assertTrue(sum==8);

        sum = calculator.add("4|2");
        assertTrue(sum==6);
    }
    
    @Test
    public void test4() throws Exception {
        exception.expect(Exception.class);
        sum = calculator.add("1,3,2,-5");
        System.out.println(sum);
    }
    
    @Test
    public void test5() throws Exception {
        exception.expect(NumberFormatException.class);
        sum = calculator.add("2,lol");
        assertTrue(sum==0);        
    }
    
}
