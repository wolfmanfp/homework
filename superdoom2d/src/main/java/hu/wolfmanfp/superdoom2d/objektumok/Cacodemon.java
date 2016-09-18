package hu.wolfmanfp.superdoom2d.objektumok;

import hu.wolfmanfp.superdoom2d.palya.Palya;
import hu.wolfmanfp.superdoom2d.vezerles.AudioVezerlo;
import java.awt.Graphics;
import java.awt.Image;
import javax.swing.ImageIcon;

public class Cacodemon extends Figura{
    private static int kezdoElet;
    private AudioVezerlo av;
    private Image halottKep;
    
    /**
     * A Cacodemon a Figura() osztály leszármazott osztálya,
     * ő az ellenség.
     * @param p 
     */
    public Cacodemon(double x, double y, Palya p) {  
        super(p);
        this.x = x;
        this.y = y;       
    }
    
    /**
     * A játékvezérlő init() metódusában hívódik meg, beállítja
     * az ellenfél tulajdonságait. 
     * @param magassag
     * @param szelesseg
     * @param sebesseg
     * @param zuhanas
     * @param maxZuhanas
     * @param kep
     * @param halottKep Beállítja az ellenfél halála után megjelenő képet.
     */
    public void beallitas(int magassag, int szelesseg,
            double sebesseg, 
            double zuhanas, double maxZuhanas,
            String kep, String halottKep) {

        this.magassag = magassag;
        this.szelesseg = szelesseg;
        this.sebesseg = sebesseg;
        this.zuhanas = zuhanas;
        this.maxZuhanas = maxZuhanas;

        this.elet = kezdoElet;
        this.jobbraNez = true;
        this.av = new AudioVezerlo();
        this.kep = new ImageIcon(this.getClass().getResource(kep)).getImage();
        this.halottKep = new ImageIcon(this.getClass().getResource(halottKep)).getImage();
    }
    
    /**
     * Frissíti a cacodemon helyzetét.
     */
    public void frissit() {
        if (halott) {
            dy += zuhanas;
            if (dy > maxZuhanas) {
                dy = maxZuhanas;
            }
        }
        utkozesEllenorzes();
        y+=dy;
    }
    
    /**
     * Kirajzolja az ellenfelet a pályára.
     * @param g 
     */
    public void rajzol(Graphics g){
        double px=palya.getX();
        double py=palya.getY();
        if(halott) g.drawImage(halottKep, (int)(x+px-szelesseg/2), (int)(y+py-magassag/2), null);
        else super.rajzol(g);
    }

    @Override
    protected void meghal() {
        super.meghal();
        av.start("/adatok/cacodemon_halal.mp3", false);
    }

    @Override
    protected void serul() {
        super.serul();
        if (elet>0) av.start("/adatok/cacodemon_serul.mp3", false);
    }   

    public static void setKezdoElet(int kezdoElet) {
        Cacodemon.kezdoElet = kezdoElet;
    }  
}
