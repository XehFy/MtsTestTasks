using System;

//  первый пришедший в голову вариант
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
// Другой вариант, перенаправить вывод из консоли в stringWriter 
// до появления слова "Муха", затем заменить первое вхождение мухи на слона, 
// вернуть стандартный вывод, вывести изменённое содержимое stringWriter. 
        static void TransformToElephant() 
        {       //... write your code here  } 
            var std =  Console.Out; 
            System.IO.StringWriter writer = new System.IO.StringWriter(); 
            Console.SetOut(writer); 
            new Thread(() => { 
                while (!writer.ToString().Contains("Муха")) 
                { 
                    Thread.Sleep(1000); 
                } 
                string sOut = writer.ToString(); 
                //sOut = sOut.Replace("Муха", "Слон"); 
                Console.SetOut(std); 
                string Replace = "Слон";
                string Find = "Муха";
                int Place = Source.IndexOf(Find);
                Source.Remove(Place, Find.Length).Insert(Place, Replace);
                Console.WriteLine(sOut); 
            }).Start(); 
        }
}
