using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    public class TriangleArea
    {
        // Messages to be used in tests
        public const string InputsIsEmptyMessage = ": Any inputs that are empty.";
        public const string InputIsLessThanZeroMessage = ": Any inputs that are negative.";
        public const string InputsAreNotValidMessage = ": Sum of any 2 sides is not greater than the other one.";

        // Caculate triangle area by Heron's formula
        public double Area(int a, int b, int c)
        {
            // Validate input integers
            CheckForInvalidTriangle(a,b,c);

            int x, y, z;
            double p, s;

            x = a;
            y = b;
            z = c;

            p = (x + y + z) / 2;
            s = Math.Sqrt(p * (p - x) * (p - y) * (p - z));
            return s;
        }

        // check input integers, or throw exceptions
        public void CheckForInvalidTriangle(int a, int b, int c)
        {
            // negative validation
            if (a < 0 || b < 0 || c < 0)
                throw new InvalidTriangleException(": Any inputs that are negative.");

            // 2 sides less than 1 side validation 
            if ((a + b <= c) || (a + c <= b) || (c + b <= a))
                throw new InvalidTriangleException(": Sum of any 2 sides is not greater than the other one.");
        }

        static void Main(string[] args)
        {
            try
            {
                // get user inputs, turn into integers
                Console.WriteLine("Please enter three (side) lengthes of a triangle:");
                Console.WriteLine("Length of side 1: ");
                string s1 = Console.ReadLine();
                Console.WriteLine("Length of side 2: ");
                string s2 = Console.ReadLine();
                Console.WriteLine("Length of side 3: ");
                string s3 = Console.ReadLine();

                // Check if the inputs are empty strings
                if (s1.Length == 0 || s2.Length == 0 || s3.Length == 0)
                throw new InvalidTriangleException(": Any inputs that are empty."); 

                // if okay, convert into integers
                int side1 = Convert.ToInt32(s1);
                int side2 = Convert.ToInt32(s2);
                int side3 = Convert.ToInt32(s3);

                // create Triangle instance 
                TriangleArea tri = new TriangleArea();

                // call Heron's formula and print result
                double s = tri.Area(side1, side2, side3);

                Console.WriteLine("\nTriangle area is: {0}", s);
                Console.ReadLine();
            }
            catch (InvalidTriangleException ex)
            {
                // print out exception message
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }

    // create InvalidTriangleException class for tests
    public class InvalidTriangleException : Exception
    {
        public InvalidTriangleException() : base("Inputs that cannot form a valid triangle") { }
        public InvalidTriangleException(string msg) : base("Inputs that cannot form a valid triangle" + msg) { }
    }
}
