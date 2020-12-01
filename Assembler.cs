using System.IO;
using System.Linq;

namespace HackAssembler
{
	public class Assembler
	{
		SymbolProcessor SymbolProcessor = new();

		public void AssembleFile(string filePath)
		{
			var assembled = Assemble(filePath);
			File.WriteAllLines(filePath.Replace(".asm", ".hack"), assembled);
		}

		private string[] Assemble(string filePath)
		{
			var lines = File.ReadAllLines(filePath);
			var cleanLines = Cleaner.CleanLines(lines);
			SymbolProcessor.LoadSymbols(cleanLines);
			var replacedSymbols = SymbolProcessor.Translate(cleanLines);
			var final = SymbolProcessor.RemoveSymbols(replacedSymbols);
			return final.Select(line => TranslateLineToBinary(line)).ToArray();
		}

		private static string TranslateLineToBinary(string line)
		{
			if (line.StartsWith("@"))
				return AInstruction.Translate(line);
			else
				return CInstruction.Translate(line);
		}
	}
}
