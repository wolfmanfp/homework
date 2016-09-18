package hu.wolfmanfp.superdoom2d.objektumok;

import hu.wolfmanfp.superdoom2d.palya.Palya;
import java.awt.*;
import javax.swing.ImageIcon;

public class Kijarat {
    private double x,y;
    private Palya palya;
    private static int szelesseg, magassag;
    private static Image kep;

    public Kijarat(double x, double y, Palya p) {
        this.x = x;
        this.y = y;
        this.palya=p;
    }

    /**
     * A kijárat statikus változóit állítja be.
     * @param szelesseg
     * @param magassag
     * @param utvonal A kép útvonala.
     */
    public static void statikusBeallitas(int szelesseg,int magassag,String utvonal) {
        Kijarat.szelesseg = szelesseg;
        Kijarat.magassag = magassag;
        Kijarat.kep = new ImageIcon(Kijarat.class.getResource(utvonal)).getImage(); 
    }

    /**
     * Kirajzolja a kijáratot.
     * @param g 
     */
    public void rajzol (Graphics g) {
        double px=palya.getX();
        double py=palya.getY();
        g.drawImage(kep, (int)(x+px-szelesseg/2), (int)(y+py-magassag/2), szelesseg, magassag, null); 
    }
    
    /**
     * Beállítja a kijárat ütközési határát a zászlórúdig.
     * @return Egy téglalapot ad vissza.
     */
    private Rectangle hatarok() {
        return new Rectangle((int)(x-szelesseg/2)+80, (int)(y-magassag/2), szelesseg-80, magassag);
    }
    
    /**
     * Eldönti, hogy a játékos elért-e a zászlórúdhoz.
     * @param j Az ellenség.
     * @return Egy logikai értéket ad vissza.
     */
    public boolean utkozik(Jatekos j) {
        Rectangle sajatHatar=this.hatarok();
        Rectangle jatekosHatar=j.hatarok();
        return sajatHatar.intersects(jatekosHatar);
    }
    
}
