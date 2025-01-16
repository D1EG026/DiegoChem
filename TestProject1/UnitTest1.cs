using ConsoleApp1;
namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Console.WriteLine("hello");
            Matrix matrix = new(3, 3);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[0, 2] = 3;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;
            matrix[1, 2] = 5;
            matrix[2, 0] = -2;
            matrix[2, 1] = 0;
            matrix[2, 2] = -1;
            Matrix inverse = matrix.Inverse();

            Matrix expectedInverse = new Matrix(3, 3);
            expectedInverse[0, 0] = 1.0f / 3.0f;
            expectedInverse[0, 1] = 4.0f / 3.0f;
            expectedInverse[0, 2] = -2.0f / 3.0f;
            expectedInverse[1, 0] = 1.0f / 3.0f;
            expectedInverse[1, 1] = 5.0f / 6.0f;
            expectedInverse[1, 2] = -2.0f / 3.0f;
            expectedInverse[2, 0] = -1.0f / 3.0f;
            expectedInverse[2, 1] = 2.0f / 3.0f;
            expectedInverse[2, 2] = -1.0f / 3.0f;

            Console.WriteLine(matrix);
            Assert.Equal(expectedInverse, inverse); //Falla

        }
    }
}
