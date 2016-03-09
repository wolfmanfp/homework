using System;
using System.Collections.Generic;

namespace Animals
{
	class Program
	{
		private static Mocker mocker = new Mocker();
		public static void Main(string[] args)
		{
			
			OtElemesListak();
			RendezhetoTipusuAllatok();
			Console.ReadKey();
		}
		
		public static void OtElemesListak() {
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
			Console.WriteLine();
		}
		
		public static void RendezhetoTipusuAllatok() {
			List<IComparable> rendezhetoLista = new List<IComparable>();
			for (int i = 0; i < 5; i++) {
				rendezhetoLista.Add(mocker.NewSnake());
			}
			rendezhetoLista.Sort();
			foreach (IComparable allat in rendezhetoLista) {
				Console.WriteLine(allat);
			}
		}
	}
}