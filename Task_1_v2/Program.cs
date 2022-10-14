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
		System.Diagnostics.Process currentProcess = System.Diagnostics.Process.GetCurrentProcess(); //Получение доступа к текущему процессу
		currentProcess.Kill(); //принудительное завершение процесса
	}
}