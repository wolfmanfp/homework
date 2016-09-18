package hu.wolfmanfp.superdoom2d.vezerles;

import java.io.BufferedInputStream;
import java.util.logging.Level;
import java.util.logging.Logger;
import javazoom.jl.decoder.JavaLayerException;
import javazoom.jl.player.Player;

public class AudioVezerlo{
    private BufferedInputStream b;
    private Player p;

    /**
     * Az AudioVezerlo() gondoskodik a háttérzene és a hangeffektek lejátszásáról.
     */
    public AudioVezerlo() {      
    }
    
    /**
     * A metódus új szálat hoz létre (inner class), és lejátssza a paraméterként megadott hangot.
     * @param fajlnev A fájl elérési útvonala.
     * @param loop Beállítja az ismétlődést, amit egy hátultesztelő ciklussal ellenőriz a metódus.
     */
    public void start(String fajlnev, boolean loop) {
                
        new Thread() {
            @Override
            public void run() {
                try {    
                    do {     
                        b = new BufferedInputStream(this.getClass().getResourceAsStream(fajlnev));
                        p = new Player(b);
                        p.play();
                    } while (loop);   
                } catch (JavaLayerException ex) {
                    Logger.getLogger(AudioVezerlo.class.getName()).log(Level.SEVERE, null, ex);
                }
            }
        }.start();       
    }
    
}
