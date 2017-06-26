using System.Collections;
using System.Collections.Generic;

namespace RMTS.Backend.Models
{
    public class ActionType
    {
        public int Id { get; set; }
        public string Content { get; set; }
	    public virtual ICollection<Action> Actions { get; set; }

	    public ActionType()
	    {
		    
	    }

        public ActionType(string content)
        {
            Content = content;
        }
    }
}