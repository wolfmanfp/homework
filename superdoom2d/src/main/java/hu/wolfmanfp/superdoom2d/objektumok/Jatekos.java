package hu.wolfmanfp.superdoom2d.objektumok;

import hu.wolfmanfp.superdoom2d.jatek.JatekPanel;
import hu.wolfmanfp.superdoom2d.palya.Palya;
import hu.wolfmanfp.superdoom2d.vezerles.AudioVezerlo;
import java.awt.Graphics;
import java.awt.Image;
import java.util.List;
import java.util.concurrent.CopyOnWriteArrayList;
import javax.swing.ImageIcon;

public class Jatekos extends Figura {
    private boolean ugrik, lo, nemlott;
    private String nev;
    private int pont, lovesSzelesseg;
    private double ugras;
    private static int kezdoElet;
    private AudioVezerlo av;
    private Image lovesKep;
    private List<Tolteny> toltenyek;

    /**
     * A játékos a Figura() osztály leszármazott osztálya.
     *
     * @param p A pálya, amin a játékos megjelenik.
     * @param nev
     */
    public Jatekos(Palya p, String nev) {
        super(p);
        this.nev = nev;
    }

    /**
     * A játékvezérlő init() metódusában hívódik meg, beállítja a játékos
     * tulajdonságait.
     *
     * @param x
     * @param y
     * @param magassag
     * @param szelesseg
     * @param lovesSzelesseg Beállítja a lövéskor használt kép szélességét.
     * @param sebesseg
     * @param maxSebesseg Legfeljebb ekkora sebességgel mehet.
     * @param lassulas
     * @param zuhanas
     * @param maxZuhanas Legfeljebb ekkora sebességgel zuhanhat.
     * @param ugras Ekkora sebességgel ugorhat (mínusz érték).
     * @param kep
     * @param lovesKep Beállítja a játékos fegyverhasználata során megjelenő
     * képet.
     */
    public void beallitas(double x, double y, int magassag, int szelesseg,
            int lovesSzelesseg, double sebesseg, double maxSebesseg,
            double lassulas, double zuhanas, double maxZuhanas, double ugras,
            String kep, String lovesKep) {
        this.x = x;
        this.y = y;
        this.magassag = magassag;
        this.szelesseg = szelesseg;
        this.lovesSzelesseg = lovesSzelesseg;
        this.sebesseg = sebesseg;
        this.maxSebesseg = maxSebesseg;
        this.lassulas = lassulas;
        this.zuhanas = zuhanas;
        this.maxZuhanas = maxZuhanas;
        this.ugras = ugras;

        this.elet = kezdoElet;
        this.pont = 0;
        this.jobbraNez = true;
        this.av = new AudioVezerlo();
        this.kep = new ImageIcon(this.getClass().getResource(kep)).getImage();
        this.lovesKep = new ImageIcon(this.getClass().getResource(lovesKep)).getImage();
        this.toltenyek = new CopyOnWriteArrayList<>();
    }

    /**
     * Kirajzolja a játékost a panelre.
     * @param g
     */
    public void rajzol(Graphics g) {
        for (int i = 0; i < toltenyek.size(); i++) {
            toltenyek.get(i).rajzol(g);
        }
        if (lo) {
            double px = palya.getX();
            double py = palya.getY();
            if (jobbraNez) {
                g.drawImage(
                        lovesKep, 
                        (int) (x + px - lovesSzelesseg / 2), 
                        (int) (y + py - magassag / 2), 
                        lovesSzelesseg, magassag, null);
            } else if (!jobbraNez) {
                g.drawImage(lovesKep, 
                        (int) (x + px + lovesSzelesseg / 2), 
                        (int) (y + py - magassag / 2), 
                        -lovesSzelesseg, magassag, null);
            }
        } else {
            super.rajzol(g);
        }
    }

    /**
     * A lenyomott billentyűk által engedélyezett tulajdonságok alapján frissíti
     * a játékos helyzetét, és lejátssza a megfelelő hangeffekteket.
     */
    public void frissit() {
        if (x < 0 + szelesseg / 2) {
            x = 0 + szelesseg / 2;
        }
        if (x > palya.getSzelesseg() - szelesseg / 2) {
            x = palya.getSzelesseg() - szelesseg / 2;
        }
        
        //System.out.println(x+";"+y);
        
        mozgas();
        tamadas();
        utkozesEllenorzes();
        
        x += dx;
        y += dy;
    }
    
    /**
     * A játékos mozgását irányítja.
     */
    private void mozgas() {
        if (balra) {
            jobbraNez = false;
            dx -= sebesseg;
            if (dx < -maxSebesseg) {
                dx = -maxSebesseg;
            }
        } else if (jobbra) {
            jobbraNez = true;
            dx += sebesseg;
            if (dx > maxSebesseg) {
                dx = maxSebesseg;
            }
        } else {
            if (dx > 0) {
                dx -= lassulas;
                if (dx < 0) {
                    dx = 0;
                }
            } else if (dx < 0) {
                dx += lassulas;
                if (dx > 0) {
                    dx = 0;
                }
            }
        }

        if (ugrik && !zuhan) {
            av.start("/adatok/ugras.mp3", false);
            dy = ugras;
            zuhan = true;
        }

        if (zuhan) {
            dy += zuhanas;
            if (dy > 0) {
                ugrik = false;
            }
            if (dy < 0 && !ugrik) {
                dy += lassulas;
            }
            if (dy > maxZuhanas) {
                dy = maxZuhanas;
            }
            if (y > JatekPanel.MAGASSAG) {
                this.meghal();
            }
        }
    }
    
    /**
     * A játékos lövését irányítja.
     */
    private void tamadas() {
        if (lo) {
            if (!(ugrik || zuhan)) {
                dx = 0;
            }
            
            if (nemlott) {
                av.start("/adatok/jatekos_lo.mp3", false);
                toltenyek.add(new Tolteny(x+20, y-15, palya, jobbraNez));
            }
            nemlott = false;
        }
        for (int i = 0; i < toltenyek.size(); i++) {
            toltenyek.get(i).frissit();
        }
    }
    
    /**
     * A JatekVezerlo frissit() metódusában hívódik meg, ellenőrzi
     * a töltények, és saját maga ütközését az ellenséggel.
     * @param ellensegek Az ellenségeket tartalmazó lista.
     */
    public void ellensegEllenorzes(List<Cacodemon> ellensegek) {
        for (int i = 0; i < ellensegek.size(); i++) {
            ellensegek.get(i).frissit();
            for (int j = 0; j < toltenyek.size(); j++) {
                if (toltenyek.get(j).eltalal(ellensegek.get(i))){
                    if (!ellensegek.get(i).halott()) {
                        ellensegek.get(i).serul();
                        this.addPont();
                    }
                    toltenyek.remove(j);                   
                }
            }
            if (utkozik(ellensegek.get(i))&&!ellensegek.get(i).halott()) serul();
        }
    }

    /**
     * Növeli a játékos pontszámát.
     */
    public void addPont() {
        this.pont+=100;
    }

    /**
     * Sérüléskor a megfelelő hangot játssza.
     */
    @Override
    public void serul() {
        super.serul();
        if (elet > 0) {
            av.start("/adatok/jatekos_serul.mp3", false);
        }
    }

    public int getPont() {
        return pont;
    }

    public Image getLovesKep() {
        return lovesKep;
    }

    public boolean lo() {
        return lo;
    }

    public boolean ugrik() {
        return ugrik;
    }

    public static int getKezdoElet() {
        return kezdoElet;
    }

    public static void setKezdoElet(int kezdoElet) {
        Jatekos.kezdoElet = kezdoElet;
    }

    public void setBalra(boolean balra) {
        this.balra = balra;
    }

    public void setJobbra(boolean jobbra) {
        this.jobbra = jobbra;
    }

    public void setUgras(boolean ugras) {
        this.ugrik = ugras;
    }

    public void setLovesKep(Image lovesKep) {
        this.lovesKep = lovesKep;
    }

    public void setLoves(boolean lo) {
        this.lo = lo;
        this.nemlott = true;
    }

    

}
