// string 1: 1abc2
// string 2: pqr3stu8vwx
// string 3: a1b2c3d4e5f
// string 4: treb7uchet

// calibration value 1: 12
// calibration value 2: 38
// calibration value 3: 15
// calibration value 4: 77

using System;
using System.IO;
class Day1
{
	static void Main()
	{
		string[] input = File.ReadAllLines("input.txt");

		int[] output = new int[input.Length];
		int lineNum = 0;


		// loop through each line in the string
		foreach (string line in input)
		{
			char?[] cal = {null, null};
			char? temp = null;
			foreach (char index in line)
			{
//				Console.WriteLine(index);
//				Console.ReadKey();
				if (index <= '9' && index >= '0')
				{
					temp = index;
				}
				if (cal[0] == null && temp != null)
				{
					cal[0] = temp;
				}
				else if (cal[0] != null)
				{
					cal[1] = temp;
				}
			}
			if (cal[1] == null)
				cal[1] = cal[0];
			char[] temp2 = {Convert.ToChar(cal[0]), Convert.ToChar(cal[1])};
			string calVal = new string(temp2);

			output[lineNum] = Int32.Parse(calVal);
			lineNum++;
//			Console.WriteLine("calibration value for line " + lineNum + " is " + calVal);
		}


		// sum calibration values
		int sum = 0;
		for (int index2 = 0; index2 < output.Length; index2++)
		{
			sum += output[index2];
		}

		// print calibration values
		using (StreamWriter outputFile = new StreamWriter("output.txt"))
		{
			foreach (int line in output)
			{
				outputFile.WriteLine(Convert.ToString(line));
			}
			outputFile.WriteLine("Sum is " + Convert.ToString(sum));
		}
		//File.WriteAllText("output.txt", Convert.ToString(sum));
		return;
	}
}

