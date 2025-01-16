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


