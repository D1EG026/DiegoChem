namespace ConsoleApp1
{
    public struct Token(AtomData atom, int count = 1)
    {
        public AtomData Atom = atom;
        public int Count = count;
        //public static implicit operator AtomData(Token token) => token.Atom;
    }
}



