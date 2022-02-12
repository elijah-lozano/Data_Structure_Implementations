using System;
namespace DataStructureImplementations.MyTrie
{
    public class Node
    {
        public char letter;
        public Boolean isWord;
        public Node[] children;

        public Node(char letter)
        {
            this.letter = letter;
            isWord = false;
            children = new Node[26];
        }
    }
}
