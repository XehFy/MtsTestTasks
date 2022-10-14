using System;

public static class EnumerableExtension
{
	/// <summary>
	/// <para> Отсчитать несколько элементов с конца </para>
	/// <example> new[] {1,2,3,4}.EnumerateFromTail(2) = (1, ), (2, ), (3, 1), (4, 0)</example>
	/// </summary> 
	/// <typeparam name="T"></typeparam>
	/// <param name="enumerable"></param>
	/// <param name="tailLength">Сколько элеметнов отсчитать с конца  (у последнего элемента tail = 0)</param>
	/// <returns></returns>
	public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength)
    {
        if (tailLength == null || tailLength <= 0) // проверка на корректность переданного параметра длины хвоста
            return new List<(T item, int? tail)>(); // возвращение пустого списка в случае некорректного параметра

        IList<(T item, int? tail)> items = new List<(T item, int? tail)>();
        var count = enumerable.Count(); //получение количества элементов списка
        if (tailLength >= count) 
        {
            foreach (var item in enumerable)
            {
                items.Add((item, --count)); //если длина хвоста не меньше длины списка, то нумеруются все элементы списка 
            }
        }
        else
        {
            var i = 0; //счетчик элементов списка
            var n = count - tailLength; //n - количество элементов, которые не будут нумероваться. Иными словами, первые n элементов, при прямом обходе списка не нумеруются 
            foreach (var item in enumerable)
            {
                items.Add((item, i < n ? null : --tailLength ));
                i++;
            }
        }
        return items;
    }

}

class Program
{
	static void Main(string[] args)
	{
        var result = new[] { 1, 2, 3, 4 }.EnumerateFromTail(2);
        foreach (var item in result)
        {
            Console.Write(item + " ");
        }
    }


}
