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
        
        //Inverse matrix function

        public Matrix Inverse()
        {
            if (Rows != Cols)
            {
                throw new InvalidOperationException("Matrix must be square");
            }
            var result = new Matrix(Rows, Cols);
            float det = Determinant();
            if (det == 0)
            {
                throw new InvalidOperationException("Matrix must be invertible");
            }
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    result[j, i] = Cofactor(i, j) / det;
                }
            }
            return result;
        }

        public float Determinant()
        {
            if (Rows != Cols)
            {
                throw new InvalidOperationException("Matrix must be square");
            }
            if (Rows == 2)
            {
                return Data[0, 0] * Data[1, 1] - Data[0, 1] * Data[1, 0];
            }
            float det = 0;
            for (int i = 0; i < Cols; i++)
            {
                det += (i % 2 == 0 ? 1 : -1) * Data[0, i] * Minor(0, i).Determinant();
            }
            return det;
        }
        /// <summary>
        /// Matriz de adjuntos
        /// </summary>
        public float Cofactor(int row, int col)
        {
            return (row + col) % 2 == 0 ? Minor(row, col).Determinant() : -Minor(row, col).Determinant();
        }

        public Matrix Minor(int row, int col)
        {
            var result = new Matrix(Rows - 1, Cols - 1);
            for (int i = 0, mi = 0; i < Rows; i++)
            {
                if (i == row) continue;
                for (int j = 0, mj = 0; j < Cols; j++)
                {
                    if (j == col) continue;
                    result[mi, mj] = Data[i, j];
                    mj++;
                }
                mi++;
            }
            return result;
        }
    }
}
