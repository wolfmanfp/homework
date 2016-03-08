using System;

namespace Animals
{
	public class Kigyo: Allat
	{
		public bool Merges { get; private set; }
		public Kigyo(Meret meret, string szin, bool tudUszni, bool merges)
			:base(meret, szin, 0, false, tudUszni, "sziszegés")
		{
			Merges = merges;
		}
	}
}
