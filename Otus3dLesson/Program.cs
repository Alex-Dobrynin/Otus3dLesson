using DotNetMath = System.Math;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


public static class Math
{
    public static double[] SolveQuadratic(double a, double b, double c, double eps = 1E-5)
    {
        if (double.IsPositiveInfinity(a)
            || double.IsPositiveInfinity(b)
            || double.IsPositiveInfinity(c)) throw new ArgumentException("Parameters cannot be equal to positive infinity");

        if (double.IsNegativeInfinity(a)
           || double.IsNegativeInfinity(b)
           || double.IsNegativeInfinity(c)) throw new ArgumentException("Parameters cannot be equal to negative infinity");

        if (double.IsNaN(a)
           || double.IsNaN(b)
           || double.IsNaN(c)) throw new ArgumentException("Parameters cannot be not a numbers");

        if (DotNetMath.Abs(a) < eps) throw new ArgumentException("Parameter 'a' cannot be equal 0");
        // Абсолютно не понятно почему нельзя сделать так, если инструменты языка позволяют это сделать?
        //if (a is 0d) throw new ArgumentException("Parameter 'a' cannot be equal 0");

        var D = b * b - 4 * a * c;

        if (double.IsInfinity(D) || double.IsNaN(D)) throw new ArgumentException("Parameters are too small or too big");

        if (DotNetMath.Abs(D) < eps)
        {
            return new double[] { -b / (2 * a), -b / (2 * a) };
        }
        // Тот же вопрос
        //if (D is 0d)
        //{
        //    return new double[] { -b / (2 * a), -b / (2 * a) };
        //}

        if (D < 0d)
        {
            return new double[0];
        }

        if (D > 0d)
        {
            return new double[] { (-b + DotNetMath.Sqrt(D)) / (2 * a), (-b - DotNetMath.Sqrt(D)) / (2 * a) };
        }

        return new double[0];
    }
}