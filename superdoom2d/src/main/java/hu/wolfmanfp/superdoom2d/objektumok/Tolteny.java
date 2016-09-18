package hu.wolfmanfp.superdoom2d.objektumok;

import hu.wolfmanfp.superdoom2d.palya.Palya;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.Rectangle;
import javax.swing.ImageIcon;

public class Tolteny{
    private double x, y;
    private static double sebesseg;
    private static int magassag, szelesseg;
    private static Image kep;
    private Palya palya;
    private boolean jobbraNez;

    /**
     * A játékos fegyveréből kirepülő töltények.
     * @param x
     * @param y
     * @param palya
     * @param jobbraNez 
     */
    public Tolteny(double x, double y, Palya palya, boolean jobbraNez) {
        this.x=x;
        this.y=y;
        this.palya = palya;
        this.jobbraNez = jobbraNez;
    }
    
    /**
     * A töltények statikus változóit állítja be.
     * @param magassag
     * @param szelesseg
     * @param sebesseg
     * @param utvonal 
     */
    public static void statikusBeallitas (int magassag, int szelesseg, 
            double sebesseg, String utvonal) {
        Tolteny.szelesseg = szelesseg;
        Tolteny.magassag = magassag;
        Tolteny.sebesseg = sebesseg;
        Tolteny.kep = new ImageIcon(Tolteny.class.getResource(utvonal)).getImage(); 
    }
    
    /**
     * Frissíti a töltény helyzetét.
     */
    public void frissit() {
        if(jobbraNez) x+=sebesseg;
        else x-=sebesseg;
    }
    
    /**
     * Kirajzolja a töltényt.
     * @param g 
     */
    public void rajzol (Graphics g) {
        double px=palya.getX();
        double py=palya.getY();
        if (jobbraNez) g.drawImage(kep, (int)(x+px-szelesseg/2), (int)(y+py-magassag/2), szelesseg, magassag, null);
        else if (!jobbraNez) g.drawImage(kep, (int)(x+px+szelesseg/2), (int)(y+py-magassag/2), -szelesseg, magassag, null);
    }
    
    /**
     * Beállítja a töltény ütközési határát.
     * @return Egy téglalapot ad vissza.
     */
    private Rectangle hatarok() {
        return new Rectangle((int)(x-szelesseg/2), (int)(y-magassag/2), szelesseg, magassag);
    }
    
    /**
     * Eldönti, hogy a töltény ütközik-e az ellenséggel.
     * @param f Az ellenség.
     * @return Egy logikai értéket ad vissza.
     */
    public boolean eltalal(Cacodemon f) {
        Rectangle o1=this.hatarok();
        Rectangle o2=f.hatarok();
        return o1.intersects(o2); 
    }

}
