using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using AlgoritMIX.Algotithms;

namespace AlgoritMIX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Loading_info();
            TreeView_loading();
        }


        private void Loading_info()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("./Algorithm_Info/Substring_search_info.xml");
            
            foreach (XmlNode node in doc.DocumentElement)
            {
                switch (node.Attributes[0].Value)
                {
                    case "Direct search":
                        /*tabControl5.TabPages[0].VerticalScroll.Enabled = true;
                        tabControl5.TabPages[0].VerticalScroll.Visible = true;
                        */
                        TextBox textDS = new TextBox();
                        textDS.Name = "Direct search";
                        textDS.Text = node["text"].InnerText;
                        textDS.TextAlign = HorizontalAlignment.Left;
                        textDS.Font = new Font("Arial Bold", 12);
                        textDS.Dock = DockStyle.Fill;
                        textDS.Multiline = true;
                        textDS.ScrollBars = ScrollBars.Vertical;
                        textDS.ReadOnly = true;

                        directSearch_Page.Controls.Add(textDS);
                        break;

                    case "BM Search":
                        TextBox textBM = new TextBox();
                        textBM.Name = "BM Search";
                        textBM.Text = node["text"].InnerText;
                        textBM.TextAlign = HorizontalAlignment.Left;
                        textBM.Font = new Font("Arial Bold", 12);
                        textBM.Dock = DockStyle.Fill;
                        textBM.Multiline = true;
                        textBM.ScrollBars = ScrollBars.Vertical;
                        textBM.ReadOnly = true;

                        tabPage2.Controls.Add(textBM);
                        break;
                    case "Test":
                        richTextBox_testSearch.Text = node["text"].InnerText;
                        break;

                    default: break;
                }

            }

            doc = new XmlDocument();
            doc.Load("./Algorithm_Info/Sorting_info.xml");

            foreach (XmlNode node in doc.DocumentElement)
            {
                switch (node.Attributes[0].Value)
                {
                    case "Bubble sort":

                        TextBox textBS = new TextBox();
                        textBS.Name = "Bubble sort";
                        textBS.Text = node["text"].InnerText  + node["algorithm_complexity"].InnerText; 
                        textBS.TextAlign = HorizontalAlignment.Left;
                        textBS.Font = new Font("Arial Bold", 12);
                        textBS.Dock = DockStyle.Fill;
                        textBS.Multiline = true;
                        textBS.ScrollBars = ScrollBars.Vertical;
                        textBS.ReadOnly = true;

                        bubbleSort_Page.Controls.Add(textBS);
                        break;

                    case "Gnome sort":
                        TextBox textGn = new TextBox();
                        textGn.Name = "Gnome sort";
                        textGn.Text = node["text"].InnerText + node["algorithm_complexity"].InnerText;
                        textGn.TextAlign = HorizontalAlignment.Left;
                        textGn.Font = new Font("Arial Bold", 12);
                        textGn.Dock = DockStyle.Fill;
                        textGn.Multiline = true;
                        textGn.ScrollBars = ScrollBars.Vertical;
                        textGn.ReadOnly = true;

                        gnomeSort_Page.Controls.Add(textGn);
                        break;

                    case "Comb sort":
                        TextBox textCmS = new TextBox();
                        textCmS.Name = "Comb sort";
                        textCmS.Text = node["text"].InnerText + node["algorithm_complexity"].InnerText;
                        textCmS.TextAlign = HorizontalAlignment.Left;
                        textCmS.Font = new Font("Arial Bold", 12);
                        textCmS.Dock = DockStyle.Fill;
                        textCmS.Multiline = true;
                        textCmS.ScrollBars = ScrollBars.Vertical;
                        textCmS.ReadOnly = true;

                        combSort_Page.Controls.Add(textCmS);
                        break;

                    case "Insertion sort":
                        TextBox textIns = new TextBox();
                        textIns.Name = "Insertion sort";
                        textIns.Text = node["text"].InnerText + node["algorithm_complexity"].InnerText;
                        textIns.TextAlign = HorizontalAlignment.Left;
                        textIns.Font = new Font("Arial Bold", 12);
                        textIns.Dock = DockStyle.Fill;
                        textIns.Multiline = true;
                        textIns.ScrollBars = ScrollBars.Vertical;
                        textIns.ReadOnly = true;

                        insertSort_Page.Controls.Add(textIns);
                        break;

                    case "Shell sort":
                        TextBox textShS = new TextBox();
                        textShS.Name = "Shell sort";
                        textShS.Text = node["text"].InnerText + node["algorithm_complexity"].InnerText;
                        textShS.TextAlign = HorizontalAlignment.Left;
                        textShS.Font = new Font("Arial Bold", 12);
                        textShS.Dock = DockStyle.Fill;
                        textShS.Multiline = true;
                        textShS.ScrollBars = ScrollBars.Vertical;
                        textShS.ReadOnly = true;

                        shellSort_Page.Controls.Add(textShS);
                        break;

                    case "Tree sort":
                        TextBox textTrS = new TextBox();
                        textTrS.Name = "Tree sort";
                        textTrS.Text = node["text"].InnerText + node["algorithm_complexity"].InnerText;
                        textTrS.TextAlign = HorizontalAlignment.Left;
                        textTrS.Font = new Font("Arial Bold", 12);
                        textTrS.Dock = DockStyle.Fill;
                        textTrS.Multiline = true;
                        textTrS.ScrollBars = ScrollBars.Vertical;
                        textTrS.ReadOnly = true;

                        treeSort_Page.Controls.Add(textTrS);
                        break;

                    case "Selection sort":
                        TextBox textSeS = new TextBox();
                        textSeS.Name = "Selection sort";
                        textSeS.Text = node["text"].InnerText + node["algorithm_complexity"].InnerText;
                        textSeS.TextAlign = HorizontalAlignment.Left;
                        textSeS.Font = new Font("Arial Bold", 12);
                        textSeS.Dock = DockStyle.Fill;
                        textSeS.Multiline = true;
                        textSeS.ScrollBars = ScrollBars.Vertical;
                        textSeS.ReadOnly = true;

                        selectionSort_Page.Controls.Add(textSeS);
                        break;

                    case "Shaker sort":
                        TextBox textSh = new TextBox();
                        textSh.Name = "Heap sort";
                        textSh.Text = node["text"].InnerText + node["algorithm_complexity"].InnerText;
                        textSh.TextAlign = HorizontalAlignment.Left;
                        textSh.Font = new Font("Arial Bold", 12);
                        textSh.Dock = DockStyle.Fill;
                        textSh.Multiline = true;
                        textSh.ScrollBars = ScrollBars.Vertical;
                        textSh.ReadOnly = true;

                        shakerSort_Page.Controls.Add(textSh);
                        break;

                    case "Heap sort":
                        TextBox textHeS = new TextBox();
                        textHeS.Name = "Heap sort";
                        textHeS.Text = node["text"].InnerText + node["algorithm_complexity"].InnerText;
                        textHeS.TextAlign = HorizontalAlignment.Left;
                        textHeS.Font = new Font("Arial Bold", 12);
                        textHeS.Dock = DockStyle.Fill;
                        textHeS.Multiline = true;
                        textHeS.ScrollBars = ScrollBars.Vertical;
                        textHeS.ReadOnly = true;

                        heapSort_Page.Controls.Add(textHeS);
                        break;

                    case "Quick sort":
                        TextBox textQS = new TextBox();
                        textQS.Name = "Quick sort";
                        textQS.Text = node["text"].InnerText + node["algorithm_complexity"].InnerText;
                        textQS.TextAlign = HorizontalAlignment.Left;
                        textQS.Font = new Font("Arial Bold", 12);
                        textQS.Dock = DockStyle.Fill;
                        textQS.Multiline = true;
                        textQS.ScrollBars = ScrollBars.Vertical;
                        textQS.ReadOnly = true;

                        quickSort_Page.Controls.Add(textQS);
                        break;

                    case "Radix LSD":
                        TextBox textR = new TextBox();
                        textR.Name = "Radix LSD";
                        textR.Text = node["text"].InnerText + node["algorithm_complexity"].InnerText;
                        textR.TextAlign = HorizontalAlignment.Left;
                        textR.Font = new Font("Arial Bold", 12);
                        textR.Dock = DockStyle.Fill;
                        textR.Multiline = true;
                        textR.ScrollBars = ScrollBars.Vertical;
                        textR.ReadOnly = true;

                        radixLsdSort_Page.Controls.Add(textR);
                        break;

                    default: break;
                }

            }

            doc = new XmlDocument();
            doc.Load("./Algorithm_Info/Compresion_info.xml");
            foreach (XmlNode node in doc.DocumentElement)
            {
                switch (node.Attributes[0].Value)
                {
                    case "Arithmetic":
                        Arithmetic_textBox1.Text = node["text"].InnerText;
                        Arithmetic_textBox2.Text = "Corax";
                        break;

                    case "Huffman":
                        Huffman_textBox1.Text = node["text"].InnerText;
                        Huffman_textBox2.Text = "Тот, кто не может лгать, не знает, что такое правда. — Фридрих Ницше";
                        break;

                    
                    default: break;
                }

            }

            doc = new XmlDocument();
            doc.Load("./Algorithm_Info/Tree_info.xml");
            foreach (XmlNode node in doc.DocumentElement)
            {
                switch (node.Attributes[0].Value)
                {
                    case "Binary Search Tree":
                        bst_textBox.Text = node["text"].InnerText;
                        break;

                    case "AVL Tree":
                        avl_textBox.Text = node["text"].InnerText;
                        break;

                    case "Red-Black Tree":
                        rbt_textBox.Text = node["text"].InnerText;
                        break;


                    default: break;
                }

            }
        }
        private void TreeView_loading()
        {

            Binary_Tree.Binary_Search_Tree bst = new Binary_Tree.Binary_Search_Tree();
            Binary_Tree.AVL_Tree avl = new Binary_Tree.AVL_Tree();
            Binary_Tree.RB_Tree rbt = new Binary_Tree.RB_Tree();
            
            
            int[] vs4 = { -11, 34, 43, 65, 7, 15, 0, 1, -42, 5, 0, 12, 42, -4, 1 };
            for (int i=0; i < 15; i++)
            {
               
                bst.Insert(vs4[i]);
                avl.Insert(vs4[i]);
                rbt.Insert(vs4[i]);
            }

            subBST(bst);
            subAVl(avl.nodeAVL);
            subRBT(rbt.Tree);
        }
        
        private void subBST(Binary_Tree.Binary_Search_Tree bst)
        {
            if (bst == null)
            {
                return;
            }
            string x = string.Format("Key:{0} Count:{1}", bst.Key, bst.kvo);
            bst_treeView.Nodes.Add(x, x);
            if (bst.Left != null)
            {
                sub(bst.Left, ref bst_treeView, x);
            }
            if (bst.Right != null)
            {
                sub(bst.Right, ref bst_treeView, x);

            }
        }
        private void sub(Binary_Tree.Binary_Search_Tree bst_node, ref TreeView nodeTV, string x)
        {
            string x2 = string.Format("Key:{0} Count:{1}", bst_node.Key, bst_node.kvo);
            TreeNode[] newN = nodeTV.Nodes.Find(x, true);
            newN[0].Nodes.Add(new TreeNode { Name = x2, Text = x2 });

            if (bst_node.Left != null)
            {

                sub(bst_node.Left, ref nodeTV, x2);
            }

            if (bst_node.Right != null)
            {
                sub(bst_node.Right, ref nodeTV, x2);
            }
        }

        private void subAVl(Binary_Tree.NodeAVL avl)
        {
            if (avl == null)
            {
                return;
            }
            string x = string.Format("Key:{0} Count:{1}", avl.Key, avl.Kvo);
            avl_treeView.Nodes.Add(x, x);
            if (avl.Left != null)
            {
                sub(avl.Left, ref avl_treeView, x);
            }
            if (avl.Right != null)
            {
                sub(avl.Right, ref avl_treeView, x);

            }
        }
        private void sub(Binary_Tree.NodeAVL avl_node, ref TreeView nodeTV, string x)
        {
            string x2 = string.Format("Key:{0} Count:{1}", avl_node.Key, avl_node.Kvo);
            TreeNode[] newN = nodeTV.Nodes.Find(x, true);
            newN[0].Nodes.Add(new TreeNode { Name = x2, Text = x2 });

            if (avl_node.Left != null)
            {

                sub(avl_node.Left, ref nodeTV, x2);
            }

            if (avl_node.Right != null)
            {
                sub(avl_node.Right, ref nodeTV, x2);
            }
        }

        private void subRBT(Binary_Tree.RB_Tree.NodeRB rb)
        {
            if (rb == null)
            {
                return;
            }
            string x = string.Format("Key:{0} Count:{1} Color:{2}", rb.Key, rb.Sum, rb.Color);
            rbt_treeView.Nodes.Add(x, x);
            if (rb.Left != null)
            {
                sub(rb.Left, ref rbt_treeView, x);
            }
            if (rb.Right != null)
            {
                sub(rb.Right, ref rbt_treeView, x);

            }
        }
        private void sub(Binary_Tree.RB_Tree.NodeRB rb_node, ref TreeView nodeTV, string x)
        {
            string x2 = string.Format("Key:{0} Count:{1} Color:{2}", rb_node.Key, rb_node.Sum, rb_node.Color);
            TreeNode[] newN = nodeTV.Nodes.Find(x, true);
            newN[0].Nodes.Add(new TreeNode { Name = x2, Text = x2 });

            if (rb_node.Left != null)
            {

                sub(rb_node.Left, ref nodeTV, x2);
            }

            if (rb_node.Right != null)
            {
                sub(rb_node.Right, ref nodeTV, x2);
            }
        }

        class XY
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        private void button_Direct_search_Click(object sender, EventArgs e)
        {
            if (richTextBox_testSearch.Text == String.Empty)
                return;
            if (textBox_testSearch.Text == String.Empty)
                return;
            List<XY> masIndex = new List<XY>();
            Substring_search search = new Substring_search();
            
            string text = richTextBox_testSearch.Text.ToLower();
            string word = textBox_testSearch.Text.ToLower();

            richTextBox_testSearch.Select(0, text.Length);
            richTextBox_testSearch.SelectionBackColor = Color.White;

            int w_len = word.Length;
            int t = search.Direct_Search(text, word);
            int t1 = 0;

            XY xy = new XY();

            xy.X = t;
            xy.Y = t + w_len;
            masIndex.Add(xy);
            
            while (true)
            {
                xy = new XY();
                t1 = t;
                if (t1 + w_len >= text.Length - 1)
                    break;
                t = search.Direct_Search(text, word, t1);
                
                if (t == t1)
                {
                    break;
                }
                xy.X = t;
                xy.Y = t + w_len;
                masIndex.Add(xy);
            }
            foreach(XY xy1 in masIndex)
            {
                richTextBox_testSearch.Select(xy1.X, w_len);
                //richTextBox_testSearch.SelectionColor = Color.Red;
                richTextBox_testSearch.SelectionBackColor = Color.Coral;
            }
        }

        private void button_BM_search_Click(object sender, EventArgs e)
        {
            if (richTextBox_testSearch.Text == String.Empty)
                return;
            if (textBox_testSearch.Text == String.Empty)
                return;
            List<XY> masIndex = new List<XY>();
            Substring_search search = new Substring_search();

            string text = richTextBox_testSearch.Text.ToLower();
            string word = textBox_testSearch.Text.ToLower();

            richTextBox_testSearch.Select(0, text.Length);
            richTextBox_testSearch.SelectionBackColor = Color.White;

            int w_len = word.Length;
            int t = search.BM_Search(text, word);
            int t1 = 0;

            XY xy = new XY();

            xy.X = t;
            xy.Y = t + w_len;
            masIndex.Add(xy);

            while (true)
            {
                xy = new XY();
                t1 = t;
                if (t1 + w_len >= text.Length - 1)
                    break;
                t = search.BM_Search(text, word, t1);

                if (t == t1)
                {
                    break;
                }
                xy.X = t;
                xy.Y = t + w_len;
                masIndex.Add(xy);
            }
            foreach (XY xy1 in masIndex)
            {
                richTextBox_testSearch.Select(xy1.X, w_len);
                //richTextBox_testSearch.SelectionColor = Color.Red;
                richTextBox_testSearch.SelectionBackColor = Color.Green;
            }
        }

        private void startSorting_button_Click(object sender, EventArgs e)
        {
            int[] mas = new int[1000];
            int[] mas2 = new int[5000];
            int[] mas3 = new int[10000];
            Random rnd = new Random((int)DateTime.Now.Ticks);
            for(int i =0; i<1000; i++)
            {
                mas[i] = rnd.Next(-10000, 10000);
            }
            for(int i = 0; i < 5000; i++)
            {
                mas2[i] = rnd.Next(-10000, 10000);
            }
            for (int i = 0; i < 10000; i++)
            {
                mas3[i] = rnd.Next(-10000, 10000);
            }
            suportStartSearchButton(mas, 1);
            suportStartSearchButton(mas2, 2);
            suportStartSearchButton(mas3, 3);


        }
        private void suportStartSearchButton(int[] mas, int index_box)
        {
            Sorting sorting = new Sorting();
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            sorting.Bubble_Sort((int[])mas.Clone());
            stopwatch.Stop();
            if(index_box == 1)
                bubble1.Text = Convert.ToString(stopwatch.Elapsed);
            else if (index_box == 2)
                bubble5.Text = Convert.ToString(stopwatch.Elapsed);
            else if(index_box == 3)
                bubble10.Text = Convert.ToString(stopwatch.Elapsed);

            stopwatch = new Stopwatch();
            stopwatch.Start();
            sorting.Gnome_Sort((int[])mas.Clone());
            stopwatch.Stop();
            if (index_box == 1)
                gnome1.Text = Convert.ToString(stopwatch.Elapsed);
            else if (index_box == 2)
                gnome5.Text = Convert.ToString(stopwatch.Elapsed);
            else if (index_box == 3)
                gnome10.Text = Convert.ToString(stopwatch.Elapsed);

            stopwatch = new Stopwatch();
            stopwatch.Start();
            sorting.Comb_Sort((int[])mas.Clone());
            stopwatch.Stop();
            if (index_box == 1)
                comb1.Text = Convert.ToString(stopwatch.Elapsed);
            else if (index_box == 2)
                comb5.Text = Convert.ToString(stopwatch.Elapsed);
            else if (index_box == 3)
                comb10.Text = Convert.ToString(stopwatch.Elapsed);

            stopwatch = new Stopwatch();
            stopwatch.Start();
            sorting.Insert_Sort((int[])mas.Clone());
            stopwatch.Stop();
            if (index_box == 1)
                insert1.Text = Convert.ToString(stopwatch.Elapsed);
            else if (index_box == 2)
                insert5.Text = Convert.ToString(stopwatch.Elapsed);
            else if (index_box == 3)
                insert10.Text = Convert.ToString(stopwatch.Elapsed);

            stopwatch = new Stopwatch();
            stopwatch.Start();
            sorting.Shell_Sort((int[])mas.Clone());
            stopwatch.Stop();
            if (index_box == 1)
                shell1.Text = Convert.ToString(stopwatch.Elapsed);
            else if (index_box == 2)
                shell5.Text = Convert.ToString(stopwatch.Elapsed);
            else if (index_box == 3)
                shell10.Text = Convert.ToString(stopwatch.Elapsed);

            stopwatch = new Stopwatch();
            stopwatch.Start();
            sorting.Tree_Sort((int[])mas.Clone());
            stopwatch.Stop();
            if (index_box == 1)
                tree1.Text = Convert.ToString(stopwatch.Elapsed);
            else if (index_box == 2)
                tree5.Text = Convert.ToString(stopwatch.Elapsed);
            else if (index_box == 3)
                tree10.Text = Convert.ToString(stopwatch.Elapsed);

            stopwatch = new Stopwatch();
            stopwatch.Start();
            sorting.Selection_Sort((int[])mas.Clone());
            stopwatch.Stop();
            if (index_box == 1)
                selection1.Text = Convert.ToString(stopwatch.Elapsed);
            else if (index_box == 2)
                selection5.Text = Convert.ToString(stopwatch.Elapsed);
            else if (index_box == 3)
                selection10.Text = Convert.ToString(stopwatch.Elapsed);

            stopwatch = new Stopwatch();
            stopwatch.Start();
            sorting.Heap_Sort((int[])mas.Clone());
            stopwatch.Stop();
            if (index_box == 1)
                heap1.Text = Convert.ToString(stopwatch.Elapsed);
            else if (index_box == 2)
                heap5.Text = Convert.ToString(stopwatch.Elapsed);
            else if (index_box == 3)
                heap10.Text = Convert.ToString(stopwatch.Elapsed);

            stopwatch = new Stopwatch();
            stopwatch.Start();
            sorting.Shaker_Sort((int[])mas.Clone());
            stopwatch.Stop();
            if (index_box == 1)
                shaker1.Text = Convert.ToString(stopwatch.Elapsed);
            else if (index_box == 2)
                shaker5.Text = Convert.ToString(stopwatch.Elapsed);
            else if (index_box == 3)
                shaker10.Text = Convert.ToString(stopwatch.Elapsed);

            stopwatch = new Stopwatch();
            stopwatch.Start();
            sorting.Quick_Sort((int[])mas.Clone(), 0, mas.Length-1);
            stopwatch.Stop();
            if (index_box == 1)
                quick1.Text = Convert.ToString(stopwatch.Elapsed);
            else if (index_box == 2)
                quick5.Text = Convert.ToString(stopwatch.Elapsed);
            else if (index_box == 3)
                quick10.Text = Convert.ToString(stopwatch.Elapsed);

            stopwatch = new Stopwatch();
            stopwatch.Start();
            sorting.Radix_LSD_sort(mas);
            stopwatch.Stop();
            if (index_box == 1)
                radixLSD1.Text = Convert.ToString(stopwatch.Elapsed);
            else if (index_box == 2)
                radixLSD5.Text = Convert.ToString(stopwatch.Elapsed);
            else if (index_box == 3)
                radixLSD10.Text = Convert.ToString(stopwatch.Elapsed);


        }

        private void arithmeticStart_button_Click(object sender, EventArgs e)
        {
            /*
            ArithmCompression compression = new ArithmCompression();
            compression.BuildItems(text);
            List<Item> iii = compression.GetNodesFull(text);
            double d = compression.Encode(iii, text);
            Console.WriteLine(compression.Decode(iii, d));
            */
            Compresion.ArithmCompression compression = new Compresion.ArithmCompression();
            compression.BuildItems(Arithmetic_textBox2.Text);
            List<Compresion.Item> iii = compression.GetNodesFull(Arithmetic_textBox2.Text);
            double d = compression.Encode(iii, Arithmetic_textBox2.Text);
            MessageBox.Show(d.ToString(), "Encode word");
            Arithmetic_textBox3.Text = compression.Decode(iii, d);
        }

        private void huffmanStart_button_Click(object sender, EventArgs e)
        {
            
            Compresion.Huffman huffman = new Compresion.Huffman(Huffman_textBox2.Text);
            huffman.Encode();
            huffman.Print_OriginBinCode();
            huffman.Print_CompresedCode();
            Huffman_textBox3.Text = huffman.Decode();
        }
    }
}
