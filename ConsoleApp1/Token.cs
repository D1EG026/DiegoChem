namespace ConsoleApp1
{
    public struct Token
    {
        public AtomData Atom;
        public string Text;
        public int Count;

        public Token(AtomData atom = default, string text = null, int count = 1)
        {
            Atom = atom;
            Text = text;
            Count = count;
        }
        //public static implicit operator AtomData(Token token) => token.Atom;
    }
    // public struct ParenthesisToken(int number)
    // {
    //     public int Number = number;
    // }
    // public struct AtomToken
    // {
    //      public AtomData Atom;
    //     public int Count;

    //     public AtomToken(AtomData atom, int count = 1)
    //     {
    //         Atom = atom;
    //         Count = count;
    //     }
    // }
}



