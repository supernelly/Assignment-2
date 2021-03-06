﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Node : IComparable
    {
        public char Character { get; set; }
        public int Frequency { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node(char character, int frequency, Node left, Node right)
        {
            Character = character;
            Frequency = frequency;
            Left = left;
            Right = right;
        }

        public int CompareTo(Object obj)
        {
            Node n = obj as Node;
            if (n == null)
                return 1;
            else if (Frequency > n.Frequency)
                return -1;
            else if (Frequency == n.Frequency)
                return 0;
            else
                return 1;
        }
    }

    class Huffman
    {
        private Node HT; // Huffman tree to create codes and decode text
        private Dictionary<char, string> D; // Dictionary to encode text

        // Constructor
        public Huffman(string S)
        {
            int[] charFreq = AnalyzeText(S);

            D = new Dictionary<char, string>();
            Build(charFreq);
            if (HT.Left == null)
                D.Add(HT.Character, "0");
            else
                CreateCodes(HT, "");

        }

        // Return the frequency of each character in the given text (invoked by Huffman)
        private int[] AnalyzeText(string S)
        {
            int[] charFreq = new int[123];
            for (int i = 0; i < S.Length; i++)
            {
                int charNum = S[i];

                if (charNum >= 65 && charNum <= 90 || charNum >= 97 && charNum <= 122 || charNum == 32)
                    charFreq[charNum]++; // Add frequency if it comes across a letter or space
            }
            return charFreq;
        }

        // Build a Huffman tree based on the character frequencies greater than 0 (invoked by Huffman)
        private void Build(int[] F)
        {
            int position = 0, charNum = 0;

            foreach (int f in F)
            {
                if (f > 0) // Number of frequencies that are not 0
                    charNum++;
            }

            PriorityQueue<Node> PQ = new PriorityQueue<Node>(charNum);
            foreach (int f in F) // Adds frequency of position number to PQ
            {
                if (f > 0)
                    PQ.Add(new Node((char)position, f, null, null));
                position++;
            }

            while (PQ.Size() > 1) // Creates binary heap when PQ.Size is 1
            {
                Node temp = PQ.Front(); // Holds front
                PQ.Remove();
                Node replaced = new Node('.', temp.Frequency + PQ.Front().Frequency, temp, PQ.Front()); // Creates parent node
                PQ.Remove();
                PQ.Add(replaced);

                if (PQ.Size() == 1)
                    HT = replaced;
            }
            PQ.MakeEmpty();
        }

        // Create the code of 0s and 1s for each character by traversing the Huffman tree (invoked by Huffman)
        private void CreateCodes(Node current, string number)
        {
            string left = number, right = number;
            if (current.Left != null)
            {
                CreateCodes(current.Left, left += "0");
                CreateCodes(current.Right, right += "1");
            }
            else
            {
                D.Add(current.Character, number); // Add number once child if null
                return;
            }
        }

        // Encode the given text and return a string of 0s and 1s
        public string Encode(string S)
        {
            string encode = "";
            foreach (char c in S)
            {
                encode += (D[c] + " ");
            }
            return encode;
        }

        // Decode the given string of 0s and 1s and return the original text
        public string Decode(string S)
        {
            string codeCurr = "", decode = "";
            if (HT == null)
                return "";
            else if (HT.Left == null)
                decode += Convert.ToString(HT.Character);
            else
                foreach (char c in S)
                {
                    if (c == ' ') // space indicates when character's code is finished
                    {
                        Traverse(HT, codeCurr);

                        codeCurr = "";
                    }
                    else
                        codeCurr += Convert.ToString(c);
                }

            void Traverse(Node current, string number) // Recursive function to traverse huffman tree
            {
                if (number == "")
                    decode += Convert.ToString(current.Character);
                else if (number.Substring(0, 1) == "0")
                    Traverse(current.Left, number.Substring(1, number.Length - 1));
                else
                    Traverse(current.Right, number.Substring(1, number.Length - 1));
            }
            return decode;
        }
    }
}




