using System;
using Parser;

namespace ConsoleApp
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var x = new TimeTable("http://hint.hro.nl/xsp/rooster/iCal.xsp/0912837-1879302.ics");
		}
	}
}