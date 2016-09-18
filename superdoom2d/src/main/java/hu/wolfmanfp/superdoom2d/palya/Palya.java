package hu.wolfmanfp.superdoom2d.palya;

import hu.wolfmanfp.superdoom2d.jatek.JatekPanel;
import java.awt.Graphics;
import java.io.IOException;
import java.io.InputStream;
import java.util.Scanner;

public class Palya {
    private double x, y;
    private int szelesseg, magassag,
            sorSzam, oszlopSzam,
            xmin, xmax, ymin, ymax,
            sorOfszet, oszlopOfszet,
            megjelenoSorok, megjelenoOszlopok;
    private Blokk[][] blokkok;
    
    /**
     * Beolvassa a megadott szövegfájlból a pálya
     * szélességét, magasságát és blokkjait.
     * @param utvonal A pályát tartalmazó szövegfájl útvonala.
     */
    public void beolvasas(String utvonal){
        try (InputStream ins=getClass().getResourceAsStream(utvonal);
                Scanner s=new Scanner(ins,"UTF-8");) {
            
            sorSzam=Integer.parseInt(s.nextLine());
            oszlopSzam=Integer.parseInt(s.nextLine());
            
            magassag=sorSzam*Blokk.oldal;
            szelesseg=oszlopSzam*Blokk.oldal;
            blokkok=new Blokk[sorSzam][oszlopSzam];
            xmin=JatekPanel.SZELESSEG-szelesseg;
            ymin=JatekPanel.MAGASSAG-magassag;
            xmax=0; ymax=0;
            megjelenoSorok=JatekPanel.MAGASSAG/Blokk.oldal+1;
            megjelenoOszlopok=JatekPanel.SZELESSEG/Blokk.oldal+1;
            
            for (int i = 0; i < sorSzam; i++) {
                String sor=s.nextLine();
                for (int j = 0; j < oszlopSzam; j++) { 
                    boolean szilard=false;
                    if (sor.charAt(j)=='x') szilard = true;
                    blokkok[i][j]=new Blokk(szilard);
                }
            }
        
        } catch (IOException e) {
            e.printStackTrace();
        }
    
    }
    
    /**
     * A játékos megadott koordinátái alapján frissíti a
     * pálya helyzetét, beállítja az ofszetet.
     * @param x
     * @param y 
     */
    public void frissit(double x, double y) {
        this.x = x;
        this.y = y;
        
        if(this.x < xmin) this.x = xmin;
        if(this.x > xmax) this.x = xmax;
        if(this.y < ymin) this.y = ymin;
        if(this.y > ymax) this.y = ymax;
        
        sorOfszet=(int)-this.y/Blokk.oldal;
        oszlopOfszet=(int)-this.x/Blokk.oldal;
    }
    
    /**
     * Kirajzolja azokat a blokkokat, amik az ofszeten belül vannak.
     * @param g 
     */
    public void rajzol(Graphics g) {
        for (int i = sorOfszet; i < sorOfszet+megjelenoSorok; i++) {
            if (i>=sorSzam) break;
            for (int j = oszlopOfszet; j < oszlopOfszet+megjelenoOszlopok; j++) { 
                if (j>=oszlopSzam) break;
                else blokkok[i][j].rajzol(g, x+j*Blokk.oldal, y+i*Blokk.oldal);
            }
        }
    }

    public Blokk getBlokk (int x,int y){
        if(x<0) x=0;
        if(x>=oszlopSzam) x=oszlopSzam-1;
        if(y<0) y=0;
        if(y>=sorSzam) y=sorSzam-1;
        return blokkok[y][x];
    }
    
    public double getX() {
        return x;
    }

    public double getY() {
        return y;
    }

    public int getSzelesseg() {
        return szelesseg;
    }

}
