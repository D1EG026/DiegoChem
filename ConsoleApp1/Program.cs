using System.Numerics;
using System.Linq;
namespace ConsoleApp1
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What atom here?");
            //string s = Console.ReadLine();
            string s = "NaOH";
            var atoms = PeriodicTable.elements;
            //Console.WriteLine($"Atom: atomic number{atoms[s].number} atomic weight{atoms[s].weight} {atoms[s].valence.Length} valence numbers");
            List<AtomData> inputAtoms = MoleculeToAtoms(s, atoms);
            foreach (var atom in inputAtoms)
            {
                Console.WriteLine(PeriodicTable.GetSymbol(atom.number));
            }
        }
        // Por ahora solo moléculas con un átomo de cada
        private static List<AtomData> MoleculeToAtoms(string s, Dictionary<string, AtomData> atoms)
        {
            List<AtomData> currentAtoms = [];
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].ToString().IsUpperCase())
                {
                    if (i != s.Length - 1 && !s[i + 1].ToString().IsUpperCase())
                        currentAtoms.Add(atoms[s[i].ToString() + s[i + 1].ToString()]); // Mayúscula-minúscula --> mismo elemento
                    else
                        currentAtoms.Add(atoms[s[i].ToString()]);                       // Mayúscula-mayúscula --> otro elemento
                }
            }
            return currentAtoms;
        }

        private static void PrintMatrix(Matrix matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; j++)
                {
                    Console.Write(matrix[i, j]);
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


