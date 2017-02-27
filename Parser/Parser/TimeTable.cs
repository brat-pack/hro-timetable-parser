using System;
using System.Collections.Generic;
using Ical.Net;
using Ical.Net.Interfaces;
using System.Net;

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
			var request = WebRequest.Create(icsUrl);
			var x = request.GetResponse();
		 	var ICalCollection = Calendar.LoadFromStream(x.GetResponseStream());
			var iCalCalendar = ICalCollection[0];
			foreach (var iCalEvent in iCalCalendar.Events)
			{
				if (iCalEvent.Location != null)
				{
					var classroom = FindOrCreateClassroom(iCalEvent.Location);
					var newEvent = new Event(iCalEvent, classroom);
					if (!newEvent.isHoliday())
					{
						classroom.Events.Add(newEvent);
						Events.Add(newEvent);
					}
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
