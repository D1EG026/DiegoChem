namespace ConsoleApp1
{
    /// <summary>
    /// Clase que contiene los elementos de la tabla periódica.
    /// </summary>
    public static class PeriodicTable
    {
        public static string GetSymbol(int atomicNumber) => elements.FirstOrDefault(x => x.Value.number == atomicNumber).Key;
        public static readonly Dictionary<string, AtomData> elements = new()
            {
                { "H", new AtomData(1, 1.008f, [1]) },
                { "He", new AtomData(2, 4.0026f, [0]) },
                { "Li", new AtomData(3, 6.94f, [1]) },
                { "Be", new AtomData(4, 9.0122f, [2]) },
                { "B", new AtomData(5, 10.81f, [3]) },
                { "C", new AtomData(6, 12.011f, [4]) },
                { "N", new AtomData(7, 14.007f, [3, 5]) },
                { "O", new AtomData(8, 15.999f, [2, 6]) },
                { "F", new AtomData(9, 18.998f, [1]) },
                { "Ne", new AtomData(10, 20.180f, [0]) },
                { "Na", new AtomData(11, 22.990f, [1]) },
                { "Mg", new AtomData(12, 24.305f, [2]) },
                { "Al", new AtomData(13, 26.982f, [3]) },
                { "Si", new AtomData(14, 28.085f, [4]) },
                { "P", new AtomData(15, 30.974f, [3, 5]) },
                { "S", new AtomData(16, 32.06f, [2, 6]) },
                { "Cl", new AtomData(17, 35.45f, [1, 7]) },
                { "Ar", new AtomData(18, 39.948f, [0]) },
                { "K", new AtomData(19, 39.098f, [1]) },
                { "Ca", new AtomData(20, 40.078f, [2]) },
                { "Sc", new AtomData(21, 44.956f, [3]) },
                { "Ti", new AtomData(22, 47.867f, [4]) },
                { "V", new AtomData(23, 50.942f, [5]) },
                { "Cr", new AtomData(24, 51.996f, [6]) },
                { "Mn", new AtomData(25, 54.938f, [7]) },
                { "Fe", new AtomData(26, 55.845f, [2, 6]) },
                { "Co", new AtomData(27, 58.933f, [2, 3]) },
                { "Ni", new AtomData(28, 58.693f, [2]) },
                { "Cu", new AtomData(29, 63.546f, [1, 2]) },
                { "Zn", new AtomData(30, 65.38f, [2]) },
                { "Ga", new AtomData(31, 69.723f, [3]) },
                { "Ge", new AtomData(32, 72.63f, [4]) },
                { "As", new AtomData(33, 74.922f, [3, 5]) },
                { "Se", new AtomData(34, 78.971f, [2, 6]) },
                { "Br", new AtomData(35, 79.904f, [1, 7]) },
                { "Kr", new AtomData(36, 83.798f, [0]) },
                { "Rb", new AtomData(37, 85.468f, [1]) },
                { "Sr", new AtomData(38, 87.62f, [2]) }
            };
        public enum AtomNumber
        {
            H = 1,
            He = 2,
            Li = 3,
            Be = 4,
            B = 5,
            C = 6,
            N = 7,
            O = 8,
            F = 9,
            Ne = 10,
            Na = 11,
            Mg = 12,
            Al = 13,
            Si = 14,
            P = 15,
            S = 16,
            Cl = 17,
            Ar = 18,
            K = 19,
            Ca = 20,
            Sc = 21,
            Ti = 22,
            V = 23,
            Cr = 24,
            Mn = 25,
            Fe = 26,
            Co = 27,
            Ni = 28,
            Cu = 29,
            Zn = 30,
            Ga = 31,
            Ge = 32,
            As = 33,
            Se = 34,
            Br = 35,
            Kr = 36,
            Rb = 37,
            Sr = 38,
            Y = 39,
            Zr = 40,
            Nb = 41,
            Mo = 42,
            Tc = 43,
            Ru = 44,
            Rh = 45,
            Pd = 46,
            Ag = 47,
            Cd = 48,
            In = 49,
            Sn = 50,
            Sb = 51,
            Te = 52,
            I = 53,
            Xe = 54,
            Cs = 55,
            Ba = 56,
            La = 57,
            Ce = 58,
            Pr = 59,
            Nd = 60,
            Pm = 61,
            Sm = 62,
            Eu = 63,
            Gd = 64,
            Tb = 65,
            Dy = 66,
            Ho = 67,
            Er = 68,
            Tm = 69,
            Yb = 70,
            Lu = 71,
            Hf = 72,
            Ta = 73,
            W = 74,
            Re = 75,
            Os = 76,
            Ir = 77,
            Pt = 78,
            Au = 79,
            Hg = 80,
            Tl = 81
        }
    }
}
