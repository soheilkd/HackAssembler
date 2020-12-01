using System.Collections.Generic;

namespace HackAssembler
{
	public static class CInstruction
	{
		private static readonly Dictionary<string, string> comps = new()
		{
			{ "0", "101010" },
			{ "1", "111111" },
			{ "-1", "111010" },
			{ "D", "001100" },
			{ "A", "110000" },
			{ "!D", "001101" },
			{ "!A", "110001" },
			{ "-D", "001111" },
			{ "-A", "110011" },
			{ "D+1", "011111" },
			{ "A+1", "110111" },
			{ "D-1", "001110" },
			{ "A-1", "110010" },
			{ "D+A", "000010" },
			{ "D-A", "010011" },
			{ "A-D", "000111" },
			{ "D&A", "000000" },
			{ "D|A", "010101" }
		};
		private static readonly Dictionary<string, string> dests = new()
		{
			{ "AMD", "111" },
			{ "AD", "110" },
			{ "AM", "101" },
			{ "A", "100" },
			{ "MD", "011" },
			{ "D", "010" },
			{ "M", "001" },
		};
		private static readonly Dictionary<string, string> jumps = new()
		{
			{ "NOJUMP", "000" },
			{ "JGT", "001" },
			{ "JEQ", "010" },
			{ "JGE", "011" },
			{ "JLT", "100" },
			{ "JNE", "101" },
			{ "JLE", "110" },
			{ "JMP", "111" },
		};

		public static string Translate(string input)
		{
			var output = "111";
			output += ProcessComp(input);
			output += ProcessDest(input);
			output += ProcessJump(input);
			return output;
		}

		private static string TranslateComp(string comp)
		{
			string aBit = comp.Contains("M") ? "1" : "0";
			comp = comp.Replace("M", "A");
			return aBit + comps[comp];
		}
		private static string ProcessComp(string input)
		{
			var comp = "";
			var index1 = input.IndexOf("=") + 1;
			var index2 = input.IndexOf(";");
			if (input.Contains("=") && input.Contains(";"))
				comp = input[index1..index2];
			else if (input.Contains("="))
				comp = input[index1..];
			else if (input.Contains(";"))
				comp = input[..index2];
			return TranslateComp(comp);
		}

		private static string TranslateDest(string dest)
		{
			return dests.ContainsKey(dest) ? dests[dest] : "000";
		}
		private static string ProcessDest(string input)
		{
			var index1 = input.IndexOf("=");
			return index1 != -1 ? TranslateDest(input[..index1]) : "000";
		}

		private static string ProcessJump(string input)
		{
			var jump = input.Contains(";") ? input[(input.IndexOf(";") + 1)..] : "NOJUMP";
			return jumps[jump];
		}
	}
}
