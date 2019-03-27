using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritMIX.Algotithms
{
    class Compresion
    {
        //Arithmetic sec
        public class Item
        {
            public char Symbol { get; set; }
            public double Low { get; set; }
            public double High { get; set; }
            public double ProbabilityAndWidth { get; set; }
            public int Frequency { get; set; }
        }
        public class ArithmCompression
        {
            // Ω
            List<Item> items = new List<Item>();
            Dictionary<char, int> frequncy = new Dictionary<char, int>();

            public void BuildItems(string str)
            {
                str += "Ω";
                for (int i = 0; i < str.Length; i++)
                {
                    if (!frequncy.ContainsKey(str[i]))
                    {
                        frequncy.Add(str[i], 0);
                    }
                    frequncy[str[i]]++;
                }
                foreach (KeyValuePair<char, int> pair in frequncy)
                {
                    items.Add(new Item { Symbol = pair.Key, Frequency = pair.Value });
                }
                var items2 = from itm in items
                             orderby itm.Frequency ascending
                             select itm;
                items = new List<Item>();
                foreach (var itm2 in items2)
                {
                    items.Add(new Item { Symbol = itm2.Symbol, Frequency = itm2.Frequency });
                    Console.WriteLine(itm2.Symbol + " " + itm2.Frequency);
                }

            }
            public List<Item> GetNodesFull(string str)
            {
                str += "Ω";
                double start = 0;
                foreach (Item itm in items)
                {
                    itm.ProbabilityAndWidth = Math.Round(((double)itm.Frequency / (str.Length + 1)), 2);
                    itm.Low = Math.Round(start, 2);
                    itm.High = start + itm.ProbabilityAndWidth;
                    start += itm.ProbabilityAndWidth;
                    //Console.WriteLine(itm.Symbol + "   " + itm.Low + "   " + itm.High + "   " + itm.ProbabilityAndWidth + "   " + itm.Frequency);
                }
                return items;
            }

            public double Encode(List<Item> item_list, string str)
            {
                double max_hight = 1;
                double max_low = 0;
                double oldH = 1, oldL = 0;

                str += "Ω";//esc simbol
                for (int i = 0; i < str.Length; i++)
                {
                    for (int j = 0; j < item_list.Count; j++)
                    {
                        if (str[i] == item_list[j].Symbol)
                        {

                            max_hight = oldL + (oldH - oldL) * item_list[j].High;
                            max_low = oldL + (oldH - oldL) * item_list[j].Low;
                            oldH = max_hight;
                            oldL = max_low;

                        }
                    }
                }
                return (max_low + max_hight) / 2;
            }
            public string Decode(List<Item> item_list, double code)
            {
                StringBuilder sb = new StringBuilder();
                while (true)
                {
                    for (int i = 0; i < item_list.Count; i++)
                    {
                        if (code >= item_list[i].Low && code < item_list[i].High)
                        {
                            if (item_list[i].Symbol != 'Ω')
                            {
                                sb.Append(item_list[i].Symbol);
                                code = (code - item_list[i].Low) / (item_list[i].High - item_list[i].Low);

                            }
                            else
                            {
                                return sb.ToString();
                            }
                        }
                    }
                }
            }
        }


        //Huffman sec
        struct TreeWeight
        {
            public char ValueKey { get; set; }
            public int WeightKey { get; set; }
            public TreeWeight(char a, int b)
            {
                ValueKey = a;
                WeightKey = b;
            }
        }
        public class Node
        {
            public char? Simbol { get; set; }
            public int Ves { get; set; }
            public Node Right { get; set; }
            public Node Left { get; set; }
            public Node Parent { get; set; }

            public List<bool> Find(char ch, List<bool> data)
            {
                if (Left == null && Right == null)
                {
                    if (ch.Equals(this.Simbol))
                    {
                        return data;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    List<bool> left = null;
                    List<bool> right = null;
                    if (Left != null)
                    {
                        List<bool> leftPath = new List<bool>();
                        leftPath.AddRange(data);
                        leftPath.Add(false);

                        left = Left.Find(ch, leftPath);
                    }
                    if (Right != null)
                    {
                        List<bool> rightPath = new List<bool>();
                        rightPath.AddRange(data);
                        rightPath.Add(true);

                        right = Right.Find(ch, rightPath);
                    }

                    if (left != null)
                    {
                        return left;
                    }
                    else
                    {
                        return right;
                    }
                }

            }

        }
        public class Huffman
        {
            public Node Wood { get; set; }
            public string STR { get; set; }
            public BitArray Compresed { get; set; }

            public Huffman(string text)
            {
                Wood = TreeBilder(NodeList(text));
                STR = text;
            }

            private List<Node> NodeList(string val)
            {

                //Create
                List<Node> nodes = new List<Node>();
                List<TreeWeight> treeWeightsList = new List<TreeWeight>();
                int index = 0;
                while (val.Length != 0)
                {
                    index = 0;
                    foreach (char a in val)
                    {
                        if (val[0] == a)
                        {
                            index++;
                        }

                    }
                    treeWeightsList.Add(new TreeWeight(val[0], index));
                    val = val.Replace(Convert.ToString(val[0]), "");
                }
                //test ebola
                foreach (TreeWeight tree in treeWeightsList)
                {
                    Console.WriteLine(tree.ValueKey + "   " + tree.WeightKey);
                }

                //sorting
                var items = from treeView in treeWeightsList
                            orderby treeView.WeightKey ascending
                            select treeView;

                treeWeightsList = new List<TreeWeight>();
                foreach (var tree2 in items)
                {
                    nodes.Add(new Node { Simbol = tree2.ValueKey, Ves = tree2.WeightKey, Left = null, Right = null, Parent = null });      //new TreeWeight(tree2.ValueKey, tree2.WeightKey));
                }
                foreach (var t in nodes)
                {
                    Console.WriteLine(t.Simbol + "  " + t.Ves);
                }
                if (nodes[0] != nodes[0]) { Console.WriteLine("!+"); }


                return nodes;

            }
            private Node TreeBilder(List<Node> nodes)
            {
                Node min_1, min_2;
                int min_index_1, min_index_2;
                while (nodes.Count > 1)
                {
                    min_index_1 = 0;
                    min_index_2 = 1;
                    min_1 = nodes[0];
                    min_2 = nodes[1];
                    for (int i = 2; i < nodes.Count; i++)
                    {
                        if (nodes[i].Ves < min_1.Ves)
                        {
                            min_1 = nodes[i];
                            min_index_1 = i;
                        }
                        else if (nodes[i].Ves < min_2.Ves)
                        {
                            min_2 = nodes[i];
                            min_index_2 = i;
                        }
                    }
                    nodes.Add(new Node { Simbol = null, Ves = min_1.Ves + min_2.Ves, Left = min_1, Right = min_2 });

                    min_1.Parent = min_2.Parent = nodes[nodes.Count - 1];
                    if (min_index_1 < min_index_2)
                    {
                        nodes.RemoveAt(min_index_2);
                        nodes.RemoveAt(min_index_1);
                    }
                    else
                    {
                        nodes.RemoveAt(min_index_1);
                        nodes.RemoveAt(min_index_2);

                    }
                }

                return nodes[0];
            }
            public void TreeStart(string text)
            {
                Wood = TreeBilder(NodeList(text));
                STR = text;

            }

            public BitArray Encode()
            {
                if (STR.Length != 0 && Wood != null)
                {
                    List<bool> encodedText = new List<bool>();
                    for (int i = 0; i < STR.Length; i++)
                    {
                        List<bool> encodedSymbol = Wood.Find(STR[i], new List<bool>());
                        encodedText.AddRange(encodedSymbol);
                    }
                    BitArray bitArray = new BitArray(encodedText.ToArray());

                    Compresed = bitArray;
                    return bitArray;
                }
                else
                {

                    return null;
                }

            }
            public string Decode()
            {

                if (Compresed.Length != 0)
                {
                    Node current = Wood;
                    StringBuilder sb = new StringBuilder();
                    foreach (bool b in Compresed)
                    {
                        if (b)
                        {
                            if (current.Right != null)
                            {
                                current = current.Right;
                            }
                        }
                        else
                        {
                            if (current.Left != null)
                            {
                                current = current.Left;
                            }
                        }
                        if (current.Left == null && current.Right == null)
                        {
                            sb.Append(current.Simbol);
                            current = Wood;
                        }
                    }

                    return sb.ToString();
                }
                else
                {
                    return null;
                }

            }

            public void Print_OriginBinCode()
            {
                StringBuilder sb = new StringBuilder();
                foreach (byte b in System.Text.Encoding.Unicode.GetBytes(STR))
                    sb.Append(Convert.ToString(b, 2).PadLeft(8, '0')).Append(' ');

                //Console.WriteLine(sb.ToString());
                MessageBox.Show(sb.ToString(), "Print_OriginBinCode()");
                
                //Console.WriteLine(sb.Length);
            }
            public void Print_CompresedCode()
            {
                
                string sb = "";
                for (int j = 0; j < Compresed.Length; j++)
                {
                    sb = sb + Convert.ToString(Compresed[j] ? 1 : 0);
                    if (j > 0 && j % 8 == 0)
                    {
                        sb += " ";
                    }
                }
                MessageBox.Show(sb, "Print_CompresedCode()");
               
            }
        }
    }
}
