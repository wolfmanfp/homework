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
		
		public Allat NewAnimal() {
			return new Allat(RandomSize(), RandomColor(), random.Next(2,8),
			                 RandomBoolean(), RandomBoolean(), RandomSound());
		}
		
		public Kutya NewDog() {
			return new Kutya(RandomSize(), RandomColor(), RandomBoolean());
		}
		
		public Madar NewBird() {
			return new Madar(RandomSize(), RandomColor(), RandomBoolean(), RandomBoolean());
		}
		
		public Hal NewFish() {
			return new Hal(RandomSize(), RandomColor(), RandomBoolean());
		}
		
		public Kigyo NewSnake() {
			return new Kigyo(RandomSize(), RandomColor(), RandomBoolean(), RandomBoolean());
		}
			
		private bool RandomBoolean(){
			return random.NextDouble() > 0.5;
		}
		
		private Allat.Meret RandomSize() {
			return (Allat.Meret)random.Next(0,4);
		}
		
		private string RandomColor() {
			string[] colors = {"fehér", "szürke", "fekete", "tarka", "zöld", "piros", "neonsárga"};
			return colors[random.Next(0,6)];
		}
		
		private string RandomSound() {
			string[] sounds = {"ugatás", "csipogás", "tátogás", "sziszegés"};
			return sounds[random.Next(0,3)];
		}
	}
}
