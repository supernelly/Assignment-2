/*
 *  Assignment 2 - Huffman Codes
 *
 *  Written By: Nelson Su (0616242) and Conrad Schoenhofer (0625149) - November 2018
 *
 *  Description here
 *  
 */
using System;

namespace Assignment2
{
    public static class Driver
    {
        public static void Main()
        {
            // Test code here
            //Huffman S = new Huffman(" ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz");
            Huffman a = new Huffman("aaabbbbccd");
            //Huffman b = new Huffman("Pipppiin");
            //Huffman c = new Huffman("Pippppiin");
            //Huffman d = new Huffman("Pipppppiin");
            Console.WriteLine(a.Encode("aaabbbbccddd"));
            Console.WriteLine(a.Decode("10 10 10 0 0 0 0 111 111 110 110 110 "));
            Console.ReadKey();

        }
    }
}