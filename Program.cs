using System;
using System.Collections.Generic;

namespace Animals
{
	class Program
	{
		private static Mocker mocker = new Mocker();
		public static void Main(string[] args)
		{
			OtelemuListak();
			RendezhetoTipusuAllatok();
            KozosTulajdonsagok();
            Allathangok();
			Console.ReadKey();
		}
		
		public static void OtelemuListak() {
            Console.WriteLine("Öt elemű listák:\n");

			List<Allat> allatok = new List<Allat>();
			List<Kutya> kutyak = new List<Kutya>();
			List<Madar> madarak = new List<Madar>();
			List<Hal> halak = new List<Hal>();
			List<Kigyo> kigyok = new List<Kigyo>();
			for (int i = 0; i < 5; i++) {
				allatok.Add(mocker.NewAnimal());
				kutyak.Add(mocker.NewDog());
				madarak.Add(mocker.NewBird());
				halak.Add(mocker.NewFish());
				kigyok.Add(mocker.NewSnake());
			}

            #region Kiíratás
            foreach (Allat allat in allatok)
            {
                Console.WriteLine(allat);
            }

            foreach (Kutya kutya in kutyak)
            {
                Console.WriteLine(kutya);
            }

            foreach (Madar madar in madarak)
            {
                Console.WriteLine(madar);
            }

            foreach (Hal hal in halak)
            {
                Console.WriteLine(hal);
            }

            foreach (Kigyo kigyo in kigyok)
            {
                Console.WriteLine(kigyo);
            }
            #endregion

            Console.WriteLine();
		}
		
		public static void RendezhetoTipusuAllatok() {
            Console.WriteLine("Rendezhető típusú állatok:\n");

			List<IComparable> rendezhetoLista = new List<IComparable>();
			for (int i = 0; i < 5; i++) {
				rendezhetoLista.Add(mocker.NewSnake());
			}
			rendezhetoLista.Sort();
			foreach (IComparable allat in rendezhetoLista) {
				Console.WriteLine(allat);
			}

            Console.WriteLine();
		}

        public static void KozosTulajdonsagok()
        {
            Console.WriteLine("Állatok közös tulajdonságai:\n");

            List<Allat> allatok = new List<Allat>();
            allatok.Add(mocker.NewAnimal());
            allatok.Add(mocker.NewBird());
            allatok.Add(mocker.NewDog());
            allatok.Add(mocker.NewFish());
            allatok.Add(mocker.NewSnake());

            foreach (Allat allat in allatok)
            {
                Console.WriteLine(allat.Tulajdonsagok());
            }

            Console.WriteLine();
        }

        public static void Allathangok()
        {
            Console.WriteLine("Állatok hangjai:\n");

            List<Allat> allatok = new List<Allat>();
            allatok.Add(mocker.NewAnimal());
            allatok.Add(mocker.NewBird());
            allatok.Add(mocker.NewDog());
            allatok.Add(mocker.NewFish());
            allatok.Add(mocker.NewSnake());

            foreach (Allat allat in allatok)
            {
                Console.WriteLine(allat.AllatHang());
            }
        }
    }
}