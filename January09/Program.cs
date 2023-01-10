using System.Diagnostics;

// Задан массив, нужно найти максимальную сумму трех элементов
// array - 10
// m - 3

// i               ` 
//   1 5 4 1 3 4 7 4 1 2
// j               ^ ^ ^

// m - 3
// MAX -> 15

int size = 1_0;

int m = 3;

int[] array = Enumerable.Range(1, size)
                        .Select(item => Random.Shared.Next(10))
                        .ToArray();
Console.WriteLine($"[{string.Join(" ", array)}]");

// Stopwatch sw = new();
// sw.Start();

// Вариант 1 не самый удачный
// int max = 0;
// for (int i = 0; i < array.Length - m; i++)
// {
//     int t = 0;
//     for (int j = i; j < i + m; j++)
//     {
//         t = t + array[j];
//         if (t > max) max = t;
//     }
// }

// sw.Stop();

// Console.WriteLine(max);


Stopwatch sw = new();
sw.Start();

int max1 = 0;
for (int j = 0; j < m; j++) max1 += array[j];
int t1 = max1;
for (int i = 1; i < array.Length - m; i++)
{
    t1 = t1 - array[i - 1] + array[i + (m - 1)];
    if (t1 > max1) max1 = t1;
}

sw.Stop();
Console.WriteLine($"time = {sw.ElapsedMilliseconds}");

Console.WriteLine($"вариант 2: {max1}");