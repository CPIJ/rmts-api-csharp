using System.Collections.Generic;

namespace RMTS.Backend.Models
{
    public class SortedActions
    {
	    public IEnumerable<Action> Today { get; private set; }
	    public IEnumerable<Action> ThisWeek { get; private set; }
	    public IEnumerable<Action> ThisMonth { get; private set; }
	    public IEnumerable<Action> Remainder { get; private set; }

	    public SortedActions(IEnumerable<Action> today, IEnumerable<Action> thisWeek, IEnumerable<Action> thisMonth, IEnumerable<Action> remainder)
	    {
		    Today = today;
		    ThisWeek = thisWeek;
		    ThisMonth = thisMonth;
		    Remainder = remainder;
	    }
    }
}