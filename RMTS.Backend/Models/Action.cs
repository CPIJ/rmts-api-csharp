using System;

namespace RMTS.Backend.Models
{
    public class Action : IComparable<Action>
    {
        public int Id { get; set; }
        public ActionType ActionType { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public Prospect Prospect { get; set; }
        public bool Completed { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
	    public virtual int ActionTypeId { get; set; }

	    public Action()	
	    {
		    
	    }

        public Action(ActionType actionType, DateTime dateTime, User user, Prospect prospect, bool completed, string description, string location)
        {
            ActionType = actionType;
            Date = dateTime;
            User = user;
            Prospect = prospect;
            Completed = completed;
            Description = description;
            Location = location;
        }

	    public int CompareTo(Action other)
	    {
		    return Date.CompareTo(other.Date);
	    }
    }
}