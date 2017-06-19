using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using RMTS.Backend.Models;
using Action = RMTS.Backend.Models.Action;

namespace RMTS.Test
{
	[TestClass]
	public class SortedActionsTest
	{

		private static readonly List<Action> Actions = new List<Action>
		{
			new Action(null, DateTime.Today, null, null, false, "1", null),
			new Action(null, DateTime.Today, null, null, false, "2", null),
			new Action(null, DateTime.Today.AddDays(2), null, null, false, "3", null),
			new Action(null, DateTime.Today.AddDays(1), null, null, false, "4", null),
			new Action(null, DateTime.Today.AddDays(8), null, null, false, "5", null),
			new Action(null, DateTime.Today.AddDays(8), null, null, false, "6", null),
			new Action(null, DateTime.Today.AddMonths(2), null, null, false, "7", null),
			new Action(null, DateTime.Today.AddMonths(2), null, null, false, "8", null),
		};

		[TestMethod]
		public void Today()
		{
			var sorted = SortedActions.FromList(Actions);

			Assert.AreEqual(2, sorted.Today.Count());
			Assert.IsTrue(sorted.Today.All(a => a.Date == DateTime.Today));
		}

		[TestMethod]
		public void ThisWeek()
		{
			Calendar calendar = null;
			if (DateTimeFormatInfo.CurrentInfo != null)
			{
				calendar = DateTimeFormatInfo.CurrentInfo.Calendar;
			}

			var sorted = SortedActions.FromList(Actions);

			Assert.AreEqual(2, sorted.ThisWeek.Count());
			Assert.IsTrue(sorted.ThisWeek.All(a => calendar.GetWeekOfYear(a.Date, CalendarWeekRule.FirstDay, DayOfWeek.Monday) ==
			                                       calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstDay, DayOfWeek.Monday)));
		}

		[TestMethod]
		public void ThisMonth()
		{
			var sorted = SortedActions.FromList(Actions);

			Assert.AreEqual(2, sorted.ThisMonth.Count());
			Assert.IsTrue(sorted.ThisMonth.All(a => a.Date.Month == DateTime.Today.Month));
		}

		[TestMethod]
		public void Remainder()
		{
			var sorted = SortedActions.FromList(Actions);

			Assert.AreEqual(2, sorted.Remainder.Count());
			Assert.IsTrue(sorted.Remainder.All(a => a.Date.Month > DateTime.Today.Month));
		}
	}
}