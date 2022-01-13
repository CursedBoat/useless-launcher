using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using Figgle;

namespace useless_launcher
{
	class Startup
	{
		private ConsoleKey keyPressed;

		/// <summary>
		/// Runs the program.
		/// </summary>
		public void Start()
		{
			RunMainMenu(); // Runs the program
		}

		/// <summary>
		/// Sets the variables for the main menu.
		/// </summary>
		private void RunMainMenu()
		{
			Variables vars = new Variables(); // Dumb variable thing I did to make my life worse.
			string footer = vars.Name();

			string prompt = @$"
 ____ ___             .__                       .____                               .__                  
|    |   \______ ____ |  |   ____   ______ _____|    |   _____   __ __  ____   ____ |  |__   ___________ 
|    |   /  ___// __ \|  | _/ __ \ /  ___//  ___/    |   \__  \ |  |  \/    \_/ ___\|  |  \_/ __ \_  __ \
|    |  /\___ \\  ___/|  |_\  ___/ \___ \ \___ \|    |___ / __ \|  |  /   |  \  \___|   Y  \  ___/|  | \/
|______//____  >\___  >____/\___  >____  >____  >_______ (____  /____/|___|  /\___  >___|  /\___  >__|   
             \/     \/          \/     \/     \/        \/    \/           \/     \/     \/     \/

Welcome to << {vars.Title} >>.			
"; // Title screen ASCII art. Taken from https://patorjk.com/software/taag.
			string[] options = { "Play", "Credits", "Exit" };

			Menu mainMenu = new Menu(prompt, options, footer);
			int selectedIndex = mainMenu.Run(); // Runs the main menu.

			switch (selectedIndex)
			{
				case 0:
					Play();
					break;

				case 1:
					AboutInfo();
					break;

				case 2:
					Exit();
					break;
			}
		}

		private void Play()
		{
			play:
			Clear();
			WriteLine(FiggleFonts.Standard.Render("Play")); // Renders ASCII art with the help of Figgle

			WriteLine();
			BackgroundColor = ConsoleColor.DarkMagenta;

			Variables var = new Variables();
			WriteLine(@"
Unfortunately, the main part of the program is still under development.
And by that I mean I haven't done a single thing I spent 8 hours on this menu send help.
");

			BackgroundColor = ConsoleColor.Black;
			WriteLine("Press BACKSPACE to return to the main menu.");

			ConsoleKeyInfo keyInfo = ReadKey();
			keyPressed = keyInfo.Key;

			if (keyInfo.Key == ConsoleKey.Backspace)
			{
				RunMainMenu();
			}
			else
			{
				goto play;
			}
		}

		private void AboutInfo()
		{
			abt:
			Clear();
			WriteLine(FiggleFonts.Standard.Render("About UselessLauncher")); // Renders ASCII art with the help of Figgle
			
			WriteLine();
			BackgroundColor = ConsoleColor.DarkMagenta;

			Variables var = new Variables();
			WriteLine(var.About());

			BackgroundColor = ConsoleColor.Black;
			WriteLine("Press BACKSPACE to return to the main menu.");

			ConsoleKeyInfo keyInfo = ReadKey();
			keyPressed = keyInfo.Key;

			if (keyInfo.Key == ConsoleKey.Backspace)
			{
				RunMainMenu();
			}
			else
			{
				goto abt;
			}
		}

		/// <summary>
		/// The function which quits the console.
		/// </summary>
		private void Exit()
		{
			exit:
				Clear();

				Write("Are you sure you want to exit?");
				Console.BackgroundColor = ConsoleColor.DarkBlue; // Sets BG color for confirmation text
			
				Write(" y/n");
				BackgroundColor = ConsoleColor.Black;

				WriteLine();
				Write("Confirmation: ");
				string conf = ReadLine();

				if (conf == "y") // If the user wants to exit
				{
					Environment.Exit(0); // Exits the console
				}
				else if (conf == "n") // If the user does not want to exit
				{
					RunMainMenu(); // Returns them to the main menu.
				}
				else // If the user selected an invalid option
				{
					goto exit; // Returns them to the exit dialogue.
				}
		}
	}
}
