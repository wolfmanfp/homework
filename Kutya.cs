using System;

namespace Animals
{
	public class Kutya: Allat
	{
		public bool LakasbanTarthato { get; private set; }
		public Kutya(Meret meret, string szin, bool lakasbanTarthato)
			: base(meret, szin, 4, false, true, "ugatás")
		{
			LakasbanTarthato = lakasbanTarthato;
		}
	}
}
