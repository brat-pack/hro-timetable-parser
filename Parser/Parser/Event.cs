using System;
using Ical.Net;
using Ical.Net.Interfaces.Components;

namespace Parser
{
	public class Event
	{
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public string Description { get; set; }
		public Classroom Classroom { get; set; }

		public Event(DateTime startTime, DateTime endTime, string description, Classroom classroom)
		{
			StartTime = startTime;
			EndTime = endTime;
			Description = description;
			Classroom = classroom;
		}

		public Event(IEvent iEvent, Classroom classroom)
		{
			StartTime = iEvent.Start.AsUtc;
			EndTime = iEvent.End.AsUtc;
			Description = iEvent.Description;
			Classroom = classroom;
		}

		public bool isHoliday()
		{
			return EndTime.Hour - StartTime.Hour == 14;
		}
	}
}
