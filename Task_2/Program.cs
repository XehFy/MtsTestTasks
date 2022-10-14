using System;
using System.Globalization;

class Program
{
	static readonly IFormatProvider _ifp = CultureInfo.InvariantCulture;

	class Number
	{
		readonly int _number;

		public Number(int number)
		{
			_number = number;
		}

		public override string ToString()
		{
			return _number.ToString(_ifp);
		}

		public static string operator + (Number someValue1, string someValue2)
        {
			int someValue2Parsed;
			try
            {
				someValue2Parsed = Int32.Parse(someValue2); //преобразование правого операнда в численный формат 
            }
			catch (FormatException ex)
            {
				return ex.Message; //возвращение текста исключения в случае неудачного преобразования
            }
			int result = someValue1._number + someValue2Parsed; //сложение операндов
			return result.ToString();
        }
	}

	static void Main(string[] args)
	{
		int someValue1 = 10;
		int someValue2 = 5;

		string result = new Number(someValue1) + someValue2.ToString(_ifp);
		Console.WriteLine(result);
		Console.ReadKey();
	}
}
