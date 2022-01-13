using System;

namespace useless_launcher
{
	class Program
	{
		static void Main()
		{
			Console.CursorVisible = false; // Hides cursor.
			Startup startLauncher = new Startup(); // Starts the program.
			startLauncher.Start();
		}
	}
}
