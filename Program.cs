using System;
using System.IO;
using System.Linq;

namespace HackAssembler
{
	class Program
	{
		static void Main(string[] args)
		{
			var assembler = new Assembler();
			if (args.Length <= 1)
			{
				while (true)
				{
					Console.WriteLine("Enter path: ");
					var path = Console.ReadLine();
					assembler.AssembleFile(path);
					Console.WriteLine("Done");
				}
			}
			else
			{
				foreach (var arg in args.Skip(1))
					assembler.AssembleFile(arg);
			}
		}
	}
}
