using System;
namespace DataStructureImplementations.MyBinaryTree
{
    public class BinaryTree
    {
        public Node root;

        public BinaryTree()
        {
            root = new Node(5);
            root.left = new Node(3);
            root.right = new Node(8);
        }

        public void insert(Node root, int num)
        {
            if (num <= root.data)
            {
                if (root.left == null)
                {
                    root.left = new Node(num);
                }
                else
                {
                    insert(root.left, num);
                }
            }
            else
            {
                if (root.right == null)
                {
                    root.right = new Node(num);
                }
                else
                {
                    insert(root.right, num);
                }
            }
        }

        public bool contains(Node root, int num)
        {
            if (root.data == num)
            {
                return true;
            }
            else if (num <= root.data)
            {
                if (root.left == null)
                {
                    return false;
                }
                else
                {
                    return contains(root.left, num);
                }
            }
            else
            {
                if (root.right == null)
                {
                    return false;
                }
                else
                {
                    return contains(root.right, num);
                }
            }
        }

        public Node search(Node root, int num)
        {
            if (root.data == num)
            {
                return root;
            }
            else if (num <= root.data)
            {
                if (root.left == null)
                {
                    return null;
                }
                else
                {
                    return search(root.left, num);
                }
            }
            else
            {
                if (root.right == null)
                {
                    return null;
                }
                else
                {
                    return search(root.right, num);
                }
            }
        }

        public void printInOrder(Node root)
        {
            if (root.left != null)
            {
                printInOrder(root.left);
            }

            Console.WriteLine(root.data);

            if (root.right != null)
            {
                printInOrder(root.right);
            }
        }

        public Node delete(Node root, int value)
        {
            if (root  == null)
            {
                return null;
            }

            Node x = search(root, value);

            if (x == null)
            {
                return null;
            }

            if (isLeaf(x))
            {
                Node p = getParent(root, x.data);

                if (p.left == null)
                {
                    p.right = null;
                    return x;
                }
                else
                {
                    p.left = null;
                    return x;
                }
            }

            if (oneChild(x))
            {
                Node p = getParent(root, x.data);

                if (p.left.data == x.data)
                {
                    if (x.left == null)
                    {
                        p.left = x.right;
                        return x;
                    }
                    else
                    {
                        p.left = x.left;
                        return x;
                    }
                }
                else
                {
                    if (x.left == null)
                    {
                        p.right = x.right;
                        return x;
                    }
                    else
                    {
                        p.right = x.left;
                        return x;
                    }
                }
            }

            if (twoChild(x))
            {
                Node p = getParent(root, x.data);
                Node i = getIS(x);

                if (p.left.data == x.data)
                {
                    p.left = i;
                    i.left = x.left;
                    i.right = x.right;
                    return x;
                }
                else
                {
                    p.right = i;
                    i.left = x.left;
                    i.right = x.right;
                    return x;
                }

            }

            return null;
        }

        private bool isLeaf(Node node)
        {
            if (node == null)
            {
                return false;
            }
            if (node.left == null && node.right == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool oneChild(Node node)
        {
            if (node == null)
            {
                return false;
            }
            if (node.left != null ^ node.right != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool twoChild(Node node)
        {
            if (node == null)
            {
                return false;
            }
            if (node.left != null && node.right != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Node getParent(Node node, int key)
        {
            if (node == null || node.data == key)
            {
                return null;
            }

            if (node.left != null && node.left.data == key ||
                node.right != null && node.right.data == key)
            {
                return node;
            }

            Node l = getParent(node.left, key);

            if (l != null)
            {
                return l;
            }

            Node r = getParent(node.right, key);

            if (r != null)
            {
                return r;
            }

            return null;
        }

        private Node getIS(Node node)
        {
            if (node == null)
            {
                return null;
            }

            if (node.right != null)
            {
                Node temp = node.right;
                while (temp.left != null)
                {
                    temp = temp.left;
                }
                return temp;
            }

            return null;
        }
        

    }
}

