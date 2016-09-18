package hu.wolfmanfp.superdoom2d.jatek;

import hu.wolfmanfp.superdoom2d.vezerles.JatekVezerlo;
import javax.swing.JPanel;
import java.awt.*;

public class JatekPanel extends JPanel{
    private static JatekPanel peldany;
    public static final int SZELESSEG=960;
    public static final int MAGASSAG=540;
    private JatekVezerlo jv;

    private JatekPanel() {
        super();
        init();
    }
    
    /**
     * Mivel a JatekPanel egy singleton osztály, ez a getter adja vissza
     * az osztály egyetlen, statikus példányát.
     * @return Egy statikus példányt ad vissza.
     */
    public static JatekPanel getPeldany() {
        if (peldany==null) peldany = new JatekPanel();
        return peldany;
    }

    /**
     * A paintComponent metódus a repaint() metódus meghívásakor hívódik meg,
     * meghívja a JatekVezerlo osztáky rajzol() metóusát.
     * @param g 
     */
    @Override
    protected void paintComponent(Graphics g) {
        super.paintComponent(g);
        if (jv!=null) jv.rajzol(g);
    }
    
    /**
     * Beállítja a panel szükséges adatait, létrehozza a játékvezérlőt.
     */
    private void init() {
        this.setPreferredSize(new Dimension(SZELESSEG, MAGASSAG));
        this.setFocusable(true);
        requestFocus();
        
        jv=JatekVezerlo.getPeldany();
        jv.setPanel(this);
        this.addKeyListener(jv); 
    }
    
}
