using System;

/* Учитывая специфику входных данных, а именно очень большое количество элементов,
 * значения которых колеблятся в относительно маленьком диапазоне, я решил, что самым оптимальным 
 * алгоритмом для сортировки будет "сортировка подсчетом". 
 * 
 * Для хранения счетчика количества вхождений элементов в список использую словарь по описанной ниже причине
 * 
 * 
 * 
 * Для обязательного по сигнатуре параметра "sortFactor" не получилось придумать лучшего применения, чем создание с его помощью словаря, 
 * который будет содержать только ключи, равные значениям, которые могут встретиться во входных данных.
 * Потому что, как я понял, в итоге, условие "в потоке больше не встретится числа меньше, чем (x - sortFactor)"
 * сведется к тому, что sortFactor - это разность между максимальным и минимальным элементами, которые могут быть в потоке.
 * Исходя из этого можно сразу узнать диапазон для ключей словоря, что позволяет создать словарь минимального размера.
 * 
 * Сложность алгоритма по времени выходит линейная O(n + 2k), где n - количество элементов входного потока, k - количество возможных значений в потоке
 * Сложность по памяти получается плохая, хранение входных данных и списка для сохранения результата - 2n, и словарь-счетчик k. В итоге O(2n + k)
 * 
 */

class Program
{
    /// <summary>
    /// Возвращает отсортированный по возрастанию поток чисел
    /// </summary>
    /// <param name="inputStream">Поток чисел от 0 до maxValue. Длина потока не превышает миллиарда чисел.</param>
    /// <param name="sortFactor">Фактор упорядоченности потока. Неотрицательное число. Если в потоке встретилось число x, то в нём больше не встретятся числа меньше, чем (x - sortFactor).</param>
    /// <param name="maxValue">Максимально возможное значение чисел в потоке. Неотрицательное число, не превышающее 2000.</param>
    /// <returns>Отсортированный по возрастанию поток чисел.</returns>
    static IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
    {
        var size = inputStream.Count();
        var result = new int[size];
        //var occurrences = new int[maxValue + 1];
        Dictionary<int, int> occurrences = new Dictionary<int, int>();
        for (int i = maxValue - sortFactor; i <= maxValue; i++)
        {
            occurrences.Add(i, 0);
        }
        for (int i = 0; i < size; i++)
        {
            occurrences[inputStream.ElementAt(i)]++;
        }
        for (int i = maxValue - sortFactor, j = 0; i <= maxValue; i++)
        {
            while (occurrences[i] > 0)
            {
                result[j] = i;
                j++;
                occurrences[i]--;
            }
        }
        return result;
    }

    static void Main(string[] args)
    {
        int[] rndList = new int[10000];
        IEnumerable<int> resList = new int[10000];
        Random rand = new Random();

        for (int x = 0; x < 10000; x++)
        {
            rndList[x] = rand.Next(100, 2001);
            Console.Write(rndList[x] + " ");
        }
        resList = Sort(rndList, 1900, 2000);
        Console.WriteLine();
        Console.WriteLine();
        foreach (var item in resList)
        {
            Console.Write(item + " ");
        }
    }


}
