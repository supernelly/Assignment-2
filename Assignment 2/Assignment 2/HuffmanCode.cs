using System;
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
        // 5 marks
        public int CompareTo(Object obj)
        {
            Node n = obj as Node;
            if (n == null)
                return 1;
            else if (Frequency < n.Frequency)
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
            // Test code
            int[] charFreq = AnalyzeText(S);
            for (int i = 0; i < charFreq.Length; i++)
            {
                Console.WriteLine(charFreq[i]);
            }


        }

        // 15 marks
        // Return the frequency of each character in the given text (invoked by Huffman)
        private int[] AnalyzeText(string S)
        {
            // (int)'A' = 65
            // (int)'Z' = 90
            // (int)'a' = 97
            // (int)'z' = 122
            // (int)' ' = 32

            // charFreq[0] = ' ', charFreq[1-26] = 'A'->'Z', charFreq[27-53] = 'a'->'z'

            int[] charFreq = new int[53];
            for (int i = 0; i < S.Length; i++)
            {
                int charNum = S[i];

                if (charNum >= 65 && charNum <= 90)
                    charNum = charNum - 64;
                else if (charNum >= 97 && charNum <= 122)
                    charNum = charNum - 70;
                else
                    charNum = 0;
         
                charFreq[charNum]++;
            }
            return charFreq;
        }
        
        // 20 marks
        // Build a Huffman tree based on the character frequencies greater than 0 (invoked by Huffman)
        private void Build(int[] F)
        {
            //PriorityQueue<Node> PQ;
            Node p = new Node(null, 0, null, null);
            int MsgTotal;
            int t = 0;
            string[] alphabet = { " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};
            
        
            for (int i = 0; i < F.Length; i++)
            {
                if(F[i] > 0)
                    MsgTotal++;
            }
            positions[MsgTotal];
            for (int i = 0; i < F.Length; i++)
            {
                if(F[i] > 0)
                    positions.add(i);
            }
            Node[] BH;
            BH[MsgTotal * 2];
            BH[0] = null;
            for (int i = BH.Length; i > 0; i--)
            {
                BH[i] = Node(alphabet[positions[t]], F[positions[t]], null, null);
                t++;
            }
        }

        // Create the code of 0s and 1s for each character by traversing the Huffman tree (invoked by Huffman)
        private void CreateCodes()
        {
        
        }

        // Encode the given text and return a string of 0s and 1s
        //public string Encode(string S)
        //{
           
        //}

        //// Decode the ggiven string of 0s and 1s and return the original text
        //public string Decode(string S)
        //{
        
        
        //} 
    }
    // Source documentation (comments)
    // 10 marks

    // Testing
    // 10 marks
}
