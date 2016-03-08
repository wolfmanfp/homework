using System;

namespace Animals
{
	public class Hal: Allat
	{
		public bool Edesvizi { get; private set; }
		public Hal(Meret meret, string szin, bool edesvizi):base(meret, szin, 0, false, true, "tátogás")
		{
			Edesvizi = edesvizi;
		}
	}
}
