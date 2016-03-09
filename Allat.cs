using System;

namespace Animals
{
	public class Allat
	{
		public enum Meret {XS, S, M, L, XL}
		
		public Meret AllatMerete { get; private set; }
		public string Szin { get; private set; }
		public int LabakSzama { get; private set; }
		public bool TudRepulni { get; private set; }
		public bool TudUszni { get; private set; }
		public string Hang { get; private set; }
		
		public Allat(Meret meret, string szin, int labak, 
		             bool tudRepulni, bool tudUszni, string hang)
		{
			AllatMerete = meret;
			Szin = szin;
			LabakSzama = labak;
			TudRepulni = tudRepulni;
			TudUszni = tudUszni;
			Hang = hang;
		}
		
		
		public override string ToString()
		{
			return "Mérete: "+AllatMerete+", színe: "+Szin;
		}
	}
}
