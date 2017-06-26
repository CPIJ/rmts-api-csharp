using System.Collections.Generic;

namespace RMTS.Backend.Models
{
    public class Prospect
    {
        public int Id { get; set; }
        public Address Address { get; set; }
        public string Profession { get; set; }
        public SocialLinks SocialLinks { get; set; }
        public virtual Status Status { get; set; }
	    public int StatusId { get; set; }
        public string FirstName { get; set; }
        public string Infix { get; set; }
        public string Surname { get; set; }
        public string FullName => $"{FirstName} {Infix} {Surname}";
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }

	    public Prospect()
	    {
		    
	    }

        public Prospect(Address address, string profession, SocialLinks socialLinks, Status status, string firstName, string infix, string surname, string phoneNumber, string emailAddress, string imageUrl, string description)
        {
            Address = address;
            Profession = profession;
            SocialLinks = socialLinks;
            Status = status;
            FirstName = firstName;
            Infix = infix;
            Surname = surname;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            ImageUrl = imageUrl;
            Description = description;
        }
    }
}