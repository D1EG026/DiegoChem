

namespace ConsoleApp1
{
    public readonly struct AtomData(int number, float weight, int[] valence)
    {
        public readonly int number = number;
        public readonly float weight = weight;
        public readonly int[] valence = valence;

        public static implicit operator Token(AtomData atom) => new(atom);
    }
}
