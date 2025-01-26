using System.Collections;
namespace ConsoleApp1
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What atom here?");
            //string s = Console.ReadLine();
            string s = "H2Cl(Ne2H3)2";
            //Console.WriteLine($"Atom: atomic number{atoms[s].number} atomic weight{atoms[s].weight} {atoms[s].valence.Length} valence numbers");
            Tokenizer tokenizer = new(PeriodicTable.elements);

            List<Token> inputTokens = tokenizer.Tokenize(s);

            PrintTokens(inputTokens);
        }
        static void PrintTokens(List<Token> tokens)
        {
            foreach (var token in tokens)
                Console.WriteLine(PeriodicTable.GetSymbol(token.Atom.number) + token.Text + " " + token.Count);
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
        // Por ahora, esta clase no sirve para NADA, supongo que se puede quitar
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
