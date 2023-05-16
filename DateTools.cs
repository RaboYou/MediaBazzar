using System;
using System.Collections.Generic;
using System.Globalization;

namespace MediaBazaar
{
	/// <summary>
	/// Static class to use for week number conversions
	/// </summary>
	public static class DateTools
	{
		/// <summary>
		/// this thing is so strange that I don't even remember why I wrote it, but it works with month calendar component,
		/// I know that week numbering used in EU is ISO-8601, that this component does not follow, but it works for this purpose
		/// </summary>
		/// <param name="time">this parameter has to have year value of the year that we want to view</param>
		/// <returns>the first day of the first week of the year</returns>
		/// <remarks>this whole thing is not as straight forward and obvious as it seems</remarks>
		private static DateTime WeekOne(DateTime time)
		{
			var year = time.Year;
			var first = Convert.ToDateTime($"{year}-1-1");
			var weekOfFirst = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(first, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

			if (weekOfFirst != 1)
			{
				switch (first.DayOfWeek)
				{
					case DayOfWeek.Monday:
						return first.AddDays(7);
					case DayOfWeek.Tuesday:
						return first.AddDays(6);
					case DayOfWeek.Wednesday:
						return first.AddDays(5);
					case DayOfWeek.Thursday:
						return first.AddDays(4);
					case DayOfWeek.Friday:
						return first.AddDays(3);
					case DayOfWeek.Saturday:
						return first.AddDays(2);
					case DayOfWeek.Sunday:
						return first.AddDays(1);
				}
			}
			else
			{
				switch (first.DayOfWeek)
				{
					case DayOfWeek.Monday:
						return first;
					case DayOfWeek.Tuesday:
						return first.AddDays(-1);
					case DayOfWeek.Wednesday:
						return first.AddDays(-2);
					case DayOfWeek.Thursday:
						return first.AddDays(-3);
					case DayOfWeek.Friday:
						return first.AddDays(-4);
					case DayOfWeek.Saturday:
						return first.AddDays(-5);
					default:
						return first.AddDays(-6);
				}
			}
			return first;
		}

		/// <summary>
		/// This calculates the date span of the desired week
		/// </summary>
		/// <param name="currentWeekNumber">number of the week which needs to be returned</param>
		/// <returns>List of dates of the desired week</returns>
		public static List<DateTime> CurrentWeekRange(int currentWeekNumber)
		{
			var weekRange = new List<DateTime>();
			var firstWeekOfTheYear = WeekOne(DateTime.Now);
			currentWeekNumber = (currentWeekNumber - 1) * 7;
			firstWeekOfTheYear = firstWeekOfTheYear.AddDays(currentWeekNumber);
			for (var i = 0; i < 7; i++)
			{
				weekRange.Add(firstWeekOfTheYear.AddDays(i));
			}
			return weekRange;
		}

		/// <summary>
		/// This calculates the week number of the desired date
		/// </summary>
		/// <param name="date">date of which week number we want to calculate</param>
		/// <returns>week number of the desired date</returns>
		public static int DateToWeekNumber(DateTime date)
		{
			return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
		}
	}
}
