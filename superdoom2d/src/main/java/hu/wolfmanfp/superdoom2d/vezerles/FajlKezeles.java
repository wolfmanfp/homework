package hu.wolfmanfp.superdoom2d.vezerles;

import hu.wolfmanfp.superdoom2d.vezerles.AdatVezerlo;
import java.io.File;
import java.io.FileWriter;
import java.io.PrintWriter;
import java.util.Scanner;
import javax.swing.table.DefaultTableModel;

public class FajlKezeles implements AdatVezerlo{
    private String utvonal;
    private File fajl;

    /**
     * A FajlKezeles() osztály implementálja az AdatVezerlo() metódust.
     * @param utvonal Az eredményeket tartalmazó fájl útvonala.
     */
    public FajlKezeles(String utvonal) {
        this.utvonal = utvonal;
        this.fajl=new File(utvonal);
    }
    
    /**
     * Hozzáadja a fájl végéhez a játékos eredményeit.
     * @param nev A játékos neve.
     * @param pont A játékos pontszáma.
     * @throws Exception 
     */
    @Override
    public void ujEredmeny(String nev, int pont) throws Exception {
        try (PrintWriter w=new PrintWriter(new FileWriter(fajl, true))) {
            w.println(nev+";"+pont);
            w.close();
        }
    }

    /**
     * Beolvassa a fájlból a játékosok eredményeit.
     * @return A metódus egy, a játékosok eredményeivel táblamodellt ad vissza.
     * @throws Exception 
     */
    @Override
    public DefaultTableModel eredmenyBeolvasas() throws Exception {
        int sorSzam=0;
        String[][] adatok = null;
        String[] oszlopok={"Név","Pont"};
        //InputStream ins;
        Scanner s;
        try {
            //ins=getClass().getResourceAsStream(utvonal);
            s=new Scanner(fajl,"UTF-8");
            String sor;
            String[] mezok;
            
            while(s.hasNextLine()){
                sorSzam++;
                s.nextLine();
            }
            
            //ins.close();
            //s.close();
            //ins=getClass().getResourceAsStream(utvonal);
            //s=new Scanner(ins,"UTF-8");
            s=new Scanner(fajl,"UTF-8");
            
            adatok=new String[sorSzam][oszlopok.length];
            
            for (int i = 0; i < sorSzam; i++) {
                sor = s.nextLine();
                mezok=sor.split(";");
                for (int j = 0; j < mezok.length; j++) {
                    adatok[i][j]=mezok[j];
                }
            }
           // ins.close();
            s.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
        return new DefaultTableModel(adatok, oszlopok);
    }

}
