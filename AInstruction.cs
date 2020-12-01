using System;

namespace HackAssembler
{
	public static class AInstruction
	{
		public static string Translate(string value)
		{
			var numString = value[1..];
			var num = int.Parse(numString);
			return "0" + NumberToBinary(num);
		}

		private static string NumberToBinary(int number)
		{
			var output = Convert.ToString(number, 2);
			while (output.Length < 15)
				output = output.Insert(0, "0");
			return output;
		}
	}
}
