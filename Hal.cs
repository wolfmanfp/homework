namespace Animals
{
    public class Hal: Allat
	{
		public bool Edesvizi { get; private set; }
		
		public Hal(Meret meret, string szin, bool edesvizi)
			:base(meret, szin, 0, false, true, "tátogás")
		{
			Edesvizi = edesvizi;
		}
		
		public override string ToString()
		{
			string edesvizi_e = Edesvizi? "édesvízi":"tengeri";
			return "Mérete: "+AllatMerete+", "
				+edesvizi_e;
		}
	}
}
