using System.Collections.Generic;

namespace RMTS.Backend.Models
{
    public class SortedActions
    {
        public Dictionary<string, List<Action>> Actions { get; private set; }

        public SortedActions(Dictionary<string, List<Action>> actions)
        {
            Actions = new Dictionary<string, List<Action>>
            {
                { "today", new List<Action>() },
                { "thisWeek", new List<Action>() },
                { "thisMonth", new List<Action>() },
                { "remainder", new List<Action>() },
            };
        }

        public void SetThisWeek(List<Action> actions)
        {
            SetAtKey("thisWeek", actions);
        }

        public void SetToday(List<Action> actions)
        {
            SetAtKey("today", actions);
        }
        public void SetThisMonth(List<Action> actions)
        {
            SetAtKey("thisMonth", actions);
        }
        public void SetRemainder(List<Action> actions)
        {
            SetAtKey("remainder", actions);
        }

        private void SetAtKey(string key, List<Action> actions)
        {
            Actions[key] = actions;
        }
    }
}