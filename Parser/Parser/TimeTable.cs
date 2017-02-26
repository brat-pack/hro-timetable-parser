using System;
using System.Collections.Generic;
using Ical.Net;
using Ical.Net.Interfaces;

namespace Parser
{
	public class TimeTable
	{
		private List<Event> _events = new List<Event>();
		private Dictionary<string, Classroom> _classrooms = new Dictionary<string, Classroom>();

		public List<Event> Events => _events;
		public Dictionary<string, Classroom> Classrooms => _classrooms;

		public TimeTable(string icsUrl)
		{
			var ICalCollection = Calendar.LoadFromFile("/Users/Moro/Downloads/0912837-1433428.ics");
			var iCalCalendar = ICalCollection[0];
			foreach (var iCalEvent in iCalCalendar.Events)
			{
				if (iCalEvent.Location != null)
				{
					var classroom = FindOrCreateClassroom(iCalEvent.Location);
					var newEvent = new Event(iCalEvent, classroom);
					classroom.Events.Add(newEvent);
					Events.Add(newEvent);
				}
			}
		}

		private Classroom FindOrCreateClassroom(string id)
		{
			if (!Classrooms.ContainsKey(id))
				Classrooms.Add(id, new Classroom(id));
			return Classrooms[id];
		}
	}
}
