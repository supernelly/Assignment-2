/*
 *  Assignment 2 - Huffman Codes
 *
 *  Written By: Nelson Su (0616242) - November 2018
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
            Console.WriteLine(a.Encode("aaabbbbccd"));
            Console.WriteLine(a.Decode("0001 0001 0001 000 000 000 000 001 001 01"));
            Console.ReadKey();

        }
    }
}