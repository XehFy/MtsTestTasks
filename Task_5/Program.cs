using System;

// Придумал только запустить задачу очистки экрана и вывода слона асинхронно, так, чтобы она выполнилась после вывода мухи

class Program
{
	static void Main(string[] args)
	{
		TransformToElephant();
		Console.WriteLine("Муха");
		//... custom application code
	}

	static void TransformToElephant()
	{       //... write your code here 	}
		Task.Run(async () =>
		{
			Console.Clear();
			Console.WriteLine("Слон");
			await Task.Delay(10);
		});
	}
}
