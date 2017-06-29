using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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

		public static SortedActions FromList(IEnumerable<Action> actions)
		{
			var actionsList = actions.ToList();
			actionsList.Sort();

			var dateTimeInfo = DateTimeFormatInfo.CurrentInfo;
			if (dateTimeInfo == null) throw new NullReferenceException();

			var cal = dateTimeInfo.Calendar;

			var today = actionsList
				.Where(a => a.Date == DateTime.Today)
				.ToList();

			var thisWeek = actionsList
				.Where(a =>
				{
					int testWeek = cal.GetWeekOfYear(a.Date, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
					int currentWeek = cal.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

					return testWeek == currentWeek && a.Date.Date != DateTime.Today;
				})
				.ToList();

			var thisMonth = actionsList
				.Where(a =>
				{
					bool withinMonth = a.Date.Month == DateTime.Today.Month;
					int testWeek = cal.GetWeekOfYear(a.Date, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
					int currentWeek = cal.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

					return withinMonth && testWeek != currentWeek;
				})
				.ToList();

			var remainder = actionsList
				.Where(a => a.Date.Month > DateTime.Today.Month)
				.ToList();

			return new SortedActions(today, thisWeek, thisMonth, remainder);
		}
	}	
}