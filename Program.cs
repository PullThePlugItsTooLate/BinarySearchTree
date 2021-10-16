using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node(30);
            Node n1 = new Node(15);
            Node n2 = new Node(45);
            Node n3 = new Node(6);
            Node n4 = new Node(41);
            Node n5 = new Node(54);

            root.left = n1;
            root.right = n2;
            n1.left = n3;
            n2.left = n4;
            n2.right = n5;

            Node nodeToFind = BinarySearchTree.Search(root, 41);
            Console.WriteLine(nodeToFind.value);

            Node newRoot = BinarySearchTree.Insert(root, 85);
            Console.WriteLine(newRoot.right.right.right.value);
            Console.WriteLine("-----------testing-phase-complete---------");
            BinarySearchTree.InOrderTraversal(newRoot);
            Console.WriteLine("-----------in-order-traversal-complete---------");
            BinarySearchTree.PostOrderTraversal(newRoot);
            Console.WriteLine("-----------post-order-traversal-complete---------");
            BinarySearchTree.PreOrderTraversal(newRoot);
            Console.WriteLine("-----------pre-order-traversal-complete---------");
            Console.ReadLine();
        }

        class Node 
        {
            public int value;
            public Node left;
            public Node right;

            public Node(int value)
            {
                this.value = value;  
            }
        }

        class BinarySearchTree
        {
            public static Node Search(Node root, int value)
            {
                if (root == null)
                {
                    return new Node(-1);
                }
                if (root.value == value)
                {
                    return root;
                }
                else if (value < root.value)
                {
                    //go to the left child
                    root = Search(root.left, value);
                }
                else if (value > root.value) 
                {
                    //go to right child
                    root = Search(root.right, value);
                }

                return root;
            }

            public static Node Insert(Node root, int value) 
            {
                if (root.value == value)
                {
                    return root;

                }
                else if (value < root.value) 
                {
                    if (root.left != null)
                    {
                        root.left = Insert(root.left, value);
                    }
                    else 
                    {
                        //insert
                        Node newNode = new Node(value);
                        root.left = newNode;

                    }
                }
                else if (value > root.value)
                {
                    if (root.right != null)
                    {
                        root.right = Insert(root.right, value);
                    }
                    else
                    {
                        //insert
                        Node newNode = new Node(value);
                        root.right = newNode;

                    }
                }

                return root;
            }

            public static void InOrderTraversal(Node root) 
            {
                if (root.left != null)
                {
                    InOrderTraversal(root.left);
                }
                Console.WriteLine(root.value);

                if (root.right != null)
                {
                    InOrderTraversal(root.right);
                }
            }

            public static void PostOrderTraversal(Node root)
            {
                if (root.left != null)
                {
                    PostOrderTraversal(root.left);
                }

                if (root.right != null)
                {
                    PostOrderTraversal(root.right);
                }

                Console.WriteLine(root.value);
            }

            public static void PreOrderTraversal(Node root)
            {
                Console.WriteLine(root.value);

                if (root.left != null)
                {
                    PreOrderTraversal(root.left);
                }

                if (root.right != null)
                {
                    PreOrderTraversal(root.right);
                }
            }
        }
    }
}
//https://www.youtube.com/watch?v=Blp-_YDojuA