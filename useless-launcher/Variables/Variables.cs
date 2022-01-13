using System;
using System.Collections.Generic;
using System.Text;

namespace useless_launcher
{
	public class Variables
	{
		public string Version = "0.0b1"; // Pretty self explanatory
		public string Title = "USELESS-LAUNCHER";
		
		/// <summary>
		/// Function for calling the name of the launcher.
		/// </summary>
		/// <returns>The name of the launcher with version number.</returns>
		public string Name()
		{
			string Name = $"{Title} v{Version}";
			return Name;
		}
		public string About()
		{
			string abt = @"
o Basically everything: SNTHE

Used external libraries:
	o FIGGLE (ASCII text generator) - https://github.com/drewnoakes/figgle
";
			return abt;
		}
	}
}
