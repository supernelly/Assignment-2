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
        private Dictionary<char, string> D = new Dictionary<char, string>(); // Dictionary to encode text

        // Constructor
        public Huffman(string S)
        {
            // Test code
            
            int[] charFreq = AnalyzeText(S);

            
            //for (int i = 0; i < charFreq.Length; i++)
            //{
                //Console.WriteLine(charFreq[i]);
            //}
            

            Build(charFreq);
            CreateCodes(HT, "");

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

            int[] charFreq = new int[123];
            for (int i = 0; i < S.Length; i++)
            {
                int charNum = S[i];

                if (charNum >= 65 && charNum <= 90 || charNum >= 97 && charNum <= 122 || charNum == 32)
                    charFreq[charNum]++;
            }
            return charFreq;
        }
        
        // 20 marks
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
                Node replaced = new Node('.', temp.Frequency + PQ.Front().Frequency, temp, PQ.Front()); // creates parent node
                PQ.Remove();
                PQ.Add(replaced);

                Console.WriteLine(replaced.Frequency); // prints parent node's frequency

                if (PQ.Size() == 1)
                    HT = replaced;
            }

            Console.WriteLine("Hello pippin"); // if it makes it to end...
        }

        // Create the code of 0s and 1s for each character by traversing the Huffman tree (invoked by Huffman)
        private void CreateCodes(Node current, string number)
        {
            if (current.Left != null)
            {
                CreateCodes(current.Left, number += "0");
                CreateCodes(current.Right, number += "1");
            }
            else
            {
                D.Add(current.Character, number); // Add number once child if null
                Console.WriteLine(current.Character);
                return;
            }
        }

        // Encode the given text and return a string of 0s and 1s
        public string Encode(string S)
        {
            string encode = "";
            foreach (char c in S)
            {
                try // removed once perfected
                {
                    encode += (D[c] + " ");
                }
                catch
                {
                    encode += "nokey ";
                }
            }
            return encode;
        }

        // Decode the given string of 0s and 1s and return the original text
       public string Decode(string S)
        {
            string codeCurr = "", decode = "";
            foreach (char c in S)
            {
                if (c == ' ') // space indicates when character's code is finished
                {
                    Traverse(HT, codeCurr);

                    Console.WriteLine(codeCurr);
                    codeCurr = "";
                }
                else
                    codeCurr += Convert.ToString(c);
            }

            void Traverse(Node current, string number)
            {
                if (current.Left == null || number == "")
                    decode += Convert.ToString(current.Character);
                else if (number.Substring(0) == "0")
                    Traverse(current.Left, number.Substring(1, number.Length - 1));
                else
                    Traverse(current.Right, number.Substring(1, number.Length - 1));
                Console.WriteLine(current.Character); // test
            }
            return decode;
        } 
    }
    // Source documentation (comments)
    // 10 marks

    // Testing
    // 10 marks
}




