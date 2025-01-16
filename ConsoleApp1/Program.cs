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
        }
        // Aqui uso el "primary constructor" para definir la clase (definir constructor y la clase a la vez)
        public class Molecule(string name, string formula, double weight)
        {
            public string Name { get; set; } = name;
            public string Formula { get; set; } = formula;
            public double Weight { get; set; } = weight;
        }
        Matrix SolveEquation(Matrix equation)
        {
            Matrix matrix = new(equation.Rows, equation.Cols - 1);  // Matriz de coeficientes
            for (int i = 0; i < equation.Rows; i++)
                for (int j = 0; j < equation.Cols - 1; j++)
                    matrix[i, j] = equation[i, j];

            Matrix results = new(equation.Rows, 1); // Matriz de términos independientes
            for (int i = 0; i < equation.Rows; i++)
                results[i, 0] = equation[i, equation.Cols - 1];

            Matrix invMatrix = matrix.Inverse();
            Matrix solution = invMatrix * results;
            return solution;
        }
    }
}
