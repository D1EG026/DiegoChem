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
            string s = "Fe2S3";
            var atoms = PeriodicTable.elements;
            //Console.WriteLine($"Atom: atomic number{atoms[s].number} atomic weight{atoms[s].weight} {atoms[s].valence.Length} valence numbers");
            List<AtomData> inputAtoms = MoleculeToAtoms(s, atoms);
            foreach (var atom in inputAtoms)
            {
                Console.WriteLine(PeriodicTable.GetSymbol(atom.number));
            }
        }
        // Por ahora sin paréntesis
        private static List<AtomData> MoleculeToAtoms(string s, Dictionary<string, AtomData> atoms)
        {
            List<AtomData> currentAtoms = [];
            AtomData atomToadd = null;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].ToString().IsUpperCase())  // Letra mayúscula
                {
                    int nextPossibleNumberIndex;
                    if (i != s.Length - 1 && s[i + 1].ToString().IsLowerCase())
                    {
                        atomToadd = atoms[s[i].ToString() + s[i + 1].ToString()]; // Mayúscula-minúscula --> mismo elemento
                        nextPossibleNumberIndex = i + 2;
                    }
                    else
                    {
                        atomToadd = atoms[s[i].ToString()];                       // Mayúscula-mayúscula --> otro elemento
                        nextPossibleNumberIndex = i + 1;
                    }
                    if (nextPossibleNumberIndex >= s.Length || !s[nextPossibleNumberIndex].ToString().IsNumber())   // Si no hay número despues del átomo
                        currentAtoms.Add(atomToadd);
                }
                else if (s[i].ToString().IsNumber()) // Número
                {
                    for (int k = 0; k < int.Parse(s[i].ToString()); k++)
                    {
                        currentAtoms.Add(atomToadd);
                    }
                    //while (j < s.Length && s[j].ToString().IsNumber())
                    //   j++;
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


