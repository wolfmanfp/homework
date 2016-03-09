using System;

namespace Animals
{
	public class Mocker
	{
		private Random random;
		
		public Mocker()
		{
			random = new Random();
		}
		
		public Allat newAnimal() {
			return new Allat(randomSize(), randomColor(), random.Next(2,8),
			                 randomBoolean(), randomBoolean(), randomSound());
		}
		
		public Kutya newDog() {
			return new Kutya(randomSize(), randomColor(), randomBoolean());
		}
		
		public Madar newBird() {
			return new Madar(randomSize(), randomColor(), randomBoolean(), randomBoolean());
		}
		
		public Hal newFish() {
			return new Hal(randomSize(), randomColor(), randomBoolean());
		}
		
		public Kigyo newSnake() {
			return new Kigyo(randomSize(), randomColor(), randomBoolean(), randomBoolean());
		}
			
		private bool randomBoolean(){
			return random.NextDouble > 0.5;
		}
		
		private Allat.Meret randomSize() {
			return Allat.Meret[random.Next(0,4)];
		}
		
		private string randomColor() {
			string[] colors = {"fehér", "szürke", "fekete", "tarka", "zöld", "piros", "neonsárga"};
			return colors[random.Next(0,6)];
		}
		
		private string randomSound() {
			string[] sounds = {"ugatás", "csipogás", "tátogás", "sziszegés"};
			return sounds[random.Next(0,3)];
		}
	}
}
