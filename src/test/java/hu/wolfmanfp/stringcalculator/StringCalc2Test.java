/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hu.wolfmanfp.stringcalculator;

import static org.junit.Assert.assertEquals;
import org.junit.Before;
import org.junit.Rule;
import org.junit.Test;
import org.junit.rules.ExpectedException;

/**
 *
 * @author wolfman
 */
public class StringCalc2Test {
    StringCalculator2 calculator;
    
    @Rule
    public ExpectedException expected = ExpectedException.none();
    
    @Before
    public void setUp() {
        calculator = new StringCalculator2();
        calculator.setDelimiter(",");
    }
    
    public StringCalc2Test() {
    }
    
    @Test
    public void emptyString() throws Exception {
        assertEquals(0, calculator.add(""));
    }
    
    @Test
    public void oneNumber() throws Exception {
            assertEquals(1, calculator.add("1"));
            assertEquals(2, calculator.add("2"));
    }
    
    @Test
    public void twoNumbers() throws Exception {
        assertEquals(4, calculator.add("1,3"));
        assertEquals(14, calculator.add("10,4"));
    }
    
    @Test
    public void multipleNumbers() throws Exception {
        assertEquals(10, calculator.add("1,3,1,5"));
        assertEquals(35, calculator.add("10,4,5,12,4"));
    }
    
    @Test
    public void customDelimiters() throws Exception {
        calculator.setDelimiter(";");
        assertEquals(3, calculator.add("1;2"));
        calculator.setDelimiter("\n");
        assertEquals(8, calculator.add("3\n5"));
        calculator.setDelimiter("\t");
        assertEquals(6, calculator.add("4\t2"));
    }
    
    @Test
    public void negativeNumbers() throws Exception {
        expected.expect(Exception.class);
        expected.expectMessage("Negatives are not allowed: [-3, -5]");
        calculator.add("1,-3,2,-5");
    }
}