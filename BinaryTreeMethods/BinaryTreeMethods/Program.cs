using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = null;
            int[] dizi = { 1, 92, 31, 14, 5, 6, 71 };
            CreateBinaryTree(dizi, 0, ref tree);

            WriteBinaryTree(tree);

            Console.WriteLine(GetHeight(tree));

            Console.WriteLine(FindItem(tree, 1, 0));

            Console.WriteLine(BinaryTreeCarp(tree));

            Console.WriteLine(IsBalanced(tree));
            int a = -1;
            int b = -1;
            FindHighest(tree, ref b, ref a);
            Console.WriteLine(a);
            Console.ReadKey();
        }
        public class BinaryTree
        {
            //Binary veri yapısı
            /*
             *         1
             *        / \
             *       2   3
             *      / \ / \
             *     4  5 6  7
             * 
             */
            public int data { get; set; }
            public BinaryTree left { get; set; }
            public BinaryTree right { get; set; }

        }
        public static BinaryTree CreateBinaryTree(int[] datas, int index, ref BinaryTree Tree)
        {
            //Vereceğimiz dizinin değerlerinin binary tree içine index numaralarını kullanarak yerleştirir
            if (index >= datas.Length) { return null; } //Index dizin sınırına çıkarsa döngü sona erer (Recursive Method)
            BinaryTree temp = new BinaryTree();
            temp.data = datas[index];
            if (Tree == null) { Tree = temp; }

            temp.left = CreateBinaryTree(datas, index * 2 + 1, ref Tree);
            temp.right = CreateBinaryTree(datas, index * 2 + 2, ref Tree);

            return temp;

        }

        public static void WriteBinaryTree(BinaryTree tree)
        {
            if (tree == null) { return; }
            Console.WriteLine(tree.data);//kök
            WriteBinaryTree(tree.left);//sol çocuk
            WriteBinaryTree(tree.right);//sağ çocuk
            //Kök sol ve sağ kısımlarının yerleri değiştirilerek inorder,postorder veya preorder şeklinde yazabiliriz.

        }
        // Yükseklik: kökten yaprağa olan uzaklık 
        public static int GetHeight(BinaryTree tree)
        {
            //Sağ ve sol yükseklikleri recursive olarak kontrol eder, hangi taraf daha büyükse o kısmı returnlar
            if (tree == null) { return -1; }
            int leftHeight = GetHeight(tree.left);
            int rightHeight = GetHeight(tree.right);

            if (leftHeight < rightHeight) { return rightHeight + 1; }
            else
            {
                return leftHeight + 1;
            }

        }
        //Aranan bir elemanın hangi yükseklikte bulunduğunu returnlar
        public static int FindItem(BinaryTree tree, int targeteditem, int currentheight)
        {
            if (tree == null) { return -1; }
            if (tree.data == targeteditem) { return currentheight; }

            int leftsearch = FindItem(tree.left, targeteditem, currentheight + 1);
            int rightsearch = FindItem(tree.right, targeteditem, currentheight + 1);

            if (leftsearch != -1)
            {
                return leftsearch;
            }
            else if (rightsearch != -1)
            {
                return rightsearch;
            }
            else
            {
                return -1;
            }

        }


        //Binary Tree elemanlarının çarpımı
        public static int BinaryTreeCarp(BinaryTree tree)
        {
            if (tree == null) { return 1; }

            int sol = BinaryTreeCarp(tree.left);
            int sag = BinaryTreeCarp(tree.right);
            int total = sol * sag * tree.data;

            return total;

        }
        //Ağacın dengeli olma durumu: yaprakların yükseklikleri arasındaki fark birden fazla ise dengesiz denir.
        public static bool IsBalanced(BinaryTree tree)
        {
            if (tree == null) return true;
            int leftheight = GetHeight(tree.left);
            int rightheight = GetHeight(tree.right);

            if (Math.Abs(leftheight - rightheight) <= 1 && IsBalanced(tree.right) && IsBalanced(tree.left))
            {
                return true;
            }
            return false;
        }
        //En Büyük bir ve ikinci sayıyı binary tree içinde bulur.
        public static void FindHighest(BinaryTree tree, ref int highest, ref int highest2)
        {
            if (tree == null) return;

            if (tree.data > highest)
            {
                highest2 = highest;
                highest = tree.data;
            }
            else if (tree.data < highest && tree.data > highest2)
            {
                highest2 = tree.data;
            }


            FindHighest(tree.left, ref highest, ref highest2);
            FindHighest(tree.right, ref highest, ref highest2);

        }
    }
}
