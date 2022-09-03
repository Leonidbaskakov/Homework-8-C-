//Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

Console.Write("Введите количество строк первой матрицы ");
int row = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов первой матрицы (строки второй матрицы будут те же) ");
int col = Convert.ToInt32(Console.ReadLine());
int row1 = col;
Console.Write("Введите количество столбцов второй матрицы ");
int col1 = Convert.ToInt32(Console.ReadLine());

int[,] FillFirstMatrix(int row1, int col1, int min, int max)
{
    int[,] array = new int[row1, col1];

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

void PrintFirstMatrix(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.Write("[");
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (j < array.GetLength(1) - 1) Console.Write($"{array[i, j],2},");
            else Console.Write($"{array[i, j],2}");
        }
        Console.WriteLine("]");
    }
}

int[,] result = FillFirstMatrix(row, col, 0, 10);
PrintFirstMatrix(result);
Console.WriteLine();

int[,] FillSecondMatrix(int row2, int col2, int min, int max)
{
    int[,] array = new int[row2, col2];

    Random rnd = new Random();

    for (int k = 0; k < array.GetLength(0); k++) //перебор строк
    {
        for (int f = 0; f < array.GetLength(1); f++) //перебор столбцов
        {
            array[k, f] = rnd.Next(min, max + 1);
        }
    }
    return array;
}

void PrintSecondMatrix(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.Write("[");
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (j < array.GetLength(1) - 1) Console.Write($"{array[i, j],2},");
            else Console.Write($"{array[i, j],2}");
        }
        Console.WriteLine("]");
    }
}

int[,] secondresult = FillSecondMatrix(row1, col1, 0, 10);
PrintSecondMatrix(secondresult);

Console.WriteLine();
Console.WriteLine("Произведение двух матриц");



void FillNewMatrix(int[,] FillFirstMatrix, int[,] FillSecondMatrix, int[,] newmatrix)
{
    for (int i = 0; i < newmatrix.GetLength(0); i++) //перебор строк
    {
        for (int j = 0; j < newmatrix.GetLength(1); j++) //перебор столбцов
        {
            int sum = 0;
            for (int k = 0; k < FillFirstMatrix.GetLength(1); k++)
            {
                sum += FillFirstMatrix[i, k] * FillSecondMatrix[k, j];
            }
            newmatrix[i, j] = sum;
        }
    }
}

void PrintNewMatrix(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.Write("[");
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (j < array.GetLength(1) - 1) Console.Write($"{array[i, j],2},");
            else Console.Write($"{array[i, j],2}");
        }
        Console.WriteLine("]");
    }
}

int[,] newmatrix = new int[row, col1];

FillNewMatrix(result, secondresult, newmatrix);
PrintNewMatrix(newmatrix);