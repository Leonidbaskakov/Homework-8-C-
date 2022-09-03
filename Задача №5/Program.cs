//Задайте двумерный массив из целых чисел.
//Напишите программу, которая удалит строку и столбец, на пересечении которых расположен наименьший элемент массива.

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
            if (j < array.GetLength(1) - 1) Console.Write($"{array[i, j],3},");
            else Console.Write($"{array[i, j],3}");
        }
        Console.WriteLine("]");
    }
}

int[,] result = FillArray(3, 4, 0, 30);
PrintArr(result);
Console.WriteLine();

int[] MinSearch(int[,] array)
{
    int[] newar = new int[3];
    int index = 0;
    int min = array[0, 0];
    int jndex = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] < min)
            {
                min = array[i, j];
                index = i;
                jndex = j;
            }
        }
    }
    newar[0] = min;
    newar[1] = index;
    newar[2] = jndex;
    Console.WriteLine($"Mинимальный элемент: {newar[0]}");
    return newar;
}

int[] poselem = MinSearch(result);

void FillNewArr(int[,] array, int[] positionElement, int[,] arrayWithoutLines)
{
  int k = 0, l = 0;
  for (int i = 0; i < array.GetLength(0); i++)
  {
    for (int j = 0; j < array.GetLength(1); j++)
    {
      if (positionElement[1] != i && positionElement[2] != j)
      {
        arrayWithoutLines[k, l] = array[i, j];
        l++;
      }
    }
    l = 0;
    if (positionElement[1] != i)
    {
      k++;
    }
  }
}

void PrintNewArr(int[,] array)
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



int[,] arrayWithoutLines = new int[result.GetLength(0) - 1, result.GetLength(1) - 1];
FillNewArr(result,poselem,arrayWithoutLines);

PrintNewArr(arrayWithoutLines);