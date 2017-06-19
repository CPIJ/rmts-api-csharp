using System.Collections.Generic;

namespace RMTS.Backend.Models
{
    public class Prospect
    {
        public int Id { get; set; }
        public Address Address { get; set; }
        public string Profession { get; set; }
        public SocialLinks SocialLinks { get; set; }
        public Status Status { get; set; }
        public string FirstName { get; set; }
        public string Infix { get; set; }
        public string Surname { get; set; }
        public string Fullname => $"{FirstName} {Infix} {Surname}";
        public string Phonenumber { get; set; }
        public string EmailAddress { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }

	    public Prospect()
	    {
		    
	    }

        public Prospect(Address address, string profession, SocialLinks socialLinks, Status status, string firstName, string infix, string surname, string phonenumber, string emailAddress, string imageUrl, string description)
        {
            Address = address;
            Profession = profession;
            SocialLinks = socialLinks;
            Status = status;
            FirstName = firstName;
            Infix = infix;
            Surname = surname;
            Phonenumber = phonenumber;
            EmailAddress = emailAddress;
            ImageUrl = imageUrl;
            Description = description;
        }
    }
}