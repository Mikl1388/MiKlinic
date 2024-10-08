

namespace MiKlinic
{
    public abstract class Person
    {
		protected Person(int id, string name)
		{
			Id = id;
			Name = name ?? throw new ArgumentNullException(nameof(name));
		}

		public int Id { get; set; }
        public string Name { get; set; }
    }
}
