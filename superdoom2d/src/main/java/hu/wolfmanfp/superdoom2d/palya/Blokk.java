package hu.wolfmanfp.superdoom2d.palya;

import java.awt.Graphics;
import java.awt.Image;
import javax.swing.ImageIcon;

public class Blokk {
    public static int oldal;
    public static Image blokkKep;
    private boolean szilard;

    /**
     * A pályán lévő blokkok osztálya.
     * @param szilard Az értéke true, ha a blokk szilárd, false, ha levegő.
     */
    public Blokk(boolean szilard) {
        this.szilard = szilard;
    }
    
    /**
     * Beállítja a statikus értékeket.
     * @param oldal A blokk oldalának hossza.
     * @param kep A megjelenítendő kép.
     */
    public static void statikusBeallitas (int oldal, String kep) {
        Blokk.oldal = oldal;
        Blokk.blokkKep=new ImageIcon(Blokk.class.getResource(kep)).getImage();
    }
    
    /**
     * Kirajzolja a blokkokat a játékpanelre.
     * @param g
     * @param x A blokk X-koordinátája.
     * @param y A blokk Y-koordinátája.
     */
    public void rajzol(Graphics g, double x, double y){
        if(szilard) g.drawImage(blokkKep, (int)x, (int)y, oldal, oldal, null);
    }

    public boolean isSzilard() {
        return szilard;
    }

}
