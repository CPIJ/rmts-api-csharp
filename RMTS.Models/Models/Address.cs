namespace RMTS.Backend.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }

	    public Address()
	    {
		    
	    }

        public Address(string street, string city, string zipcode)
        {
            Street = street;
            City = city;
            Zipcode = zipcode;
        }
    }
}