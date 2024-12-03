using ExerciseFive;

namespace Ex5_UnitTesting
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(17)]
        [InlineData(48)]
        [InlineData(136)]
        public void ClassifyAgeTrue(int age)
        {
            // Arrange & Act
            int exp = -1;
            PersonaHelper classifyAge = new PersonaHelper();
            int result = classifyAge.ClassifyAge(age);

            // Assert
            Assert.NotEqual(exp, result);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(12)]
        [InlineData(17)]
        public void ClassifyAgeChildTrue(int age)
        {
            // Arrange & Act
            int exp = 0;
            PersonaHelper classifyAge = new PersonaHelper();
            int result = classifyAge.ClassifyAge(age);

            // Assert
            Assert.Equal(exp, result);
        }
        [Theory]
        [InlineData(18)]
        [InlineData(44)]
        [InlineData(65)]
        public void ClassifyAgeAdultTrue(int age)
        {
            // Arrange & Act
            int exp = 1;
            PersonaHelper classifyAge = new PersonaHelper();
            int result = classifyAge.ClassifyAge(age);

            // Assert
            Assert.Equal(exp, result);
        }
        [Theory]
        [InlineData(66)]
        [InlineData(102)]
        [InlineData(120)]
        public void ClassifyAgeOldTrue(int age)
        {
            // Arrange & Act
            int exp = 2;
            PersonaHelper classifyAge = new PersonaHelper();
            int result = classifyAge.ClassifyAge(age);

            // Assert
            Assert.Equal(exp, result);
        }
        [Theory]
        [InlineData(12)]
        [InlineData(-10)]
        public void IsEvenTrue(int age)
        {
            // Arrange & Act
            PersonaHelper isEven = new PersonaHelper();
            bool flag = isEven.IsEven(age);

            // Assert
            Assert.True(flag);
        }
        [Theory]
        [InlineData(28)]
        [InlineData(-4)]
        public void IsEvenFalse(int age)
        {
            // Arrange & Act
            PersonaHelper isEven = new PersonaHelper();
            bool flag = isEven.IsEven(age);

            // Assert
            Assert.True(flag);
        }

    }
}