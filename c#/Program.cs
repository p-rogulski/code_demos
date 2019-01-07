using System;
using System.Collections.Generic;

namespace ch3
{
    //Operators overloading 

    class SubComplex
    {
        private Complex c;

        public SubComplex(Complex o)
        {
            this.c = o;
        }

        public Complex C
        {
            get
            {
                return c;
            }
        }
    }

    internal class Complex : IEquatable<Complex>
    {
        public string ID = "Complex";
        public bool[] _complexes = { true, false, true };
        public double Real { get; set; }
        public double Imaginary { get; set; }
        public string Name { get; set; }


        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex
            {
                Real = c1.Real + c2.Real,
                Imaginary = c1.Imaginary + c2.Imaginary
            };
        }

        public static Complex operator -(Complex c1, Complex c2)
        {
            return new Complex
            {
                Real = c1.Real - c2.Real,
                Imaginary = c1.Imaginary - c2.Imaginary
            };
        }

        public static Complex operator *(Complex c1, Complex c2)
        {
            return new Complex
            {
                Real = c1.Real * c2.Real,
                Imaginary = c1.Imaginary * c2.Imaginary
            };
        }

        public static Complex operator /(Complex c1, Complex c2)
        {
            return new Complex
            {
                Real = c1.Real / c2.Real,
                Imaginary = c1.Imaginary / c2.Imaginary
            };
        }

        public static bool operator ==(Complex c1, Complex c2)
        {
            return c1.Real == c2.Real && c1.Imaginary == c2.Imaginary;
        }

        public static bool operator !=(Complex c1, Complex c2)
        {
            return c1.Real != c2.Real && c1.Imaginary != c2.Imaginary;
        }

        public static explicit operator bool[] (Complex c)
        {
            return c._complexes;
        }


        public static implicit operator SubComplex(Complex c)
        {
            return new SubComplex(c);
        }


        public bool Equals(Complex other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(other, this)) return true;
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as Complex);
        }

        public override int GetHashCode()
        {
            var hashCode = -1829679665;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ID);
            hashCode = hashCode * -1521134295 + EqualityComparer<bool[]>.Default.GetHashCode(_complexes);
            hashCode = hashCode * -1521134295 + Real.GetHashCode();
            hashCode = hashCode * -1521134295 + Imaginary.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Complex c1 = new Complex { Real = 2.34, Imaginary = 3.45 };
            Complex c2 = new Complex { Real = 5.67, Imaginary = 3.58 };
            Complex result_plus = c1 + c2;
            Complex result_minus = c1 - c2;
            Complex result_multi = c1 * c2;
            Complex result_div = c1 / c2;
            var c = new Complex();
            bool[] explict = (bool[])c;
            SubComplex implict = c;

            Console.WriteLine("Operators Overloading:\n+ Re:{0} Im:{1}", Math.Round(result_plus.Real, 2), Math.Round(result_plus.Imaginary, 2));
            Console.WriteLine("- Re:{0} Im:{1}", Math.Round(result_minus.Real, 2), Math.Round(result_minus.Imaginary, 2));
            Console.WriteLine("* Re:{0} Im:{1}", Math.Round(result_multi.Real, 2), Math.Round(result_multi.Imaginary, 2));
            Console.WriteLine("/ Re:{0} Im:{1}", Math.Round(result_div.Real, 2), Math.Round(result_div.Imaginary, 2));
            Console.WriteLine("== Result:{0}", c1 == c2);
            Console.WriteLine("!= Result:{0}", c1 != c2);
            Console.WriteLine("Equals Result:{0}", Complex.Equals(c1, c2));
            Console.WriteLine("Explict:{0}", explict[0]);
            Console.WriteLine("Implict:{0}", implict.C.ID);
            Console.ReadKey();
        }
    }

}
