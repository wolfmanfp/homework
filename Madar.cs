using System;

namespace Animals
{
	public class Madar: Allat
	{
		public bool Ragadozo { get; private set; }
		public bool KalitkabanTarthato { get; private set; }
		
		public Madar(Meret meret, string szin, bool ragadozo, bool kalitkabanTarthato)
			:base(meret, szin, 2, true, false, "csipogás")
		{
			Ragadozo = ragadozo;
			KalitkabanTarthato = kalitkabanTarthato;
		}
		
		public override string ToString()
		{
			return "Madár - "+base.ToString()+", "
				+TudRepulni? "tud repülni":"nem tud repülni"+", "
				+KalitkabanTarthato? "kalitkában tartható":"nem tartható kalitkában";
		}
	}
}
