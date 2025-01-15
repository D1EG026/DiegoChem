namespace ConsoleApp1
{
    public record AtomData
    {
        public int number;
        public float weight;
        public int[] valence;

        public AtomData(int number, float weight, int[] valence)
        {
            this.number = number;
            this.weight = weight;
            this.valence = valence;
        }
    }
}
