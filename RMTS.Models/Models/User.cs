namespace RMTS.Backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

	    public User()
	    {
		    
	    }

        public User(string name, string username, string password, bool isActive)
        {
            Name = name;
            Username = username;
            Password = password;
            this.IsActive = isActive;
        }
    }
}