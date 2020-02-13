using System;

namespace AlgoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            TreeNode node10 = new TreeNode(10);
            TreeNode node14 = new TreeNode(14);

            TreeNode node12 = new TreeNode(12);
            TreeNode node7 = new TreeNode(7);
            TreeNode node9 = new TreeNode(9);
            TreeNode node5 = new TreeNode(5);
            TreeNode node6 = new TreeNode(6);

            node10.left = node5;
            node10.right = node14;
            node14.left = node12;
            node5.right = node7;
            node7.left = node6;
            node7.right = node9;

            preOrder(node10);
            Console.WriteLine();
           AddNode(node10,4);
             preOrder(node10);






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
            if (root == null) return;

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



    }
}
