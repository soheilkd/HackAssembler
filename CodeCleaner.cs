using System.Collections.Generic;

namespace HackAssembler
{
	public static class Cleaner
	{
		public static string[] CleanLines(string[] lines)
		{
			var newLines = new List<string>();
			foreach (var line in lines)
			{
				var newLine = CleanLine(line);
				if (string.IsNullOrWhiteSpace(newLine))
					continue;
				newLines.Add(newLine);
			}
			return newLines.ToArray();
		}

		public static string CleanLine(string line)
		{
			if (line.Contains("/"))
				line = line[..line.IndexOf("/")];
			line = line.Replace(" ", "");
			return line;
		}
	}
}
