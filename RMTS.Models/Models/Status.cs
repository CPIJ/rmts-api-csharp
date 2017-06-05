namespace RMTS.Backend.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }

	    public Status()
	    {
		    
	    }

        public Status(int id, string name)
        {
            Id = id;
            Name = name;
        }

	    public Status(string name)
	    {
		    this.Name = name;
	    }
    }
}