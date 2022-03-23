// Original version by Kanasz Robert: http://www.codeproject.com/Articles/132757/Visualization-and-Comparison-of-sorting-algorithms
// This version by Mark Kent Monnin
//      Changes:
//          Added Counting Sort, MergeSortDoubleStorage, Radix Sort, Smoothsort, and Timsort (though bugged)
//          Changed Quicksort with Bubble Sort to Quicksort with Insertion Sort
//          Removed Bucket Sort, since the code matched Pigeonhole Sort
//          Changed the visualization to highlight what is being compared and changed
//          Changed the visualization to display wider bars if there's room
//          Changed the visualization system to run on operations per second rather than sleeping after every operation
//          Changed the visualization to allow larger images
//          Extended the maximum samples from 100 to 1000
//          Changed the speed slider to logarithmic scale so one bump up doubles the speed
//          Changed the animation creation to delete the individual images after creation
//          Added different data set types: Reversed, Sorted, Nearly Sorted, Few Unique
//          Changed the threading so they stop if the user starts over (and therefore no bogus failure message is displayed)
//          Added check to notify if the sort fails

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Threading;

namespace SortComparison
{
    public class SortAlgorithm
    {
        ArrayList arrayToSort;
        Graphics g;
        Bitmap bmpsave;
        PictureBox pnlSamples;
        string outputFile;
        int operationsPerFrame; // operations per frame
        int frameMS; // time between frames (aim for 40 ms = 25 fps)
        int operationCount;
        Dictionary<int, bool> highlightedIndexes = new Dictionary<int, bool>(); // highlight all of these indexes in the frame
        DateTime nextFrameTime;
        int originalPanelHeight;

        Random rand = new Random();

        public SortAlgorithm(ArrayList list, PictureBox pic, int s, string outFile)
        {
            //imgCount = 0;
            arrayToSort = list; //luu danh sach
            pnlSamples = pic; //luu kich co khung ve 
     

            operationCount = 0;//
            operationsPerFrame = s;
            frameMS = 1000; // so now operationsPerFrame is operations per second

            // reduce the frame wait for better visuals (increased frame rate)
            while (frameMS >= 40 && operationsPerFrame > 1)
            {
                operationsPerFrame = operationsPerFrame / 2;
                frameMS = frameMS / 2;
            }

            bmpsave = new Bitmap(pnlSamples.Width, pnlSamples.Height);
            g = Graphics.FromImage(bmpsave);
            originalPanelHeight = pnlSamples.Height;
            pnlSamples.Image = bmpsave;
            nextFrameTime = DateTime.UtcNow;

            checkForFrame();
        }

        // simple to program, but really terrible in performance
        public IList BubbleSort(IList arrayToSort, string order)
        {
            bool swapMade = true;
            int n = arrayToSort.Count - 1;
            for (int i = 0; i < n && swapMade; i++)
            {
                swapMade = false;

                for (int j = n; j > i; j--)
                {
                    if (order == "Increase")
                    {
                        if (CompareItems(arrayToSort, j - 1, j) > 0)
                        {
                            SwapItems(arrayToSort, j - 1, j);
                            swapMade = true;
                        }
                    }
                    else
                    {
                        if (CompareItems(arrayToSort, j - 1, j) < 0)
                        {
                            SwapItems(arrayToSort, j - 1, j);
                            swapMade = true;
                        }
                    }
                }
            }

            return arrayToSort;
        }
        // super-fast, but it requires the data to have a small amount of variation (ideally n or less)
        
        public IList InsertionSort(IList arrayToSort, string order)
        {
            for (int i = 1; i < arrayToSort.Count; i++)
            {
                object val = null;
                SetItem(arrayToSort, ref val, i); //luu vi tri i hien tai vao val
                int j = i - 1;
                bool done = false;

                do
                {
                    if (order == "Increase")
                    {
                        if (CompareItems(arrayToSort, j, val) > 0)
                        {
                            SetItem(arrayToSort, j + 1, j); //trao vi tri
                            //arrayToSort[j] = val; // in practice, we do not assign here! wait until after the loop! (this is for visuals)

                            j--;
                            if (j < 0)
                            {
                                done = true; //sau vi tri i khong con phan tu nao chua xet
                            }
                        }
                        else
                        {
                            done = true; //sau vi tri i khong con phan tu nao chua xet
                        }
                    }
                    else
                    {
                        if (CompareItems(arrayToSort, j, val) < 0)
                        {
                            SetItem(arrayToSort, j + 1, j); //trao vi tri
                            //arrayToSort[j] = val; // in practice, we do not assign here! wait until after the loop! (this is for visuals)

                            j--;
                            if (j < 0)
                            {
                                done = true;
                            }
                        }
                        else
                        {
                            done = true; //sau vi tri i khong con phan tu nao chua xet
                        }
                    }
                } while (!done); //thuc hien do khi done=false

                SetItem(arrayToSort, j + 1, val);
            }

            return arrayToSort;
        }
        // a fast sort with log2(n) extra storage
        public IList Quicksort(IList a, int left, int right, string order)
        {
            int i = left;
            int j = right;
            object x = null;
            SetItem(a, ref x, rand.Next(left, right + 1));//lay mot gia tri bat ki giưa index trai và phải để lư vô x

            // find items to swap so smaller items are on the left side and larger items are on the right side
            while (i <= j) // when i=j, need to compare to know which way to move (left or right)
            {
                if (order == "Increase")
                {
                    while (CompareItems(a, i, x) < 0)
                    {
                        i++;
                    }
                    while (CompareItems(a, x, j) < 0)
                    {
                        j--;
                    }
                }
                else
                {
                    while (CompareItems(a, i, x) > 0)
                    {
                        i++;
                    }
                    while (CompareItems(a, x, j) > 0)
                    {
                        j--;
                    }
                }
                if (i < j)
                {
                    SwapItems(a, i, j);
                    i++;
                    j--;
                }
                else if (i == j) // no need to swap in this case
                {
                    i++;
                    j--;
                }
            }

            // now everything from left to j is less than or equal to the pivot
            // and everything from i to right is greater than or equal to the pivot
            // note that we don't need to push the pivot in between these partitions to be fast
                if (left < j)
                {
                    Quicksort(a, left, j, order);
                }
                if (i < right)
                {
                    Quicksort(a, i, right, order);
                }
            return a;
        }
       
        private object GetItem(IList arrayToSort, int index)
        {
            if (!highlightedIndexes.ContainsKey(index))
                highlightedIndexes.Add(index, false);

            operationCount++;
            checkForFrame();

            return arrayToSort[index];
        }
        private void SetItem(IList arrayToSort, int toIndex, int fromIndex)
        {
            arrayToSort[toIndex] = arrayToSort[fromIndex];

            if (!highlightedIndexes.ContainsKey(toIndex))
                highlightedIndexes.Add(toIndex, false);

            operationCount++;
            checkForFrame();
        }
        private void SetItem(IList arrayToSort, int toIndex, object fromObject)
        {
            arrayToSort[toIndex] = fromObject;

            if (!highlightedIndexes.ContainsKey(toIndex))
                highlightedIndexes.Add(toIndex, false);

            operationCount++;
            checkForFrame();
        }
        private void SetItem(IList arrayToSort, ref object toObject, int fromIndex)
        {
            toObject = arrayToSort[fromIndex];

            if (!highlightedIndexes.ContainsKey(fromIndex))
                highlightedIndexes.Add(fromIndex, false);

            operationCount++;
            checkForFrame();
        }
        private void SwapItems(IList arrayToSort, int index1, int index2)
        {
            object temp = arrayToSort[index1];
            arrayToSort[index1] = arrayToSort[index2];
            arrayToSort[index2] = temp;

            if (!highlightedIndexes.ContainsKey(index1))
                highlightedIndexes.Add(index1, false);
            if (!highlightedIndexes.ContainsKey(index2))
                highlightedIndexes.Add(index2, false);

            operationCount += 2;
            checkForFrame();
        }
        private int CompareItems(IList arrayToSort, int index1, int index2)
        {
            if (!highlightedIndexes.ContainsKey(index1))
                highlightedIndexes.Add(index1, false);
            if (!highlightedIndexes.ContainsKey(index2))
                highlightedIndexes.Add(index2, false);

            operationCount++;
            checkForFrame();

            return ((IComparable)arrayToSort[index1]).CompareTo(arrayToSort[index2]);
        }
        private int CompareItems(IList arrayToSort, int index1, object o)
        {
            if (!highlightedIndexes.ContainsKey(index1))
                highlightedIndexes.Add(index1, false);

            operationCount++;
            checkForFrame();

            return ((IComparable)arrayToSort[index1]).CompareTo(o);
        }
        private int CompareItems(IList arrayToSort, object o, int index1)
        {
            if (!highlightedIndexes.ContainsKey(index1))
                highlightedIndexes.Add(index1, false);

            operationCount++;
            checkForFrame();

            return ((IComparable)o).CompareTo(arrayToSort[index1]);
        }

        private void checkForFrame()
        {
            if (operationCount >= operationsPerFrame || nextFrameTime <= DateTime.UtcNow)
            {
                // time to draw a new frame and wait
                DrawSamples();
                RefreshPanel(pnlSamples);
                //if (savePicture)
                //    SavePicture();

                // prepare for next frame
                highlightedIndexes.Clear();
                operationCount -= operationsPerFrame; // if there were more operations than needed, don't just forget those

                if (DateTime.UtcNow < nextFrameTime)
                {
                    Thread.Sleep((int)((nextFrameTime - DateTime.UtcNow).TotalMilliseconds));
                }
                nextFrameTime = nextFrameTime.AddMilliseconds(frameMS);
            }
        }

        public void finishDrawing()
        {
            if (highlightedIndexes.Count > 0)
            {
                // put one last frame in before the end
                nextFrameTime = DateTime.UtcNow;
                checkForFrame();
            }

            // draw the last frame
            nextFrameTime = DateTime.UtcNow;
            checkForFrame();
        }

        delegate void SetControlValueCallback(Control pnlSort);

        private void RefreshPanel(Control pnlSort)
        {
            if (pnlSort.InvokeRequired)
            {
                SetControlValueCallback d = new SetControlValueCallback(RefreshPanel);
                pnlSort.Invoke(d, new object[] { pnlSort });
            }
            else
            {
                pnlSort.Refresh();
            }
        }

        public void DrawSamples()
        {
            // might need to grow or shrink if size is different from original (can't change array!)
            double multiplyHeight = 1;

            // check if need to change size
            if (bmpsave.Width != pnlSamples.Width || bmpsave.Height != pnlSamples.Height)
            {
                bmpsave = new Bitmap(pnlSamples.Width, pnlSamples.Height);
                g = Graphics.FromImage(bmpsave);
                pnlSamples.Image = bmpsave;
            }

            if (pnlSamples.Height != originalPanelHeight)
            {
                multiplyHeight = (double)(pnlSamples.Height) / (double)(originalPanelHeight);
            }

            // start with white background
            g.Clear(Color.White);

            // use black sometimes
            Pen pen = new Pen(Color.Black);
            SolidBrush b = new SolidBrush(Color.Black);

            // use red sometimes
            Pen redPen = new Pen(Color.Red);
            SolidBrush redBrush = new SolidBrush(Color.Red);

            // draw a nice width based on number of elements
            int w = (pnlSamples.Width / arrayToSort.Count) - 1;

            for (int i = 0; i < this.arrayToSort.Count; i++)
            {
                int x = (int)(((double)pnlSamples.Width / arrayToSort.Count) * i);

                int itemHeight = (int)Math.Round(Convert.ToDouble(arrayToSort[i]) * multiplyHeight);

                // draw highlighed versions
                if (highlightedIndexes.ContainsKey(i))
                {
                    if (w <= 1)
                    {
                        g.DrawLine(redPen, new Point(x, pnlSamples.Height), new Point(x, (int)(pnlSamples.Height - itemHeight)));
                    }
                    else
                    {
                        g.FillRectangle(redBrush, x, pnlSamples.Height - itemHeight, w, pnlSamples.Height);
                    }
                }
                else // draw normal versions
                {
                    if (w <= 1)
                    {
                        g.DrawLine(pen, new Point(x, pnlSamples.Height), new Point(x, (int)(pnlSamples.Height - itemHeight)));
                    }
                    else
                    {
                        g.FillRectangle(b, x, pnlSamples.Height - itemHeight, w, pnlSamples.Height);
                    }
                }
            }
        }
    }
}
