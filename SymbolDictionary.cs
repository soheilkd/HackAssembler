using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackAssembler
{
	public class SymbolDictionary
	{
		private readonly Dictionary<string, int> MainDictionary = new()
		{
			{ "SCREEN", 16384 },
			{ "KBD", 24576 },
			{ "SP", 0 },
			{ "LCL", 1 },
			{ "ARG", 2 },
			{ "THIS", 3 },
			{ "THAT", 4 }
		};
		private int LastVariableLocation = 0;

		public int this[string symbol]
		{
			get => GetOrCreateValue(symbol);
			set => MainDictionary[symbol] = value;
		}

		public SymbolDictionary()
		{
			//Initialize R0 .. R15
			foreach (var item in Enumerable.Range(0, 15))
				GetOrCreateValue("R" + item.ToString());
		}
		
		//Gets value of symbol. If it doesnt exist, creates a new value and returns it
		private int GetOrCreateValue(string symbol)
		{
			if (MainDictionary.TryGetValue(symbol, out var value))
				return value;
			else
			{
				MainDictionary.Add(symbol, LastVariableLocation);
				LastVariableLocation++;
				return LastVariableLocation - 1;
			}
		}
	}
}
