using System;

namespace Udemy_Unit8__tasks
{
    class Complex
    {
        public Complex(double materialPart, double imaginaryPart)
        {
            MaterialPart = materialPart;
            ImaginaryPart = imaginaryPart;
        }
        public double MaterialPart {get; set;}
        public double ImaginaryPart {get; set;}

        public void PrintInfo(){Console.WriteLine("MaterialPart = " + MaterialPart + ", ImaginaryPart = " + ImaginaryPart);}

        public Complex Plus(Complex c2)
        {
            return new Complex(MaterialPart+c2.MaterialPart, ImaginaryPart+c2.ImaginaryPart);
        }

        public Complex Minus(Complex c2)
        {
            return new Complex(MaterialPart-c2.MaterialPart, ImaginaryPart-c2.ImaginaryPart);
        }
    }
}