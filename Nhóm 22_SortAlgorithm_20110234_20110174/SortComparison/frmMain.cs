using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;

namespace SortComparison
{
    public partial class frmMain : Form
    {
        ArrayList array1;
        ArrayList array2;
        ArrayList array3;

        static Random rand = new Random();

        Thread thread1;
        Thread thread2;
        Thread thread3;

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboAlg1.SelectedIndex = cboAlg1.Items.IndexOf("Bubble Sort");
            cboAlg2.SelectedIndex = cboAlg2.Items.IndexOf("Insertion Sort");
            cboAlg3.SelectedIndex = cboAlg3.Items.IndexOf("Quicksort");
            bxorder.SelectedIndex = bxorder.Items.IndexOf("Increase");
            tbSamples.Value = 100;
        }

        public void Randomize(IList list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int swapIndex = rand.Next(i + 1);
                if (swapIndex != i)
                {
                    object tmp = list[swapIndex];
                    list[swapIndex] = list[i];
                    list[i] = tmp;
                }
            }
        }

        private void PrepareForSort()
        {
            array1 = new ArrayList(tbSamples.Value);
            array2 = new ArrayList(tbSamples.Value);
            array3 = new ArrayList(tbSamples.Value);

            for (int i = 0; i < array1.Capacity; i++)
            {
                int y = (int)((double)(i + 1) / array1.Capacity * pnlSort1.Height);
                array1.Add(y);
            }
            Randomize(array1);

            array2 = (ArrayList)array1.Clone();
            array3 = (ArrayList)array1.Clone();
        }

        private void cmdSort_Click(object sender, EventArgs e)
        {
            // prevent a bogus "Sort #1 failed!" message
            if (thread1 != null)
            {
                thread1.Abort();
                thread1.Join();
            }
            if (thread2 != null)
            {
                thread2.Abort();
                thread2.Join();
            }

            if (thread3 != null)
            {
                thread3.Abort();
                thread3.Join();
            }

            PrepareForSort();
            int speed = 1;
            for (int i = 0; i < tbSpeed.Value; i++)
            {
                speed *= 2; //speed=speed*2^n (n is tbSpeed.Value)
            }

            string alg1="";
            string alg2="";
            string alg3 ="";

            if(cboAlg1.SelectedItem!=null)
                alg1 = cboAlg1.SelectedItem.ToString();

            if(cboAlg2.SelectedItem!=null)
                alg2 = cboAlg2.SelectedItem.ToString();

            if (cboAlg3.SelectedItem != null)
                alg3 = cboAlg3.SelectedItem.ToString();

            SortAlgorithm sa = new SortAlgorithm(array1, pnlSort1, speed, alg1);
            SortAlgorithm sa2 = new SortAlgorithm(array2, pnlSort2, speed, alg2);
            SortAlgorithm sa3 = new SortAlgorithm(array3, pnlSort3, speed, alg3);
            string check = bxorder.Text;
            ThreadStart ts = delegate()
            {
                switch (alg1)
                {
                    case "Bubble Sort":
                        sa.BubbleSort(array1, check);
                        break;
                    //case "Counting Sort":
                    //    sa.CountingSort(array1, check);
                    //    break;
                    case "Insertion Sort":
                        sa.InsertionSort(array1, check);
                        break;
                    case "Quicksort":
                        sa.Quicksort(array1, 0, array1.Count - 1, check);
                        break;
                    //case "Selection Sort":
                    //    sa.SelectionSort(array1, check);
                    //    break;
                    //case "Shell Sort":
                    //    sa.ShellSort(array1, check);
                    //    break;
                }

                sa.finishDrawing();
                if (!isSorted(array1, check))
                    MessageBox.Show("#1 Sort Failed!");
            };

            ThreadStart ts2 = delegate()
            {
                switch (alg2)
                {
                    case "Bubble Sort":
                        sa2.BubbleSort(array2, check);
                        break;
                    //case "Counting Sort":
                    //    sa2.CountingSort(array2, check);
                    //    break;
                    case "Insertion Sort":
                        sa2.InsertionSort(array2, check);
                        break;
                    case "Quicksort":
                        sa2.Quicksort(array2, 0, array2.Count - 1, check);
                        break;
                    //case "Selection Sort":
                    //    sa2.SelectionSort(array2, check);
                    //    break;
                    //case "Shell Sort":
                    //    sa2.ShellSort(array2, check);
                    //    break;
                }

                sa2.finishDrawing();
                if (!isSorted(array2, check))
                    MessageBox.Show("#2 Sort Failed!");
            };

            ThreadStart ts3 = delegate()
            {
                switch (alg3)
                {
                    case "Bubble Sort":
                        sa3.BubbleSort(array3, check);
                        break;
                    //case "Counting Sort":
                    //    sa3.CountingSort(array3, check);
                    //    break;
                    case "Insertion Sort":
                        sa3.InsertionSort(array3, check);
                        break;
                   
                    case "Quicksort":
                        IList list = sa3.Quicksort(array3, 0, array3.Count - 1, check);
                        break;
                    //case "Selection Sort":
                    //    sa3.SelectionSort(array3, check);
                    //    break;
                    //case "Shell Sort":
                    //    sa3.ShellSort(array3, check);
                    //    break;
                }

                sa3.finishDrawing();
                if (!isSorted(array3, check))
                    MessageBox.Show("#3 Sort Failed!");
            };

            if (alg1 != "")
            {
                thread1 = new Thread(ts);
                thread1.Start();
            }
            if (alg2 != "")
            {
                thread2 = new Thread(ts2);
                thread2.Start();
            }
            if (alg3 != "")
            {
                thread3 = new Thread(ts3);
                thread3.Start();
            }
        }

        private bool isSorted(IList checkThis, string order)
        {
            for (int i = 0; i < checkThis.Count - 1; i++)
            {
                if (order == "Increase")
                {
                    if (((IComparable)checkThis[i]).CompareTo(checkThis[i + 1]) > 0)
                        return false;
                }
                else
                {
                    if (((IComparable)checkThis[i]).CompareTo(checkThis[i + 1]) < 0)
                        return false;
                }
            }

            return true;
        }

        private void tbSamples_Scroll(object sender, EventArgs e)
        {
            lblSamples.Text = "Samples: " + tbSamples.Value.ToString("n0");
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void tbSpeed_Scroll(object sender, EventArgs e)
        {

        }

        private void lblSamples_Click(object sender, EventArgs e)
        {

        }

        private void bxorder_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
