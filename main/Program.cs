using System;
using System.Linq;
using System.Numerics;

namespace main
{
    class BinaryInteger 
    {     
        char[] value { get; }

        public BinaryInteger(char[] val) =>
            value = val;

        public BinaryInteger(string val)  =>      
            value = val.ToCharArray();

        public BinaryInteger(BigInteger val) =>
            value = ToBinaryInt(val);

        public static BinaryInteger operator +(BinaryInteger a, BinaryInteger b) =>
            new(a.ToDecimalInt() + b.ToDecimalInt());

        private char[] ToBinaryInt(BigInteger val)
        {
            int bitCount = val == 0 ? 1 : (int)Math.Floor(BigInteger.Log(val, 2)) + 1;
            char[] result = new char[bitCount];
            for (int i = 0; val > 0; i++)
            {
                result[^(i+1)] = (char)(val % 2 + '0');
                val /= 2;
            }
            return result;
        }

        public BigInteger ToDecimalInt()
        {
            BigInteger result = 0;
            for (int i = 0; i < value.Length; i++)
                result += (value[^(i + 1)] - '0') * BigInteger.Pow(2, i);

            return result;
        }

        public static BinaryInteger InputValidBinaryInteger()
        {
            Console.WriteLine("Введіть число в бінарному вигляді без пробілів:");
            var input = Console.ReadLine() ?? "";
            bool isBinary = input.All(c => c == '0' || c == '1');
            if (!isBinary)
            {
                Console.WriteLine("Введене число не є бінарним.");
                return InputValidBinaryInteger();
            }
            var result = new BinaryInteger(input);
            Console.WriteLine($"Ви ввели число: {result.ToDecimalInt()}\n");
            return result;
        }

        public override string ToString() =>
            $"{ToDecimalInt()}  (decimal)\n{new(value)}  (binary)";
    }

    internal class Program
    {        
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            var a = BinaryInteger.InputValidBinaryInteger();
            var b = BinaryInteger.InputValidBinaryInteger();
            Console.WriteLine($"Сума чисел:\n{a + b}");
        }
    }
}