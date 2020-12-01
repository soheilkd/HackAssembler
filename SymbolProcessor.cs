using System.Collections.Generic;
using System.Linq;

namespace HackAssembler
{
	public class SymbolProcessor
	{
		private readonly SymbolDictionary Dictionary = new();

		public string[] Translate(string[] lines)
		{
			var output = new List<string>();
			foreach (var line in lines)
			{
				if (line[0] == '@' && !int.TryParse(line[1..], out _))
					output.Add("@" + Dictionary[line[1..]]);
				else
					output.Add(line);
			}
			return output.ToArray();
		}

		public void LoadSymbols(string[] lines)
		{
			int i = 0;
			foreach (var line in lines)
			{
				if (line.StartsWith("("))
					AddressSymbol(line, i);
				else
					i++;
			}
		}

		private void AddressSymbol(string symbol, int lineNumber)
		{
			symbol = symbol[1..(symbol.Length - 1)];
			Dictionary[symbol] = lineNumber;
		}

		public string[] RemoveSymbols(string[] lines)
		{
			var output = lines.Where(line => line[0] != '(');
			return output.ToArray();
		}
	}
}
