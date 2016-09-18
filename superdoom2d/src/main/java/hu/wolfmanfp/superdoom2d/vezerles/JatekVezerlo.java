package hu.wolfmanfp.superdoom2d.vezerles;

import hu.wolfmanfp.superdoom2d.palya.*;
import hu.wolfmanfp.superdoom2d.jatek.*;
import hu.wolfmanfp.superdoom2d.objektumok.*;
import java.awt.*;
import java.awt.event.*;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.*;
import java.util.List;
import java.util.concurrent.CopyOnWriteArrayList;

/**
 * A JatekVezerlo osztály gondoskodik az objektumok frissítéséről, és
 * játékpanelre való rajzolásáról.
 * @author Farkas Péter
 */
public class JatekVezerlo implements KeyListener, Runnable{
    private static JatekVezerlo peldany = null;
    private Image hatterkep;
    private String nev;
    private Jatekos jatekos;
    private JatekPanel jp;
    private AdatVezerlo adatv;
    private AudioVezerlo av;
    private Palya palya;
    private Kijarat kijarat;
    private Thread szal;
    private static int FPS;
    private boolean fut;
    private List<Cacodemon> ellensegek;

    private JatekVezerlo() {
        kezdoAblak();
        init();
    }

    /**
     * Mivel a JatekVezerlo egy singleton osztály, ez a getter adja vissza
     * az osztály egyetlen, statikus példányát.
     * @return Egy statikus példányt ad vissza.
     */
    public static JatekVezerlo getPeldany() {
        if(peldany==null) peldany=new JatekVezerlo();
        return peldany;
    }
    
    /**
     * Megnyitja a játék elején lévő ablakot, majd lekérdezi a játékos által beírt nevet.
     */
    private void kezdoAblak() {
        KezdoAblak dialog=new KezdoAblak(new JFrame(),"Super Doom 2D",true);
        dialog.setDefaultCloseOperation(JFrame.DO_NOTHING_ON_CLOSE);
        dialog.setLocationRelativeTo(null);
        dialog.setVisible(true);
        nev=dialog.getNev();
    }

    /**
     * Létrehozza a játékost, a pályát, beállítja a változók értékeit, és elindítja a szálat.
     */
    private void init() {
        
        adatv=new FajlKezeles("eredmenyek.txt");
        //adatv=new MySQLKezeles("jdbc:mysql://localhost/superdoom2d");
        //adatv=new MSSQLKezeles("jdbc:sqlserver://localhost;DatabaseName=superdoom2d;");  
        
        JatekVezerlo.FPS=60;
        
        hatterkep=new ImageIcon(this.getClass().getResource("/adatok/hatter.jpg")).getImage();
        
        Blokk.statikusBeallitas(48, "/adatok/blokk.jpg");
        palya=new Palya();
        palya.beolvasas("/adatok/palya.txt");
        
        Kijarat.statikusBeallitas(328, 340, "/adatok/kijarat.png");
        kijarat=new Kijarat(3200, 310, palya);
        
        Jatekos.setKezdoElet(5);
        if(!"".equals(nev)) {
            jatekos=new Jatekos(palya, nev);
            jatekos.beallitas(50, 300, 125, 82, 120, 2.1, 6, 0.6, 2.6, 9, -36, 
                              "/adatok/figura.png", "/adatok/figura_lo.png");
        }
        
        Tolteny.statikusBeallitas(3, 9, 10, "/adatok/tolteny.png");
        
        Cacodemon.setKezdoElet(2);
        ellensegek=new CopyOnWriteArrayList<>();
        ellensegek.add(new Cacodemon(1400, 240, palya));
        ellensegek.add(new Cacodemon(2450, 240, palya));
        for (int i = 0; i < ellensegek.size(); i++) {
            ellensegek.get(i).beallitas(100, 89, 2.1, 2.6, 9, 
                    "/adatok/cacodemon.png", "/adatok/cacodemon_halott.png");
        }
        
        av=new AudioVezerlo();
        av.start("/adatok/zene.mp3",true);
        
        if(szal==null){
            szal=new Thread(this);
            fut=true;
            szal.start();  
        }
    }    
    
    /**
     * A szál másodpercenként 60-szor frissül, ennek a pontos kiszámításához
     * long típusú változókat és a rendszeridőt használja fel.
     */
    @Override
    public void run() {	
        long frElott;
        long frUtan;
        long ido;

        while(fut) {
            frElott = System.nanoTime();
            
            frissit();
            jp.repaint();
            
            frUtan = System.nanoTime() - frElott;
            ido = (1000/FPS) - frUtan / 1000000;
            if (ido<0) ido=1000/FPS;
            
            try {
                Thread.sleep(ido);
            }
            catch(Exception e) {
                e.printStackTrace();
            }
        }
    }
    
    /**
     * Frissíti az objektumok helyzetét a frissit() metódusuk meghívásával.
     */
    private void frissit() {
        palya.frissit(
                JatekPanel.SZELESSEG/2-jatekos.getX(),
                JatekPanel.MAGASSAG/2-jatekos.getY()
        );
        
        jatekos.ellensegEllenorzes(ellensegek);
        
        if (!jatekos.halott()) jatekos.frissit();    
        else { 
            jp.repaint();
            av.start("/adatok/jatekos_halal.mp3", false);
            JOptionPane.showMessageDialog(
                new JFrame(),
                "Meghaltál."
            );
        this.fut=false;
        System.exit(0);
        }    
        
        if (kijarat.utkozik(jatekos)) {
            this.fut=false;
            av.start("/adatok/vastaps.mp3", false);
            try {
                adatv.ujEredmeny(nev, jatekos.getPont());
            } catch (Exception ex) {
                Logger.getLogger(JatekVezerlo.class.getName()).log(Level.SEVERE, null, ex);
            }
            eredmenyAblak();
        }
    }
    
    /**
     * Megnyitja az eredményeket tartalmazó ablakot.
     */
    private void eredmenyAblak() {
        EredmenyAblak dialog=new EredmenyAblak(new JFrame(),"Eredmények",true,adatv);
        dialog.setLocationRelativeTo(null);
        dialog.setVisible(true);
    }

    /**
     * Kirajzolja az objektumokat a rajzol() metódusuk meghívásával.
     * @param g
     */
    public void rajzol(Graphics g) {
        g.drawImage(hatterkep, 0, 0, JatekPanel.SZELESSEG, JatekPanel.MAGASSAG, null);
        palya.rajzol(g);
        kijarat.rajzol(g);
        for (int i = 0; i < ellensegek.size(); i++) {
            ellensegek.get(i).rajzol(g);
        }
        if (jatekos!=null) jatekos.rajzol(g);
        
        String allapot=nev+": "+jatekos.getPont()+
                " pont, életek száma: "+jatekos.getElet();
        g.setColor(Color.white);
        g.setFont(new Font("Arial", Font.PLAIN, 18));
        g.drawString(allapot, 10,20);
    }

    @Override
    public void keyTyped(KeyEvent e) {}

    /**
     * A megadott billentyűk lenyomásakor engedélyezi a játékos valamely képességét,
     * ami aztán a játékos frissit() metódusában lesz alkalmazva.
     * @param e 
     */
    @Override
    public void keyPressed(KeyEvent e) {
        if (e.getKeyCode()==KeyEvent.VK_LEFT || e.getKeyCode()==KeyEvent.VK_A)
            jatekos.setBalra(true);
        if (e.getKeyCode()==KeyEvent.VK_RIGHT || e.getKeyCode()==KeyEvent.VK_D) 
            jatekos.setJobbra(true);
        if (e.getKeyCode()==KeyEvent.VK_SPACE || e.getKeyCode()==KeyEvent.VK_W) 
            jatekos.setUgras(true);
        if (e.getKeyCode()==KeyEvent.VK_CONTROL) 
            jatekos.setLoves(true);
        if (e.getKeyCode()==KeyEvent.VK_ESCAPE) 
            System.exit(0);
        //sérülés tesztelése
        if (e.getKeyCode()==KeyEvent.VK_K) 
            jatekos.serul();
    }

    @Override
    public void keyReleased(KeyEvent e) {
        if (e.getKeyCode()==KeyEvent.VK_LEFT || e.getKeyCode()==KeyEvent.VK_A) 
            jatekos.setBalra(false);
        if (e.getKeyCode()==KeyEvent.VK_RIGHT || e.getKeyCode()==KeyEvent.VK_D) 
            jatekos.setJobbra(false);
        if (e.getKeyCode()==KeyEvent.VK_SPACE || e.getKeyCode()==KeyEvent.VK_W)
            jatekos.setUgras(false);
        if (e.getKeyCode()==KeyEvent.VK_CONTROL) 
            jatekos.setLoves(false);
    }

    public void setPanel(JatekPanel jp) {
        this.jp = jp;
    }
 
}
