using System;
using System.IO;
using Syste.Collections.Generic;

class Day2
{
	static void Main()
	{
		// Load input
		string[] input = File.ReadAllLines();

		// Separate games by line


		// Each line is 1 game
		foreach (string line in input)
		{
			// Neglect the game index at front of string:
			int colonIndex = line.IndexOf(":");
			int semicolonIndex = 0;
			// Separate the game into multiple showings
			
			// Use Dictionaries to encode a showing
			
			// Use Lists to group showings into a game
			
			List<Dictionary> game = new List<Dictionary>();
			// Separate each showing into a color-count pair
			
			// Compare the Color-count pairs to the total number of each dice color
			
			// Game is invalid if any color count is greater than its relevant # of dice
			// Otherwise the game is valid
			
			// Repeat for each game
		}

		// showings are separated by semicolons
		// Define each
	}
}
