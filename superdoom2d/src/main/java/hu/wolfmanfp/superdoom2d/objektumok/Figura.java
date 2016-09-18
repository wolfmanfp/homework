package hu.wolfmanfp.superdoom2d.objektumok;

import hu.wolfmanfp.superdoom2d.palya.*;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.Rectangle;

public abstract class Figura{
    protected double x, y, dx, dy, //helyzet, sebesség
            sebesseg, lassulas, zuhanas, //sebességek
            maxSebesseg, maxZuhanas; //sebességkorlátok
    protected int szelesseg, magassag, elet;
    protected Image kep;
    protected Palya palya;
    protected boolean balra, jobbra, jobbraNez, zuhan, halott;
    private Blokk felso, also, bal, jobb;

    public Figura(Palya palya) { 
        this.palya = palya;
    }
    
    /**
     * Kirajzolja a figurát a játékpanelre.
     * @param g 
     */
    public void rajzol(Graphics g) {
        double px=palya.getX();
        double py=palya.getY();
        if (jobbraNez) g.drawImage(kep, (int)(x+px-szelesseg/2), (int)(y+py-magassag/2), null);
        else if (!jobbraNez) g.drawImage(kep, (int)(x+px+szelesseg/2), (int)(y+py-magassag/2), -szelesseg, magassag, null);
    }

    /**
     * Beállítja a figura ütközési határát.
     * @return Egy téglalapot ad vissza.
     */
    protected Rectangle hatarok() {
        return new Rectangle((int)(x-szelesseg/2), (int)(y-magassag/2), szelesseg, magassag);
    }
    
    /**
     * Eldönti, hogy a figura ütközik-e egy másik figurával.
     * @param f
     * @return 
     */
    protected boolean utkozik(Figura f) {
        Rectangle o1=this.hatarok();
        Rectangle o2=f.hatarok();
        return o1.intersects(o2);
    }
    
    /**
     * Ellenőrzi, hogy a figura ütközik-e a pálya valamely blokkjával.
     */
    protected void utkozesEllenorzes() {
        felso = palya.getBlokk((int) (x / Blokk.oldal), (int) ((y - magassag / 2) / Blokk.oldal));
        also = palya.getBlokk((int) (x / Blokk.oldal), (int) ((y + magassag / 2) / Blokk.oldal));
        
        for (int i = (int) ((y / Blokk.oldal) - 1); i < (int) ((y / Blokk.oldal) + 2); i++) {
            bal = palya.getBlokk((int) ((x - szelesseg / 2) / Blokk.oldal), i);
            jobb = palya.getBlokk((int) ((x + szelesseg / 2) / Blokk.oldal), i);
            if ((bal.isSzilard()) && dx < 0) {
                dx = 0;
            }
            if ((jobb.isSzilard()) && dx > 0) {
            dx = 0;
        }
        }

        if (also.isSzilard() && dy > 0) {
            dy = 0;
            zuhan = false;
        }
        if (felso.isSzilard() && dy < 0) {
            dy = 0;
        }
        if (!also.isSzilard()) {
            zuhan = true;
        }
    }
    
    /**
     * Ez a metódus hívódik meg, ha a figura sérül, ekkor
     * az életéből levon 1-et, ameddig nem 0. Ekkor a figura meghal().
     */
    protected void serul() {
        elet--;
        if (elet==0) this.meghal();
    }
    
    /**
     * A figura halálakor ez a metódus hívódik meg,
     * beállítja a halott logikai változót.
     */
    protected void meghal() {
        elet=0;
        if (!this.halott) this.halott=true;
    }
    
    public boolean halott(){
        return halott;
    }

    public int getElet() {
        return elet;
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

    public int getMagassag() {
        return magassag;
    }

    public boolean isBalra() {
        return balra;
    } 

    public boolean isJobbra() {
        return jobbra;
    }
    
    public void setKep(Image kep) {
        this.kep = kep;
    }
    
}
