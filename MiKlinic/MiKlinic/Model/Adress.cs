
namespace MiKlinic.Model
{

	public class Adress
	{
		public Adress() { }
		public Adress(string apartment, string house, string street, string city, string state, string country, string postalCode)
		{
			Apartment = apartment ?? throw new ArgumentNullException(nameof(apartment));
			House = house ?? throw new ArgumentNullException(nameof(house));
			Street = street ?? throw new ArgumentNullException(nameof(street));
			City = city ?? throw new ArgumentNullException(nameof(city));
			State = state ?? throw new ArgumentNullException(nameof(state));
			Country = country ?? throw new ArgumentNullException(nameof(country));
			PostalCode = postalCode ?? throw new ArgumentNullException(nameof(postalCode));
		}

		public int Id { get; set; }
		public string Apartment { get; set; }
		public string House { get; set; }
		public string Street { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
		public string PostalCode { get; set; }
	}
}
