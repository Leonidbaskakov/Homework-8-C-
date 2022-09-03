//Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

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

int[,] result = FillArray(5, 5, 0, 10);
PrintArr(result);

int SumElemLine(int[,] array, int i) //Нахождение суммы в первой строке
{
  int sumLine = array[i,0];
  for (int j = 1; j < array.GetLength(1); j++)
  {
    sumLine += array[i,j];
  }
  return sumLine;
}

int minSumLine = 0; // минимальная сумма строки
int sumLine = SumElemLine(result, 0); //сумма в первой строке

for (int i = 1; i < result.GetLength(0); i++)//проверяем сумму строк начиная со второй
{
  int tempSumLine = SumElemLine(result, i);
  if (sumLine > tempSumLine)
  {
    sumLine = tempSumLine;
    minSumLine = i;
  }
}

Console.WriteLine($"{minSumLine+1} строкa с наименьшей суммой элементов");