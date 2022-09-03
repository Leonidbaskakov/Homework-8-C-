// Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.

int[,] FillArray(int row, int col, int min, int max)
{
    int[,] array = new int[row, col];

    Random rnd = new Random();

    for (int i = 0; i < array.GetLength(0); i++) //перебор строк
    {
        for (int j = 0; j < array.GetLength(1); j++) //перебор столбцов
        {
            array[i, j] = rnd.Next(min, max + 1);
        }
    }
    return array;
}

void PrintArr(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.Write("[");
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (j < array.GetLength(1) - 1) Console.Write($"{array[i, j],4},");
            else Console.Write($"{array[i, j],4}");
        }
        Console.WriteLine("]");
    }
}

int[,] result = FillArray(3, 4, 0, 10);
PrintArr(result);

Console.WriteLine();
Console.WriteLine("Отсартированный массив");

void FillNewArr(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++) //перебор строк
    {
        for (int j = 0; j < array.GetLength(1); j++) //перебор столбцов
        {
            for (int k = 0; k < array.GetLength(1)-1; k++)
            {
                if (array[i, k] < array[i, k + 1])
                {
                    int buf = array[i, k + 1];
                    array[i, k + 1] = array[i, k];
                    array[i, k] = buf;
                }
            }
        }
    }
}


FillNewArr(result);
PrintArr(result);