using System.Numerics;
using System.Linq;

namespace ConsoleApp1
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What atom here?");
            string s = Console.ReadLine();


            var atoms = PeriodicTable.elements;
            Console.WriteLine($"Atom: atomic number{atoms[s].number} atomic weight{atoms[s].weight} {atoms[s].valence.Length} valence numbers");
            //Do a test to check that solveequation works

            Matrix matrix = new(3, 3);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[0, 2] = 3;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;
            matrix[1, 2] = 5;
            matrix[2, 0] = -2;
            matrix[2, 1] = 0;
            matrix[2, 2] = -1;
            Matrix inverse = matrix.Inverse();

            Matrix expectedInverse = new Matrix(3, 3);
            expectedInverse[0, 0] = 1.0f / 3.0f;
            expectedInverse[0, 1] = 4.0f / 3.0f;
            expectedInverse[0, 2] = -2.0f / 3.0f;
            expectedInverse[1, 0] = 1.0f / 3.0f;
            expectedInverse[1, 1] = 5.0f / 6.0f;
            expectedInverse[1, 2] = -2.0f / 3.0f;
            expectedInverse[2, 0] = -1.0f / 3.0f;
            expectedInverse[2, 1] = 2.0f / 3.0f;
            expectedInverse[2, 2] = -1.0f / 3.0f;
            Console.WriteLine("Matrix: ");
            for (int i = 0; i < inverse.Rows; i++)
            {
                for (int j = 0; j < inverse.Cols; j++)
                {
                    Console.Write(inverse[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Expected");
            for (int i = 0; i < expectedInverse.Rows; i++)
            {
                for (int j = 0; j < expectedInverse.Cols; j++)
                {
                    Console.Write(expectedInverse[i, j]);
                }
                Console.WriteLine();
            }
        }
        // Aqui uso el "primary constructor" para definir la clase (definir constructor y la clase a la vez)
        public class Molecule(string name, string formula, double weight)
        {
            public string Name { get; set; } = name;
            public string Formula { get; set; } = formula;
            public double Weight { get; set; } = weight;
        }
        Matrix SolveLinearSystem(Matrix system)
        {
            Matrix coefficients = new(system.Rows, system.Cols - 1);  // Matriz de coeficientes
            for (int i = 0; i < system.Rows; i++)
                for (int j = 0; j < system.Cols - 1; j++)
                    coefficients[i, j] = system[i, j];

            Matrix results = new(system.Rows, 1); // Matriz de términos independientes
            for (int i = 0; i < system.Rows; i++)
                results[i, 0] = system[i, system.Cols - 1];

            try
            {
                Matrix invMatrix = coefficients.Inverse();
                Matrix solution = invMatrix * results;
                return solution;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("System has no solution");
                return new Matrix(2, 2);
            }
        }
    }
}


