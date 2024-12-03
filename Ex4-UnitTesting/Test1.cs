namespace Ex4_UnitTesting
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        [DataRow(2, 2, 4)]
        [DataRow(17.396, 4.982, 86.666872)]
        public void CalculateRectangleAreaTrue(double width, double height, double exp)
        {
            // Arrange & Act
            double result = Ex4.Program.CalculateRectangleArea(width, height);

            // Assert
            Assert.AreEqual(exp, result);
        }
        [TestMethod]
        [DataRow(3, 3, 9)]
        [DataRow(8.5, 17.4, 147.9)]
        public void CalculateRectangleAreaFalse(double width, double height, double exp)
        {
            // Arrange & Act
            double result = Ex4.Program.CalculateRectangleArea(width, height);

            // Assert
            Assert.AreNotEqual(exp, result);
        }
        [TestMethod]
        [DataRow(23)]
        [DataRow(43.91)]
        public void CalculateCircleCircumferenceTrue(double radius)
        {
            // Arrange & Act
            double result = Ex4.Program.CalculateCircleCircumference(radius);
            double exp = 2 * Math.PI * radius;

            // Assert
            Assert.AreEqual(exp, result);
        }
        [TestMethod]
        [DataRow(9)]
        [DataRow(1.254)]
        public void CalculateCircleCircumferenceFalse(double radius)
        {
            // Arrange & Act
            double result = Ex4.Program.CalculateCircleCircumference(radius);
            double exp = 2 * Math.PI * radius;

            // Assert
            Assert.AreNotEqual(exp, result);
        }

    }
}
