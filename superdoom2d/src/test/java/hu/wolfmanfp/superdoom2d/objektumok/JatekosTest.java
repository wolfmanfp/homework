/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hu.wolfmanfp.superdoom2d.objektumok;

import hu.wolfmanfp.superdoom2d.objektumok.Jatekos;
import hu.wolfmanfp.superdoom2d.palya.Palya;
import hu.wolfmanfp.superdoom2d.vezerles.AudioVezerlo;
import java.awt.Image;
import javax.swing.ImageIcon;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 * A Jatekos osztály tesztje.
 * @author Péter
 */
public class JatekosTest {
    private Jatekos jatekos;
    private double x, y, dx, dy, //helyzet, sebesség
            palyaX, palyaY, //pálya helyzete
            sebesseg, zuhanas, lassulas, //sebességek
            maxSebesseg, maxZuhanas; //sebességkorlátok
    private int szelesseg, magassag, elet;
    private Image kep;
    private Palya palya;
    private boolean balra, jobbra, halott, zuhan, jobbraNez;
    private boolean ugrik, lo, lovesHang;
    private String nev;
    private int pont, lovesSzelesseg;
    private double ugras;
    private AudioVezerlo av;
    private Image lovesKep;
    
    public JatekosTest() {
    }
    
    @BeforeClass
    public static void setUpClass() {
    }
    
    @AfterClass
    public static void tearDownClass() {
    }
    
    @Before
    public void setUp() {
        Jatekos.setKezdoElet(5);
        palya=new Palya();
        nev="Péter";
        jatekos = new Jatekos(palya, nev);
    }
    
    @After
    public void tearDown() {
    }

    /**
     * Test of beallitas method, of class Jatekos.
     */
    @Test
    public void testBeallitas() {
        System.out.println("beallitas");
        x = 0.0;
        y = 0.0;
        magassag = 125;
        szelesseg = 82;
        lovesSzelesseg = 120;
        sebesseg = 2.1;
        maxSebesseg = 6.0;
        lassulas = 0.6;
        zuhanas = 2.6;
        maxZuhanas = 12.0;
        ugras = -30.0;
        String kepString = "/adatok/figura.png";
        String lovesKepString = "/adatok/figura_lo.png";
        jatekos.beallitas(x, y, magassag, szelesseg, lovesSzelesseg, sebesseg, maxSebesseg, lassulas, 
                zuhanas, maxZuhanas, ugras, kepString, lovesKepString);
        assertTrue(jatekos.getX()== x);
    }


    /**
     * Test of addPont method, of class Jatekos.
     */
    @Test
    public void testAddPont() {
        System.out.println("addPont");
        jatekos.addPont();
        assertTrue(jatekos.getPont()==100);
    }

    /**
     * Test of getPont method, of class Jatekos.
     */
    @Test
    public void testGetPont() {
        System.out.println("getPont");
        int expResult = 0;
        int result = jatekos.getPont();
        assertEquals(expResult, result);
    }

    /**
     * Test of setKezdoElet method, of class Jatekos.
     */
    @Test
    public void testSetKezdoElet() {
        System.out.println("setKezdoElet");
        int kezdoElet = 5;
        Jatekos.setKezdoElet(kezdoElet);
        assertTrue(Jatekos.getKezdoElet()==kezdoElet);
    }

    /**
     * Test of setBalra method, of class Jatekos.
     */
    @Test
    public void testSetBalra() {
        System.out.println("setBalra");
        boolean balra = false;
        jatekos.setBalra(balra);
        assertTrue(jatekos.isBalra()==balra);
    }

    /**
     * Test of setJobbra method, of class Jatekos.
     */
    @Test
    public void testSetJobbra() {
        System.out.println("setJobbra");
        boolean jobbra = false;
        jatekos.setJobbra(jobbra);
        assertTrue(jatekos.isJobbra()==jobbra);
    }

    /**
     * Test of setUgras method, of class Jatekos.
     */
    @Test
    public void testSetUgras() {
        System.out.println("setUgras");
        boolean ugras = false;
        jatekos.setUgras(ugras);
        assertTrue(jatekos.ugrik()==ugrik);
    }

    /**
     * Test of setLovesKep method, of class Jatekos.
     */
    @Test
    public void testSetLovesKep() {
        System.out.println("setLovesKep");
        String lovesKepString = "/adatok/figura_lo.png";
        Image lovesKep = new ImageIcon(this.getClass().getResource(lovesKepString)).getImage();
        jatekos.setLovesKep(lovesKep);
        assertTrue(jatekos.getLovesKep()==lovesKep);
    }

    /**
     * Test of setLoves method, of class Jatekos.
     */
    @Test
    public void testSetLoves() {
        System.out.println("setLoves");
        boolean lo = false;
        jatekos.setLoves(lo);
        assertTrue(jatekos.lo()==lo);
    }
    
}
