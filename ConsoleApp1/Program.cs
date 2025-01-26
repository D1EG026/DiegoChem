using System.Numerics;
using System.Linq;
using System.Collections;
namespace ConsoleApp1
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What atom here?");
            //string s = Console.ReadLine();
            string s = "H2ClNe2H3";
            var atoms = PeriodicTable.elements;
            //Console.WriteLine($"Atom: atomic number{atoms[s].number} atomic weight{atoms[s].weight} {atoms[s].valence.Length} valence numbers");
            List<Token> inputAtoms = MoleculeToAtoms(s, atoms);
            foreach (var atom in inputAtoms)
            {
                Console.WriteLine(PeriodicTable.GetSymbol(atom.Atom.number) + " " + atom.Count);
            }
        }
        // Por ahora sin paréntesis
        private static List<Token> MoleculeToAtoms(string s, Dictionary<string, AtomData> atoms)
        {
            int parenthesisOpen = 0;
            List<AtomData> parenthesisAtoms = new();
            List<AtomData> currentAtoms = [];
            List<Token> tokens = [];
            Token token = default;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].ToString().IsUpperCase())  // Letra mayúscula
                {
                    token = GetTokenFromIndesx(s, atoms, ref i);
                    tokens.Add(token);
                }
                // else if (s[i].ToString() == "(")
                // {
                //     //parenthesisOpen++;
                //     tokens.Add(token);
                // }
                // else if (s[i].ToString() == ")")
                // {
                //     if (token[i + 1].ToString().IsNumber()) // Si hay número después del paréntesis
                //     {
                //         //token.Multiply(int.Parse(token[i + 1].ToString()));
                //         token.Count = int.Parse(token[i + 1].ToString());
                //     }
                //     currentAtoms.AddRange(token);
                // }
                // else
                //     currentAtoms.AddRange(token);
            }
            return tokens;
        }
        /// <summary>
        /// Devuelve un token de la cadena de entrada a partir de una posición dada. i es la última posición del token.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="atoms"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        private static Token GetTokenFromIndesx(string s, Dictionary<string, AtomData> atoms, ref int i)
        {
            AtomData atomToAdd;
            Token token = new();
            int nextPossibleNumberIndex;
            if (i != s.Length - 1 && s[i + 1].ToString().IsLowerCase()) // Mayúscula-minúscula --> mismo elemento
            {
                token = atoms[s[i].ToString() + s[i + 1].ToString()]; 
                nextPossibleNumberIndex = i + 2;
            }
            else                                                        // Mayúscula-mayúscula --> otro elemento
            {
                token = atoms[s[i].ToString()];
                nextPossibleNumberIndex = i + 1;
            }

            if (s[nextPossibleNumberIndex].ToString().IsNumber()) // Si hay número después del átomo
            {
                token.Count = int.Parse(s[nextPossibleNumberIndex].ToString());
            }
            i = nextPossibleNumberIndex - 1;
            return token;
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
        class SubMolecule(List<AtomData> atoms) : IEnumerable<AtomData>
        {
            List<AtomData> Atoms = atoms;
            public void Multiply(int n)
            {
                List<AtomData> newAtoms = [];
                foreach (var atom in Atoms)
                {
                    for (int i = 1; i <= n; i++)
                    {
                        newAtoms.Add(atom);
                    }
                }
                Atoms.AddRange(newAtoms);
            }
            public static implicit operator List<AtomData>(SubMolecule subMolecule) => subMolecule.Atoms;
            public IEnumerator<AtomData> GetEnumerator() => Atoms.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            // Implementación del indexador
            public AtomData this[int index]
            {
                get => Atoms[index];
                set => Atoms[index] = value;
            }
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
