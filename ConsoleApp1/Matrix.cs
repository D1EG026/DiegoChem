using System;

namespace ConsoleApp1
{
    public struct Matrix(int rows, int cols)
    {
        public int Rows { get; } = rows;
        public int Cols { get; } = cols;
        public float[,] Data { get; } = new float[rows, cols];

        // Sobrecarga del operador []
        // Esto lo he descubierto hoy que se puede hacer
        public float this[int row, int col]
        {
            get => Data[row, col];
            set => Data[row, col] = value;
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
            {
                throw new InvalidOperationException("Matrices must have the same dimensions");
            }
            var result = new Matrix(a.Rows, a.Cols);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            return result;
        }
        //Esto no lo he hecho yo, lo ha hecho Copilot (wow no sabía que ocuparía tan poco)
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Cols != b.Rows)
            {
                throw new InvalidOperationException("Number of columns in the first matrix must be equal to the number of rows in the second matrix");
            }
            var result = new Matrix(a.Rows, b.Cols);

            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < b.Cols; j++)
                {
                    for (int k = 0; k < a.Cols; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return result;
        }
        public Matrix Inverse() // Esto falta por hacer
        {
            throw new NotImplementedException();
        }
    }
}
