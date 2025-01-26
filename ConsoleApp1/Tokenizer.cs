namespace ConsoleApp1
{
    public class Tokenizer(Dictionary<string, AtomData> atoms)
    {
        readonly Dictionary<string, AtomData> atoms = atoms;

        public List<Token> Tokenize(string s)
        {
            List<Token> tokens = [];

            for (int i = 0; i < s.Length; i++)
            {
                Token token;

                if (s[i].ToString().IsUpperCase())  // Letra mayúscula
                {
                    token = GetAtomTokenFromIndex(s, atoms, ref i);
                    tokens.Add(token);
                }

                if (s[i].ToString() == "(")
                {
                    tokens.Add(new(text: "("));
                }
                else if (s[i].ToString() == ")")
                {
                    token = new(text: ")");
                    if (i < s.Length && s[i + 1].ToString().IsNumber()) // Si hay número después del paréntesis
                    {
                        token.Count = int.Parse(s[i + 1].ToString());
                    }
                    tokens.Add(token);
                }
            }
            return tokens;
        }
        /// <summary>
        /// Devuelve un token de la cadena de entrada a partir de una posición dada. i es la última posición del token.
        /// </summary>
        private static Token GetAtomTokenFromIndex(string s, Dictionary<string, AtomData> atoms, ref int i)
        {
            AtomData atomToAdd;
            Token token;
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
    }
}