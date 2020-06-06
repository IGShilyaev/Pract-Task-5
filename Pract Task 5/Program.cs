using System;

namespace Pract_Task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размерность квадратной матрицы: ");
            int n = EnterIntNumber();
            double[,] matrix = CreateMatrix(n);

            double resBelow = MatrixSumDown(matrix);
            double resOn = MatrixSumOn(matrix);
            double resAbove = MatrixSumUp(matrix);

            Console.WriteLine();
            Console.WriteLine("Для строк, начинающихся с отрицательного элемента:");
            Console.WriteLine($"Сумма элементов ниже главной диагонали = {resBelow}");
            Console.WriteLine($"Сумма элементов на главной диагонали = {resOn}");
            Console.WriteLine($"Сумма элементов выше главной диагонали = {resAbove}");
        }


        static double MatrixSumDown(double[,] matrix)
        {
            double sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++) if (matrix[i, 0] < 0)
                    for (int j = 0; j < i; j++) sum += matrix[i, j];
            return sum;
        }

        static double MatrixSumOn(double[,] matrix)
        {
            double sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++) if (matrix[i, 0] < 0) sum += matrix[i, i];
            return sum;
        }

        static double MatrixSumUp(double[,] matrix)
        {
            double sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++) if (matrix[i, 0] < 0)
                    for (int j = i+1; j < matrix.GetLength(1); j++) sum += matrix[i, j];
            return sum;
        }

        static double[,] CreateMatrix(int n)
        {
            double[,] matrix = new double[n, n];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"Введите значение элемента {i + 1}-{j + 1} матрицы: ");
                    matrix[i, j] = EnterDoubleNumber();
                }
            return matrix;
        }

        static int EnterIntNumber()
        {
            bool ok = false;
            int n;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out n) && (n > 0);
                if (!ok) Console.Write("Ошибка! Не удалось преобразовать в натуральное число. Введите значение заново: ");
            } while (!ok);
            return n;
        }

        static double EnterDoubleNumber()
        {
            bool ok = false;
            double n;
            do
            {
                ok = double.TryParse(Console.ReadLine(), out n);
                if (!ok) { Console.Write("Ошибка! Не удалось преобразовать введенное значение в вещественное число. Введите другое значение: "); }
            } while (!ok);
            return n;
        }

    }
}
