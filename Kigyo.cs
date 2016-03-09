using System;

namespace Animals
{
	public class Kigyo: Allat, IComparable
	{
		public bool Merges { get; private set; }
		public Kigyo(Meret meret, string szin, bool tudUszni, bool merges)
			:base(meret, szin, 0, false, tudUszni, "sziszegés")
		{
			Merges = merges;
		}
		
		public int CompareTo(object obj) {
			Kigyo masik = obj as Kigyo;

			int elsodleges = Merges.CompareTo(masik.Merges);
			if(elsodleges != 0) return elsodleges*(-1);
			return AllatMerete.CompareTo(masik.AllatMerete);
		}
		
		public override string ToString()
		{
			string merges_e = Merges? "mérges":"nem mérges";
			string tud_e_uszni = TudUszni? "tud úszni":"nem tud úszni";
			return "Kígyó - "+base.ToString()+", "
				+merges_e+", "
				+tud_e_uszni;
		}
	}
}
