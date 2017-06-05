using System;

namespace RMTS.Backend.Models
{
    public class Action
    {
        public int Id { get; set; }
        public ActionType ActionType { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public Prospect Prospect { get; set; }
        public bool IsCompleted { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

	    public Action()
	    {
		    
	    }

        public Action(ActionType actionType, DateTime dateTime, User user, Prospect prospect, bool isCompleted, string description, string location)
        {
            ActionType = actionType;
            Date = dateTime;
            User = user;
            Prospect = prospect;
            IsCompleted = isCompleted;
            Description = description;
            Location = location;
        }
    }
}