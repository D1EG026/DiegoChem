namespace ConsoleApp1
{
    public struct Token(AtomData atom = default, string text = null, int count = 1)
    {
        public AtomData Atom = atom;
        public string Text = text;
        public int Count = count;
        //public static implicit operator AtomData(Token token) => token.Atom;
    }
}



