namespace MiKlinic.Model
{
	public abstract class Person
	{
		public Person() { }
		protected Person(string name)
		{
			Name = name ?? throw new ArgumentNullException(nameof(name));
		}

		public string Name { get; set; }
	}
}
