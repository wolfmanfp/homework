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
			if(elsodleges != 0) return elsodleges;
			return AllatMerete.CompareTo(masik.AllatMerete);
		}
		
		public override string ToString()
		{
			return "Kígyó - "+base.ToString()+", "
				+Merges? "mérges":"nem mérges"+", "
				+TudUszni? "tud úszni":"nem tud úszni";
		}
	}
}
