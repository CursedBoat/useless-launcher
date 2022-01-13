using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace useless_launcher
{
	class Menu
	{
		// Variables needed for the menu to work.
		private int selectedIndex;
		private string[] Options;
		private string Prompt;
		private string Footer;

		/// <summary>
		/// Defines the variables needed for the menu to work.
		/// </summary>
		/// <param name="prompt">Prompt for the menu.</param>
		/// <param name="options">Options that are displayed (ARRAY)</param>
		/// <param name="footer">Text shown in the bottom of the menu.</param>
		public Menu(string prompt, string[] options, string footer)
		{
			Prompt = prompt;
			Options = options;
			Footer = footer;
			selectedIndex = 0;
		}

		/// <summary>
		/// The main menu function that displays which option is selected.
		/// </summary>
		private void MenuOps()
		{
			WriteLine(Prompt);
			for(int i = 0; i < Options.Length; i++) // Loop runs until all the options are displayed
			{
				string currentOption = Options[i];
				string prefix;

				if(i == selectedIndex) // Sets the selected option's text to Black and BG to White
				{
					prefix = "*";
					ForegroundColor = ConsoleColor.Black;
					BackgroundColor = ConsoleColor.White;
				}
				else // Sets the non-selected options' text to White and BG to Black
				{
					prefix = " ";
					ForegroundColor = ConsoleColor.White;
					BackgroundColor = ConsoleColor.Black;
				}

				WriteLine($"{prefix} >> {currentOption} <<"); // Makes the options look like buttons
			}
			ResetColor(); // Resets color so that the footer isn't white
			WriteLine();
			WriteLine(Footer);
		}

		/// <summary>
		/// The actual command that lets the program know what to do.
		/// </summary>
		/// <returns>The number of the option selected.</returns>
		public int Run()
		{
			ConsoleKey keyPressed;
			do
			{
				Clear();
				MenuOps();

				ConsoleKeyInfo keyInfo = ReadKey();
				keyPressed = keyInfo.Key;

				// Update variable selectedIndex based on arrow key presses
				if(keyPressed == ConsoleKey.UpArrow)
				{
					if (selectedIndex > 0) // Doesn't let the selected index go above the last option
					{
						selectedIndex--;
					}
				}
				else if (keyPressed == ConsoleKey.DownArrow)
				{
					if (selectedIndex < Options.Length-1) // Doesn't let the selected index go below the last option
					{
						selectedIndex++;
					}
				}
			} while (keyPressed != ConsoleKey.Enter); // Runs the loop until ENTER is pressed

			return selectedIndex; // Returns the selected option so that the program can actually do stuff with it
		}
	}
}
