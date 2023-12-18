using System;
using System.IO;
using System.Collections.Generic;
class Day2
{
	static void Main()
	{
		// store input
		string[] input = File.ReadAllLines("input.txt");

		Game[] gameSet = new Game[100];
		int gameIndex = 0;
		foreach(string line in input)
		{
			colorCount[] lineVals = readData(csvParse(line));
			gameSet[gameIndex] = new Game(gameIndex, lineVals.Length, lineVals);
			gameIndex++;
		}
		int sumOfIndexes = 0;
		using (StreamWriter outputFile = new StreamWriter("output.txt"))
		{
			foreach(Game game in gameSet)
			{
				outputFile.WriteLine("Game {gameSet.index} is "
				+ (game.IsValid ? "valid" : "invalid"));
				if(game.IsValid) sumOfIndexes += game.GameIndex;
			}
			outputFile.WriteLine("Sum of indexes is {sumOfIndexes}");
		}
		return;
	}


	static string[] csvParse(string line)
	{
		// identify locaitons of the commas in the provided string
		List<int> commaIndices = new List<int>();


		// create int array containing colon and comma locations
		for (int loopIndex1 = 0; loopIndex1 < line.Length; loopIndex1++)
		{
			if (line[loopIndex1] == ':' || line[loopIndex1] == ',')
			{
				commaIndices.Add(loopIndex1);
			}
		}

		// string.Substring values between commas and colons
		string[] returnString = new string[commaIndices.Count];
		for (int loopIndex2 = 0; loopIndex2 < commaIndices.Count; loopIndex2++)
		{
			if (loopIndex2 < commaIndices.Count - 1)
			{
				returnString[loopIndex2] = line.Substring(commaIndices[loopIndex2],
				commaIndices[loopIndex2 + 1] - 1);
			}
			else
			{
				returnString[loopIndex2] = line.Substring(commaIndices[loopIndex2]);
			}
		}

		return returnString;
	}

	static colorCount[] readData (string[] delimitedString)
	{
		// parse data from delimited values
		colorCount[] returnColorCount = new colorCount[delimitedString.Length];

		for (int outerIndex = 0; outerIndex < delimitedString.Length; outerIndex++)
		{
			string count = "";
			string color = "";
			string stringElement = delimitedString[outerIndex];
			for (int innerIndex = 0; innerIndex < stringElement.Length; innerIndex++)
			{
				char charElement = stringElement[outerIndex];
				if (charElement >= '0' && 
				charElement <= '9')
				{
					count += charElement;
				}
				else if (charElement >= 'a' && 
				charElement <= 'z' ||
				charElement >= 'A' &&
				charElement <= 'Z')
				{
					color += charElement;
				}
			}
			returnColorCount[outerIndex].Count = Convert.ToInt32(count);
			returnColorCount[outerIndex].Color = color;
		}
		return returnColorCount;
	}


	public struct colorCount
	{
		public string Color;
		public int Count;
		colorCount(string color, int count)
		{
			Color = color;
			Count = count;
		}
	}


	public class Game
	{
		public int GameIndex;
		public int NumShows;
		public colorCount[] ColorCount;
		public bool IsValid = true;

		public Game(int gameIndex, int numShows, colorCount[] sets)
		{
			GameIndex = gameIndex;
			NumShows = numShows;
			ColorCount = sets;
		}

		public void CheckValid()
		{
			for (int setIndex = 0; setIndex < ColorCount.Length; setIndex++)
			{
				bool redInvalid = (ColorCount[setIndex].Color == "red" 
				&& ColorCount[setIndex].Count > 12);
				bool greenInvalid = (ColorCount[setIndex].Color == "green"
				&& ColorCount[setIndex].Count > 13);
				bool blueInvalid = (ColorCount[setIndex].Color == "blue"
				&& ColorCount[setIndex].Count > 14);
				if (redInvalid | greenInvalid | blueInvalid)
				{
					IsValid = false;
				}
			}
		}
	}
}
