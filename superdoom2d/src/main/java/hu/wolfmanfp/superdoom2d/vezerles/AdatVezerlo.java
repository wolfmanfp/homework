package hu.wolfmanfp.superdoom2d.vezerles;

import javax.swing.table.DefaultTableModel;

/**
 * Ez az interfész gondoskodik az eredmények beolvasásáról,
 * illetve az új eredmények "felírásáról".
 * @author Péter
 */
public interface AdatVezerlo {
    void ujEredmeny(String nev, int pont) throws Exception;
    DefaultTableModel eredmenyBeolvasas() throws Exception;
}
