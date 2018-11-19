/*
 *  Assignment 2 - Huffman Codes
 *
 *  Written By: Nelson Su (0616242) and Conrad Schoenhofer (0625149) - November 2018
 *
 *  Huffman code implementation
 *  
 */
using System;

namespace Assignment2
{
    public static class Driver
    {
        public static void Main()
        {
            string s1 = "PiP pIn", s2 = "qwerty", s3 = "QWERTY", s4 = " Hello ";

            Huffman a = new Huffman(s1);
            Console.WriteLine("String: " + s1);
            Console.WriteLine("Encode: " + a.Encode(s1));
            Console.WriteLine("Decode: " + a.Decode(a.Encode(s1)));
            Console.WriteLine();

            Huffman b = new Huffman(s2);
            Console.WriteLine("String: " + s2);
            Console.WriteLine("Encode: " + b.Encode(s2));
            Console.WriteLine("Decode: " + b.Decode(b.Encode(s2)));
            Console.WriteLine();

            Huffman c = new Huffman(s3);
            Console.WriteLine("String: " + s3);
            Console.WriteLine("Encode: " + c.Encode(s3));
            Console.WriteLine("Decode: " + c.Decode(c.Encode(s3)));
            Console.WriteLine();

            Huffman d = new Huffman(s4);
            Console.WriteLine("String: " + s4);
            Console.WriteLine("Encode: " + d.Encode(s4));
            Console.WriteLine("Decode: " + d.Decode(d.Encode(s4)));

            Console.ReadKey();

        }
    }
}