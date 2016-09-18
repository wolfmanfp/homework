package hu.wolfmanfp.superdoom2d.vezerles;

import java.sql.*;
import java.util.Vector;
import javax.swing.table.DefaultTableModel;

public class MySQLKezeles implements AdatVezerlo{
    private String utvonal;
    private Connection kapcsolat;

    public MySQLKezeles(String utvonal) {
        this.utvonal = utvonal;
    }
    
    /**
     * Kapcsolódik a MySQL adatbázishoz a konstruktorban megadott útvonal alapján.
     * @throws ClassNotFoundException
     * @throws SQLException 
     */
    private void kapcsolodas() throws ClassNotFoundException, SQLException{
        Class.forName("com.mysql.jdbc.Driver");
        kapcsolat = DriverManager.getConnection(utvonal, "root", "");
    }

    /**
     * Kapcsolódás után hozzáadja az új eredményt az adatbázis Eredmenyek táblájához.
     * @param nev A játékos neve.
     * @param pont A játékos által elért pontok száma.
     * @throws Exception 
     */
    @Override
    public void ujEredmeny(String nev, int pont) throws Exception {
        if (kapcsolat==null||kapcsolat.isClosed()) kapcsolodas();
        if (kapcsolat!=null) {
            PreparedStatement utasitas=kapcsolat.prepareStatement(
                    "INSERT INTO eredmenyek(Nev,Pont)values(?, ?)"
            );
            utasitas.setString(1, nev);
            utasitas.setInt(2, pont);
            utasitas.execute();
            kapcsolat.close();
        }
    }

    /**
     * Beolvassa az Eredmenyek táblából az eddigi eredményeket.
     * @return A metódus egy, a játékosok eredményeivel táblamodellt ad vissza.
     * @throws Exception 
     */
    @Override
    public DefaultTableModel eredmenyBeolvasas() throws Exception {
        Vector<Vector<Object>> adatok = null;
        Vector<String> oszlopok = null;
        if (kapcsolat==null||kapcsolat.isClosed()) kapcsolodas();
        if (kapcsolat!=null) {
            try(Statement utasitas = kapcsolat.createStatement();               
                ResultSet eredmenyHalmaz = utasitas.executeQuery("SELECT * FROM eredmenyek;");)
            {
                ResultSetMetaData metaData = eredmenyHalmaz.getMetaData();

                oszlopok = new Vector<>();
                int oszlopSzam = metaData.getColumnCount();
                for (int i = 1; i <= oszlopSzam; i++) {
                    oszlopok.add(metaData.getColumnName(i));
                }

                adatok = new Vector<>();
                while (eredmenyHalmaz.next()) {
                    Vector<Object> sor = new Vector<>();
                    for (int i = 1; i <= oszlopSzam; i++) {
                        sor.add(eredmenyHalmaz.getObject(i));
                    }
                    adatok.add(sor);
                }
            }
            kapcsolat.close();
        }
        return new DefaultTableModel(adatok, oszlopok);
    }
    
}
