using System;

using FluentAssertions;

using Xunit;


namespace Otus3dLesson.Tests
{
    public class MathTest
    {
        [Fact]
        public void Test_No_Roots()
        {
            var result = Math.SolveQuadratic(1, 0, 1);
            result.Should().BeEmpty();
        }

        [Fact]
        public void Test_Two_Roots_Multiplicity_1()
        {
            var result = Math.SolveQuadratic(1, 0, -1);
            result.Should().HaveCount(2).And.BeEquivalentTo(new double[] { 1, -1 });
        }

        [Fact]
        public void Test_One_Root_Multiplicity_2()
        {
            var result = Math.SolveQuadratic(0.999, 2, 1.001);
            result.Should().HaveCount(2).And.BeEquivalentTo(new double[] { -1.0010010010010011, -1.0010010010010011 });
        }

        [Fact]
        public void Test_Parameter_a_Cannot_Be_0()
        {
            var result = () => Math.SolveQuadratic(1E-7, 2, 1);
            result.Should().Throw<ArgumentException>().WithMessage("Parameter 'a' cannot be equal 0");
        }

        [Theory]
        [InlineData(double.PositiveInfinity, 1, 1)]
        [InlineData(1, double.PositiveInfinity, 1)]
        [InlineData(1, 1, double.PositiveInfinity)]
        [InlineData(double.PositiveInfinity, double.PositiveInfinity, 1)]
        [InlineData(1, double.PositiveInfinity, double.PositiveInfinity)]
        [InlineData(double.PositiveInfinity, 1, double.PositiveInfinity)]
        [InlineData(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity)]
        public void Test_Positive_Infinity(double a, double b, double c)
        {
            var result = () => Math.SolveQuadratic(a, b, c);
            result.Should().Throw<ArgumentException>().WithMessage("Parameters cannot be equal to positive infinity");
        }

        [Theory]
        [InlineData(double.NegativeInfinity, 1, 1)]
        [InlineData(1, double.NegativeInfinity, 1)]
        [InlineData(1, 1, double.NegativeInfinity)]
        [InlineData(double.NegativeInfinity, double.NegativeInfinity, 1)]
        [InlineData(1, double.NegativeInfinity, double.NegativeInfinity)]
        [InlineData(double.NegativeInfinity, 1, double.NegativeInfinity)]
        [InlineData(double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity)]
        public void Test_Negative_Infinity(double a, double b, double c)
        {
            var result = () => Math.SolveQuadratic(a, b, c);
            result.Should().Throw<ArgumentException>().WithMessage("Parameters cannot be equal to negative infinity");
        }

        [Theory]
        [InlineData(double.NaN, 1, 1)]
        [InlineData(1, double.NaN, 1)]
        [InlineData(1, 1, double.NaN)]
        [InlineData(double.NaN, double.NaN, 1)]
        [InlineData(1, double.NaN, double.NaN)]
        [InlineData(double.NaN, 1, double.NaN)]
        [InlineData(double.NaN, double.NaN, double.NaN)]
        public void Test_Not_A_Number(double a, double b, double c)
        {
            var result = () => Math.SolveQuadratic(a, b, c);
            result.Should().Throw<ArgumentException>().WithMessage("Parameters cannot be not a numbers");
        }

        [Theory]
        [InlineData(double.MaxValue, 1, 1)]
        [InlineData(1, double.MaxValue, 1)]
        [InlineData(1, 1, double.MaxValue)]
        [InlineData(double.MaxValue, double.MaxValue, 1)]
        [InlineData(1, double.MaxValue, double.MaxValue)]
        [InlineData(double.MaxValue, 1, double.MaxValue)]
        [InlineData(double.MaxValue, double.MaxValue, double.MaxValue)]

        [InlineData(double.MinValue, 1, 1)]
        [InlineData(1, double.MinValue, 1)]
        [InlineData(1, 1, double.MinValue)]
        [InlineData(double.MinValue, double.MinValue, 1)]
        [InlineData(1, double.MinValue, double.MinValue)]
        [InlineData(double.MinValue, 1, double.MinValue)]
        [InlineData(double.MinValue, double.MinValue, double.MinValue)]

        [InlineData(double.MinValue, 1, double.MaxValue)]
        [InlineData(1, double.MinValue, double.MaxValue)]
        [InlineData(1, double.MaxValue, double.MinValue)]
        [InlineData(double.MaxValue, 1, double.MinValue)]
        public void Test_Parameters_Min_Max_Value(double a, double b, double c)
        {
            var result = () => Math.SolveQuadratic(a, b, c);
            result.Should().Throw<ArgumentException>().WithMessage("Parameters are too small or too big");
        }
    }
}