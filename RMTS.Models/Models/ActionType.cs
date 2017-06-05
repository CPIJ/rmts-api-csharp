namespace RMTS.Backend.Models
{
    public class ActionType
    {
        public int Id { get; set; }
        public string Content { get; set; }

	    public ActionType()
	    {
		    
	    }

        public ActionType(string content)
        {
            Content = content;
        }
    }
}