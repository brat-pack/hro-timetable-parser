using System;
using System.Collections.Generic;

namespace Parser
{
	public class Classroom
	{
		public string Id { get; set; }
		public List<Event> Events { get; set; }

		public Classroom(string id)
		{
			Id = id;
			Events = new List<Event>();
		}
	}
}
