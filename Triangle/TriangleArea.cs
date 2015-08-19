using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    /// <summary>
    /// Class 'TriangleArea'
    /// </summary>
    public class TriangleArea
    {
        // Messages to be used in unit test
        public const string InputsIsEmptyMessage = ": Any inputs that are empty.";
        public const string InputIsLessThanZeroMessage = ": Any inputs that are negative.";
        public const string InputsAreNotValidMessage = ": Sum of any 2 sides is not greater than the other one.";
                
        /// <summary>
        /// Caculate triangle area by Heron's formula
        ///    1. check if the inputs are available 
        ///    2. calculate by Heron's formula
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public double Area(int a, int b, int c)
        {
            // Validate input integers
            CheckForInvalidTriangle(a,b,c);

            // create local variables to accept integer arguments
            int x, y, z;

            // p, s will be used in formula
            double p, s;

            // assign value to local variables
            x = a;
            y = b;
            z = c;

            // here's Heron's formula 
            p = (x + y + z) / 2;
            s = Math.Sqrt(p * (p - x) * (p - y) * (p - z));

            // finally return the area
            return s;
        }
                
        /// <summary>
        /// check input integers, or throw exceptions
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public void CheckForInvalidTriangle(int a, int b, int c)
        {
            // negative validation
            if (a < 0 || b < 0 || c < 0)
                throw new InvalidTriangleException(": Any inputs that are negative.");

            // 2 sides less than 1 side validation 
            if ((a + b <= c) || (a + c <= b) || (c + b <= a))
                throw new InvalidTriangleException(": Sum of any 2 sides is not greater than the other one.");
        }

        /// <summary>
        /// Call method via Main()
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args){
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
        
    /// <summary>
    /// create InvalidTriangleException class for tests
    /// </summary>
    public class InvalidTriangleException : Exception
    {
        public InvalidTriangleException() : base("Inputs that cannot form a valid triangle") { }
        public InvalidTriangleException(string msg) : base("Inputs that cannot form a valid triangle" + msg) { }
    }
}
