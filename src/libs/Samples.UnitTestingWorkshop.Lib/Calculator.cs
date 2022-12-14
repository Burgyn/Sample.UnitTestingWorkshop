﻿namespace Samples.UnitTestingWorkshop.Lib;

public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }
    
    public int Subtract(int a, int b)
    {
        return a - b;
    }
    
    public int Multiply(int a, int b)
    {
        return a * b;
    }
    
    public (int Result, int Remainder) Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException();
        }
        return (a / b, a % b);
    }
}
