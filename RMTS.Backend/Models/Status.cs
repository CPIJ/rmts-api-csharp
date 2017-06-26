using System.Collections.Generic;

namespace RMTS.Backend.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Content { get; set; }
	    public virtual ICollection<Prospect> Prospects { get; set; }

	    public Status()
	    {
		    
	    }

        public Status(int id, string content)
        {
            Id = id;
            Content = content;
        }

	    public Status(string content)
	    {
		    this.Content = content;
	    }
    }
}