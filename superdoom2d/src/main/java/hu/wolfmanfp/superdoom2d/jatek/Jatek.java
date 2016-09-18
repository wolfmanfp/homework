package hu.wolfmanfp.superdoom2d.jatek;

import java.awt.Toolkit;
import javax.swing.JFrame;
import javax.swing.JPanel;

public class Jatek {
    
    /**
     * A main metódus létrehoz egy új ablakot, és beállítja annak tulajdonságait.
     * @param args
     * @author Farkas Péter (FAPVABP.PTE)
     */
    public static void main(String[] args) {
        JFrame ablak=new JFrame("Super Doom 2D alpha");
        JPanel panel=JatekPanel.getPeldany();
        
        ablak.setIconImage(Toolkit.getDefaultToolkit().getImage(Jatek.class.getResource("/adatok/ikon.png")));
        ablak.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        ablak.setContentPane(panel);
        //ablak.setResizable(false);
        ablak.pack();
        ablak.setLocationRelativeTo(null);
        ablak.setVisible(true);
    }

}
