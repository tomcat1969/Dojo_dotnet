using System;

namespace AlgoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

        //     TreeNode node10 = new TreeNode(10);
        //     TreeNode node14 = new TreeNode(14);
        //     TreeNode node12 = new TreeNode(12);
        //     TreeNode node7 = new TreeNode(7);
        //     TreeNode node9 = new TreeNode(9);
        //     TreeNode node5 = new TreeNode(5);
        //     TreeNode node6 = new TreeNode(6);

        //     node10.left = node5;
        //     node10.right = node14;
        //     node14.left = node12;
        //     node5.right = node7;
        //     node7.left = node6;
        //     node7.right = node9;

        //     preOrder(node10);
        //     Console.WriteLine();
        //    //AddNode(node10,4);
        //     // Remove(node10,5);

        //     Console.WriteLine("*******size is ****" + BSTsize(node10));
        //      Console.WriteLine("*******size(v2) is ****" + BSTsize_v2(node10));

        //     Console.WriteLine("$$$$$$$$ the height is $$$$$$$ " + BSThight(node10));

        //      //preOrder(node10);

                Vertex v0 = new Vertex(0);
                Vertex v1 = new Vertex(1);
                Vertex v2 = new Vertex(2);
                Vertex v3 = new Vertex(3);
                Vertex v4 = new Vertex(4);

                v0.neighbors.Add(v0);
                v0.neighbors.Add(v1);
                v0.neighbors.Add(v4);

                v1.neighbors.Add(v1);
                v1.neighbors.Add(v0);
                v1.neighbors.Add(v4);
                v1.neighbors.Add(v3);
                v1.neighbors.Add(v2);

                v2.neighbors.Add(v2);
                v2.neighbors.Add(v1);
                v2.neighbors.Add(v3);

                v3.neighbors.Add(v3);
                v3.neighbors.Add(v1);
                v3.neighbors.Add(v4);
                v3.neighbors.Add(v2);

                v4.neighbors.Add(v4);
                v4.neighbors.Add(v3);
                v4.neighbors.Add(v0);
                v4.neighbors.Add(v1);












        }

        private void AddEdge(Vertex v1,Vertex v2)
        {
            v1.neighbors.Add(v2);
            v2.neighbors.Add(v1);

        }


        private static int BSThight(TreeNode root)
        {
            if(root == null) return 0;
            int leftHeight = BSThight(root.left);
            int rightHeight = BSThight(root.right);
            return Math.Max(leftHeight,rightHeight) + 1;
        }

        private static int BSTsize_v2(TreeNode root) 
        {
            if (root == null) return 0;
            int leftSize = BSTsize(root.left);
            int rightSize = BSTsize(root.right);
            return leftSize + rightSize + 1;
        }

        private static int BSTsize(TreeNode root)
        {
            int[] count = new int[1];
            if(root == null) return 0;
            
            BSTsize_helper(root,count);
           
            return count[0];
        }

        private static void BSTsize_helper(TreeNode root,int[] count) 
        {
            if(root == null) return;
            count[0]++;
            BSTsize_helper(root.left,count);
            BSTsize_helper(root.right,count);

            
        }
        private  static void preOrder(TreeNode root) 
        {
            if(root == null) return;
            
            preOrder(root.left);
            Console.Write(root.val + " ");
            preOrder(root.right);
        }


        private static void AddNode(TreeNode root, int val)
        {
            if (root == null) return ;

            TreeNode newNode = new TreeNode(val);

            if(val < root.val && root.left == null) 
            {
                root.left = newNode;
                return;
            }
            if(val > root.val && root.right == null)
            {
                root.right = newNode;
                return;
            }
            if(val > root.val)
            {
                AddNode(root.right,val);
            }else{
                AddNode(root.left,val);
            }
            
        }

        private static void Remove(TreeNode root,int val) 
        {
            if(root == null) return ;

            if(root.val == val) {
                if(root.left == null && root.right == null)
                {
                    root = null;
                }

                if( root.right == null && root.left != null)
                {
                    root = root.left;
                }
                if(root.left == null && root.right != null)
                {
                    root = root.right;
                }

                if(root.left != null && root.right != null)
                {
                    root = root.left;
                }

            }else if (root.val < val) 
            {
                Remove(root.right,val);
            }else{
                Remove(root.left,val);
            }



        }



    }
}
