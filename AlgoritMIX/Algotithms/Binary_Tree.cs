using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritMIX.Algotithms
{
    class Binary_Tree
    {
        //Binary tree
        public class Binary_Search_Tree
        {
            public int? Key { get; set; }
            public int kvo { get; set; }
            public Binary_Search_Tree Left { get; set; }
            public Binary_Search_Tree Right { get; set; }
            public Binary_Search_Tree Parent { get; set; }


            public void Insert(int data)
            {
                if (Key == null || Key == data)
                {
                    Key = data;
                    kvo++;
                    return;
                }
                if (Key > data)
                {
                    if (Left == null)
                    {
                        Left = new Binary_Search_Tree();
                    }
                    Insert(data, Left, this);
                }
                else
                {
                    if (Right == null)
                    {
                        Right = new Binary_Search_Tree();
                    }
                    Insert(data, Right, this);
                }
            }
            private void Insert(int data, Binary_Search_Tree node, Binary_Search_Tree parent)
            {
                if (node.Key == null || node.Key == data)
                {
                    node.Key = data;
                    node.kvo++;
                    node.Parent = parent;
                    return;
                }
                if (node.Key > data)
                {
                    if (node.Left == null)
                    {
                        node.Left = new Binary_Search_Tree();
                    }
                    Insert(data, node.Left, node);
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Right = new Binary_Search_Tree();
                    }
                    Insert(data, node.Right, node);
                }
            }
            private void Insert(Binary_Search_Tree insertNode, Binary_Search_Tree targetNode, Binary_Search_Tree parent)
            {
                if (targetNode.Key == null || targetNode.Key == insertNode.Key)
                {
                    targetNode.Key = insertNode.Key;
                    targetNode.kvo++;
                    targetNode.Left = insertNode.Left;
                    targetNode.Right = insertNode.Right;
                    targetNode.Parent = parent;
                    return;
                }
                if (targetNode.Key > insertNode.Key)
                {
                    if (targetNode.Left == null)
                    {
                        targetNode.Left = new Binary_Search_Tree();
                    }
                    Insert(insertNode, targetNode.Left, targetNode);
                }
                else
                {
                    if (targetNode.Right == null)
                    {
                        targetNode.Right = new Binary_Search_Tree();
                    }
                    Insert(insertNode, targetNode.Right, targetNode);
                }
            }

            public Binary_Search_Tree Find(int data)
            {
                if (Key == data)
                {
                    return this;
                }
                if (Key > data)
                {
                    return Find(data, Left);
                }
                return Find(data, Right);
            }
            private Binary_Search_Tree Find(int data, Binary_Search_Tree node)
            {
                if (node == null)
                {
                    Console.WriteLine("Искомый элемент не найден");
                    return null;
                }
                if (node.Key == data)
                {
                    return node;
                }
                if (node.Key > data)
                {
                    return Find(data, node.Left);
                }
                return Find(data, node.Right);
            }

            public void Remove(Binary_Search_Tree node)
            {
                if (node == null)
                {
                    return;
                }
                //вычисление относительно позиции родителя текущего элемента (лево-право) 
                bool? myPositionLR = DetecktPosition(node);

                //-------------------------------------------------------------------------
                if (myPositionLR != null)
                {
                    if (node.Left == null && node.Right == null)
                    {
                        if (myPositionLR == true)
                        {
                            node.Parent.Right = null;
                        }
                        else
                        {
                            node.Parent.Left = null;
                        }
                        return;
                    }
                    if (node.Right == null)
                    {
                        if (myPositionLR == true)
                        {
                            node.Parent.Right = node.Left;
                        }
                        else
                        {
                            node.Parent.Left = node.Left;
                        }
                        node.Left.Parent = node.Parent;
                        return;
                    }
                    if (node.Left == null)
                    {
                        if (myPositionLR == true)
                        {
                            node.Parent.Right = node.Right;
                        }
                        else
                        {
                            node.Parent.Left = node.Right;
                        }
                        node.Right.Parent = node.Parent;
                        return;
                    }

                    //Если присутствуют оба дочерних узла
                    //то правый ставим на место удаляемого
                    //а левый вставляем Insert() в правый
                    if (myPositionLR == false)
                    {
                        node.Parent.Left = node.Right;
                        node.Right.Parent = node.Parent;
                        Insert(node.Left, node.Right, node.Right);
                    }
                    if (myPositionLR == true)
                    {
                        node.Parent.Right = node.Right;
                        node.Right.Parent = node.Parent;
                        Insert(node.Left, node.Right, node.Right);
                    }
                }

                if (myPositionLR == null)//возможно в начало надо, потестит с однім єлементом
                {
                    var BuffLeft = node.Left;
                    Binary_Search_Tree buffRR = node.Right.Right;
                    Binary_Search_Tree buffRL = node.Right.Left;
                    node.Key = node.Right.Key;
                    node.kvo = node.Right.kvo;
                    node.Left = buffRL;
                    node.Right = buffRR;
                    if (node.Left != null)
                    {
                        node.Left.Parent = node;
                    }
                    if (node.Right != null)
                    {
                        node.Right.Parent = node;
                    }
                    if (BuffLeft != null)
                        Insert(BuffLeft, node, node);
                }
            }
            public void Remove(int data)
            {
                Binary_Search_Tree binaryTree = Find(data);
                if (binaryTree == null)
                {
                    Console.WriteLine("Удаление не было произведено");
                    return;
                }
                if (binaryTree.kvo < 1)
                {
                    kvo--;
                    return;
                }
                Remove(binaryTree);
            }
            private bool? DetecktPosition(Binary_Search_Tree node)
            {
                if (node.Parent == null)
                {
                    return null;
                }
                if (node.Parent.Right == node)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Traverse_infix()
            {
                if (Key == null && Left == null && Right == null)
                    return;
                else
                {
                    if (Left != null)
                    {
                        Traverse_infix(Left);
                    }
                    Console.Write("( Key: " + Key + " Count: " + kvo + " )\n");
                    if (Right != null)
                    {
                        Traverse_infix(Right);
                    }
                }
            } //поперечный обход древа
            private void Traverse_infix(Binary_Search_Tree node)
            {
                if (node.Left != null)
                {
                    Traverse_infix(node.Left);
                }
                Console.Write("( Key: " + node.Key + " Count: " + node.kvo + " )\n");
                if (node.Right != null)
                {
                    Traverse_infix(node.Right);
                }
            }

            public void Traverse_prefix()
            {
                if (Key == null && Left == null && Right == null)
                    return;
                else
                {
                    Console.Write("( Key: " + Key + " Count: " + kvo + " )\n");

                    if (Left != null)
                    {
                        Traverse_prefix(Left);
                    }

                    if (Right != null)
                    {
                        Traverse_prefix(Right);
                    }
                }
            } //прямой обход древа
            private void Traverse_prefix(Binary_Search_Tree node)
            {
                Console.Write("( Key: " + node.Key + " Count: " + node.kvo + " )\n");

                if (node.Left != null)
                {
                    Traverse_prefix(node.Left);
                }

                if (node.Right != null)
                {
                    Traverse_prefix(node.Right);
                }
            }

            public void Traverse_postfix()
            {
                if (Key == null && Left == null && Right == null)
                    return;
                else
                {

                    if (Left != null)
                    {
                        Traverse_postfix(Left);
                    }

                    if (Right != null)
                    {
                        Traverse_postfix(Right);
                    }

                    Console.Write("( Key: " + Key + " Count: " + kvo + " )\n");
                }
            }  //обратный обход древа
            private void Traverse_postfix(Binary_Search_Tree node)
            {
                if (node.Left != null)
                {
                    Traverse_postfix(node.Left);
                }

                if (node.Right != null)
                {
                    Traverse_postfix(node.Right);
                }

                Console.Write("( Key: " + node.Key + " Count: " + node.kvo + " )\n");
            }

            //добавить балансировку (я хуею на телекомуникациях диплом магистра  или аспиранта можно защитить, какая же у них халява была... не то что у нас). 
            // Хотя нет... это уже походу АВЛ древо будет если добавить балансировку... (проверить)
        }

        //AVL Tree
        public class NodeAVL
        {
            public int? Key { get; set; }
            public int Kvo { get; set; }
            public NodeAVL Left { get; set; }
            public NodeAVL Right { get; set; }
        }
        public class AVL_Tree
        {
            public NodeAVL nodeAVL { get; set; }

            public void Insert(int data)
            {
                if (nodeAVL == null)
                {
                    nodeAVL = new NodeAVL();
                }
                if (nodeAVL.Key == null || nodeAVL.Key == data)
                {
                    nodeAVL.Key = data;
                    nodeAVL.Kvo++;
                    return;
                }
                if (nodeAVL.Key > data)
                {
                    if (nodeAVL.Left == null)
                    {
                        nodeAVL.Left = new NodeAVL();
                    }
                    Insert(data, nodeAVL.Left);
                    nodeAVL = Balancer_tree(nodeAVL);
                }
                else
                {
                    if (nodeAVL.Right == null)
                    {
                        nodeAVL.Right = new NodeAVL();
                    }
                    Insert(data, nodeAVL.Right);
                    nodeAVL = Balancer_tree(nodeAVL);
                }

            }
            private void Insert(int data, NodeAVL node)
            {
                if (node.Key == null || node.Key == data)
                {
                    node.Key = data;
                    node.Kvo++;
                    return;
                }
                if (data < node.Key)
                {
                    if (node.Left == null)
                    {
                        node.Left = new NodeAVL();
                    }
                    Insert(data, node.Left);
                    node.Left = Balancer_tree(node.Left);
                }
                if (data > node.Key)
                {
                    if (node.Right == null)
                    {
                        node.Right = new NodeAVL();
                    }
                    Insert(data, node.Right);
                    node.Right = Balancer_tree(node.Right);
                }
            }

            public NodeAVL Find(int data)
            {
                if (nodeAVL.Key == data)
                {
                    return nodeAVL;
                }
                if (nodeAVL.Key > data)
                {
                    return Find(data, nodeAVL.Left);
                }
                return Find(data, nodeAVL.Right);
            }
            private NodeAVL Find(int data, NodeAVL node)
            {
                if (node == null)
                {
                    Console.WriteLine("Искомый элемент не найден");
                    return null;
                }
                if (node.Key == data)
                {
                    return node;
                }
                if (node.Key > data)
                {
                    return Find(data, node.Left);
                }
                return Find(data, node.Right);
            }

            private int Height(NodeAVL current)
            {
                int h = 0;
                if (current != null)
                {
                    int l = Height(current.Left);
                    int r = Height(current.Right);
                    h = l >= r ? l : r;
                    h++;
                }
                return h;
            }
            private NodeAVL Balancer_tree(NodeAVL node)
            {
                int balance_point = Balance_point(node);
                if (balance_point == 2)
                {
                    if (Balance_point(node.Left) == 1)
                    {
                        node = Rotate_LL(node);
                    }
                    else
                    {
                        node = Rotate_LR(node);
                    }
                }
                else if (balance_point == -2)
                {
                    if (Balance_point(node.Right) == -1)
                    {
                        node = Rotate_RR(node);
                    }
                    else
                    {
                        node = Rotate_RL(node);
                    }
                }
                return node;
            }
            private int Balance_point(NodeAVL node)
            {
                int l = Height(node.Left);
                int r = Height(node.Right);
                int balance_point = l - r;
                return balance_point;
            }

            private NodeAVL Rotate_LL(NodeAVL node)
            {
                NodeAVL newNode = node.Left;
                node.Left = newNode.Right;
                newNode.Right = node;
                return newNode;
            }
            private NodeAVL Rotate_LR(NodeAVL node)
            {
                NodeAVL newNode = node.Left;
                node.Left = Rotate_RR(newNode);
                return Rotate_LL(node);
            }
            private NodeAVL Rotate_RR(NodeAVL node)
            {
                NodeAVL newNode = node.Right;
                node.Right = newNode.Left;
                newNode.Left = node;
                return newNode;
            }
            private NodeAVL Rotate_RL(NodeAVL node)
            {
                NodeAVL newNode = node.Right;
                node.Right = Rotate_LL(newNode);
                return Rotate_RR(node);
            }
        }

        //Red-Black Tree
        public class RB_Tree
        {
            public enum RBColor { Red, Black }

            public class NodeRB
            {
                public int? Key { get; set; }
                public RBColor Color { get; set; }
                public int Sum { get; set; }
                public NodeRB Left { get; set; }
                public NodeRB Right { get; set; }
                public NodeRB Parent { get; set; }
            }

            public NodeRB Tree { get; set; }

            public void Insert(int data)
            {
                if (Tree == null)
                {
                    Tree = new NodeRB();
                    Tree.Key = data;
                    Tree.Color = RBColor.Black;
                    Tree.Sum++;
                    return;
                }
                if (Tree.Key == data)
                {
                    Tree.Sum++;
                    return;
                }
                if (data < Tree.Key)
                {
                    if (Tree.Left == null)
                        Tree.Left = new NodeRB();
                    Insert(data, Tree.Left, Tree);
                    //rebalans
                }
                else
                {
                    if (Tree.Right == null)
                        Tree.Right = new NodeRB();
                    Insert(data, Tree.Right, Tree);
                    //rebalans
                }
            }
            private void Insert(int data, NodeRB node, NodeRB parent)
            {
                if (node.Key == null)
                {
                    node.Key = data;
                    node.Sum++;
                    node.Color = RBColor.Red;
                    node.Parent = parent;
                    InsertBalanser(node);
                    return;
                }
                if (node.Key == data)
                {
                    node.Sum++;
                    return;
                }
                if (data < node.Key)
                {
                    if (node.Left == null)
                        node.Left = new NodeRB();
                    Insert(data, node.Left, node);
                    //balanser
                }
                else
                {
                    if (node.Right == null)
                        node.Right = new NodeRB();
                    Insert(data, node.Right, node);
                    //balanser
                }
            }
            public NodeRB Find(int data)
            {
                if (Tree == null)
                    return null;
                if (Tree.Key == data)
                    return Tree;
                if (data < Tree.Key)
                    return Find(data, Tree.Left);
                return Find(data, Tree.Right);
            }
            private NodeRB Find(int data, NodeRB node)
            {
                if (node == null)
                    return null;
                if (node.Key == data)
                    return node;
                if (data < node.Key)
                    return Find(data, node.Left);
                return Find(data, node.Right);
            }

            private NodeRB FindMin(NodeRB node)
            {
                if (node == null)
                    return null;
                if (node.Left != null)
                {
                    return FindMin(node.Left);
                }
                else
                {
                    return node;
                }
            }
            private NodeRB FindMax(NodeRB node)
            {
                if (node == null)
                    return null;
                if (node.Right != null)
                {
                    return FindMax(node.Right);
                }
                else
                {
                    return node;

                }
            }

            public void Delete(int data)
            {
                NodeRB DelItem = Find(data);
                if (DelItem == null)
                {
                    Console.WriteLine("ERROR - item not faund");
                }
                else
                {
                    if (DelItem.Sum > 1)
                    {
                        DelItem.Sum--;
                    }
                    else
                    {
                        Delete(DelItem);
                    }
                }
            }
            private void Delete(NodeRB node)
            {
                NodeRB DeletingNode = node;
                NodeRB ZamenaItem;
                RBColor FirstColor = node.Color;

                bool? myPosition;
                if (node.Parent == null)
                    myPosition = null;
                else if (node.Parent.Left == node)
                    myPosition = false;
                else
                    myPosition = true;
                //1
                if (node.Left == null && node.Right == null)
                {
                    if (myPosition == null)
                    {
                        node.Key = null;
                        node.Sum = 0;
                    }
                    if (myPosition == false)
                        node.Parent.Left = null;
                    if (myPosition == true)
                        node.Parent.Right = null;

                    node.Parent = null;
                }

                //2
                if (node.Left != null && node.Right == null)
                {
                    if (myPosition == null)
                    {
                        Tree = node.Left;
                        node.Left.Parent = null;
                        //node.Left = null; 
                    }
                    if (myPosition == false)
                    {
                        node.Parent.Left = node.Left;
                        node.Left.Parent = node.Parent;
                        //node.Parent = null;
                        //node.Left = null;
                    }
                    if (myPosition == true)
                    {
                        node.Parent.Right = node.Left;
                        node.Left.Parent = node.Parent;
                        //node.Parent = null;
                        //node.Left = null;
                    }
                }
                if (node.Left == null && node.Right != null)
                {
                    if (myPosition == null)
                    {
                        Tree = node.Right;
                        node.Right.Parent = null;
                        //node.Right = null;
                    }
                    if (myPosition == false)
                    {
                        node.Parent.Left = node.Right;
                        node.Right.Parent = node.Parent;
                        //node.Parent = null;
                        //node.Right = null;
                    }
                    if (myPosition == true)
                    {
                        node.Parent.Right = node.Right;
                        node.Right.Parent = node.Parent;
                        node.Parent = null;
                        node.Right = null;
                    }
                }
                //3
                if (node.Left != null && node.Right != null)
                {
                    ZamenaItem = FindMin(node.Right);
                    node.Key = ZamenaItem.Key;
                    node.Sum = ZamenaItem.Sum;

                    if (node.Color == RBColor.Red)
                    {
                        node.Color = ZamenaItem.Color;
                        Delete(ZamenaItem);
                        return;
                    }
                    if (node.Color == RBColor.Black && ZamenaItem.Color == RBColor.Red)
                    {
                        node.Color = RBColor.Black;
                        Delete(ZamenaItem);
                        return;
                    }
                    if (node.Color == RBColor.Black && ZamenaItem.Color == RBColor.Black)
                    {
                        DeleteBalanser(node);
                    }
                }

            }

            private void LeftRotate(NodeRB X)
            {
                NodeRB Y = X.Right;
                X.Right = Y.Left;

                if (Y.Left != null)
                    Y.Left.Parent = X;

                if (Y != null)
                    Y.Parent = X.Parent;



                if (X.Parent == null)
                    Tree = Y;
                else
                {
                    if (X.Parent.Left == X)
                        X.Parent.Left = Y;

                    if (X.Parent.Right == X)
                        X.Parent.Right = Y;
                }
                Y.Left = X;

                if (X != null)
                    X.Parent = Y;

            }
            private void RightRotate(NodeRB Y)
            {
                NodeRB X = Y.Left;
                Y.Left = X.Right;

                if (X != null)
                    X.Parent = Y.Parent;

                if (X.Right != null)
                    X.Right.Parent = Y;

                if (Y.Parent == null)
                    Tree = X;
                else
                {
                    if (Y.Parent.Left == Y)
                        Y.Parent.Left = X;

                    if (Y.Parent.Right == Y)
                        Y.Parent.Right = X;
                }
                X.Right = Y;

                if (Y != null)
                    Y.Parent = X;
            }
            private void InsertBalanser(NodeRB node)
            {
                while (node != Tree && node.Parent.Color == RBColor.Red)
                {
                    if (node.Parent == node.Parent.Parent.Left)
                    {
                        NodeRB Right_Uncle = node.Parent.Parent.Right;
                        if (Right_Uncle != null && Right_Uncle.Color == RBColor.Red) //uncle - red
                        {
                            node.Parent.Color = RBColor.Black;
                            Right_Uncle.Color = RBColor.Black;
                            node.Parent.Parent.Color = RBColor.Red;
                            node = node.Parent.Parent;
                        }
                        else   //uncle - black
                        {
                            if (node == node.Parent.Right)
                            {
                                node = node.Parent;
                                LeftRotate(node);
                            }
                            node.Parent.Color = RBColor.Black;
                            node.Parent.Parent.Color = RBColor.Red;
                            RightRotate(node.Parent.Parent);
                        }
                    }
                    else //mirorr
                    {
                        NodeRB Left_Uncle = node.Parent.Parent.Left;
                        if (Left_Uncle != null && Left_Uncle.Color == RBColor.Red) // uncle - red
                        {
                            node.Parent.Color = RBColor.Black;
                            Left_Uncle.Color = RBColor.Black;
                            node.Parent.Parent.Color = RBColor.Red;
                            node = node.Parent.Parent;
                        }
                        else
                        {
                            if (node == node.Parent.Left)
                            {
                                node = node.Parent;
                                RightRotate(node);
                            }
                            node.Parent.Color = RBColor.Black;
                            node.Parent.Parent.Color = RBColor.Red;
                            LeftRotate(node.Parent.Parent);
                        }
                    }
                }
                Tree.Color = RBColor.Black;
            }
            private void DeleteBalanser(NodeRB node)
            {
                while (node != null && node != Tree && node.Color == RBColor.Black)
                {
                    if (node.Parent.Left == node)
                    {
                        NodeRB RightBraser = node.Parent.Right;
                        //1
                        if (node.Parent.Right.Color == RBColor.Red)
                        {
                            node.Parent.Color = RBColor.Red;
                            node.Parent.Right.Color = RBColor.Black;
                            LeftRotate(node.Parent);
                            RightBraser = node.Parent.Right;
                        }
                        //2
                        if (RightBraser.Color == RBColor.Black)
                        {
                            if (RightBraser.Left.Color == RBColor.Black && RightBraser.Right.Color == RBColor.Black)
                            {
                                RightBraser.Color = RBColor.Red;
                                node = node.Parent;
                            }
                            if (RightBraser.Left.Color == RBColor.Red && RightBraser.Right.Color == RBColor.Black)
                            {
                                RightBraser.Color = RBColor.Red;
                                RightBraser.Left.Color = RBColor.Black;
                                RightRotate(RightBraser.Left);
                                RightBraser = node.Parent.Right;
                            }
                            if (RightBraser.Right.Color == RBColor.Red)
                            {
                                RightBraser.Color = node.Parent.Color;
                                node.Parent.Color = RBColor.Black;
                                RightBraser.Right.Color = RBColor.Black;
                                LeftRotate(node.Parent);
                                break;
                            }
                        }
                    }
                    else //mirror
                    {
                        NodeRB LeftBraser = node.Parent.Left;
                        //1
                        if (node.Parent.Left.Color == RBColor.Red)
                        {
                            node.Parent.Color = RBColor.Red;
                            node.Parent.Right.Color = RBColor.Black;
                            RightRotate(node.Parent);
                            LeftBraser = node.Parent.Left;
                        }
                        //2
                        if (LeftBraser.Color == RBColor.Black)
                        {
                            if (LeftBraser.Left.Color == RBColor.Black && LeftBraser.Right.Color == RBColor.Black)
                            {
                                LeftBraser.Color = RBColor.Red;
                                node = node.Parent;
                            }
                            if (LeftBraser.Right.Color == RBColor.Red && LeftBraser.Left.Color == RBColor.Black)
                            {
                                LeftBraser.Color = RBColor.Red;
                                LeftBraser.Right.Color = RBColor.Black;
                                LeftRotate(LeftBraser.Right);
                                LeftBraser = node.Parent.Left;
                            }
                            if (LeftBraser.Left.Color == RBColor.Red)
                            {
                                LeftBraser.Color = node.Parent.Color;
                                node.Parent.Color = RBColor.Black;
                                LeftBraser.Left.Color = RBColor.Black;
                                RightRotate(node.Parent);
                                break;
                            }
                        }
                    }
                }
                if (Tree != null)
                {
                    Tree.Color = RBColor.Black;
                }
            }
        }

    }
}
