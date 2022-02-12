using System;
namespace DataStructureImplementations.MyTrie
{
    public class Trie
    {
        public Node root;

        public Trie()
        {
            root = new Node('\0');
        }

        public void insert(String word)
        {
            Node curr = root;
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (curr.children[c - 'a'] == null)
                {
                    curr.children[c - 'a'] = new Node(c);
                }
                curr = curr.children[c - 'a'];
            }

            curr.isWord = true;
        }

        public Node getNode(string word)
        {
            Node curr = root;
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (curr.children[c - 'a'] == null)
                {
                    return null;
                }

                curr = curr.children[c - 'a'];
            }

            return curr;
        }

        public Boolean search(string word)
        {
            Node node = getNode(word);

            if (node != null && node.isWord == true)
            {
                return true;
            }

            return false;
        }

        public Boolean startsWith(string prefix)
        {
            if (getNode(prefix) != null)
            {
                return true;
            }

            return false;
        }

    }
}
