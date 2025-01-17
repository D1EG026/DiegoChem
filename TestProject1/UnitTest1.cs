using ConsoleApp1;
namespace TestProject1
{
    public class MatrixOperationTest
    {
        [Fact]
        public void TestDeterminant()
        {
            // Arrange
            Matrix matrix = new Matrix(3, 3);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[0, 2] = 3;
            matrix[1, 0] = 0;
            matrix[1, 1] = 1;
            matrix[1, 2] = 4;
            matrix[2, 0] = 5;
            matrix[2, 1] = 6;
            matrix[2, 2] = 0;

            // Act
            float det = matrix.Determinant();

            // Assert
            Assert.Equal(1, det);
        }

        [Fact]
        public void TestMinor()
        {
            // Arrange
            Matrix matrix = new Matrix(3, 3);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[0, 2] = 3;
            matrix[1, 0] = 0;
            matrix[1, 1] = 1;
            matrix[1, 2] = 4;
            matrix[2, 0] = 5;
            matrix[2, 1] = 6;
            matrix[2, 2] = 0;

            // Act
            Matrix minor00 = matrix.Minor(0, 0);
            Matrix minor01 = matrix.Minor(0, 1);
            Matrix minor02 = matrix.Minor(0, 2);

            // Assert
            Assert.Equal(-24, minor00.Determinant());
            Assert.Equal(-20, minor01.Determinant());
            Assert.Equal(-5, minor02.Determinant());
        }
        [Fact]
        public void TestInverse()
        {
            // Arrange
            Matrix matrix = new Matrix(3, 3);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[0, 2] = 3;
            matrix[1, 0] = 0;
            matrix[1, 1] = 1;
            matrix[1, 2] = 4;
            matrix[2, 0] = 5;
            matrix[2, 1] = 6;
            matrix[2, 2] = 0;

            // Act
            Matrix inverse = matrix.Inverse();

            // Assert
            Assert.Equal(-24, inverse[0, 0]);
            Assert.Equal(18, inverse[0, 1]);
            Assert.Equal(5, inverse[0, 2]);
            Assert.Equal(20, inverse[1, 0]);
            Assert.Equal(-15, inverse[1, 1]);
            Assert.Equal(-4, inverse[1, 2]);
            Assert.Equal(-5, inverse[2, 0]);
            Assert.Equal(4, inverse[2, 1]);
            Assert.Equal(1, inverse[2, 2]);

        }
    }
}
