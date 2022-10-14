using System;
class Program
{
	static void Main(string[] args)
	{
		try
		{
			FailProcess();
		}
		catch { }

		Console.WriteLine("Failed to fail process!");
		Console.ReadKey();
	}

	static void FailProcess()
	{
		Environment.Exit(0); //завершение текущего процесса с кодом выхода '0'
	}
}