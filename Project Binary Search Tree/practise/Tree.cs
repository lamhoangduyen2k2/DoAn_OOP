using System;
using System.Drawing;
using System.Windows.Forms;

namespace practise
{
    public class Tree
    {
        #region Fields
        Node root; // Gốc của một cây
        #endregion

        #region Constructor
        public Tree()
        {
            root = null;
        }
        #endregion

        #region Properties
        public Node Root
        {
            get { return root; }
            set { root = value; }
        }
        #endregion

        #region Methods
        // Chèn một node vào cây 
        public void Insert(Node nodeInsert)
        {
            if (this.root == null)
            {
                this.root = nodeInsert;
                root.Box.Location = new Point(365, 110);
                root.Box.Size = new Size(60, 22);
                root.Box.Text = nodeInsert.Data.ToString();
                root.Box.TextAlign = HorizontalAlignment.Center;
                root.Box.ReadOnly = true;
            }
            else
                root.Insert(nodeInsert);
        }

        // Tìm xem node có tồn tại trên cây không
        public Node Find(int value)
        {
            if (root == null)
            {
                return null;
            }
            else
                return root.Find(value);

        }

        // In thành mảng theo thứ tự tăng dần
        public string Display()
        {
            if (root == null)
                return String.Empty;
            else
            {
                string OutArray;
                OutArray = root.Display();
                return OutArray;
            }
        }

        // Tìm giá trị lớn nhất của cây
        public Node GetMax()
        {
            if (root == null)
                return null;
            else
            {
                return root.GetMax();
            }
        }

        // Tìm giá trị nhỏ nhất của cây
        public Node GetMin()
        {
            if (root == null)
                return null;
            else
            {
                return root.GetMin();
            }
        }

        // Xóa một node trên cây
        public bool Remove(int value)
        {
            Node current = root;
            Node parent = root;
            bool isLeftChild = false;

            if (current == null)
                return false;
            while (current != null && current.Data != value)
            {
                parent = current;
                if (current.Data < value)
                {
                    current = current.Right;
                    isLeftChild = false;
                }
                else
                {
                    current = current.Left;
                    isLeftChild = true;
                }
            }

            if (current == null)
                return false;
            if (current.Left == null && current.Right == null) //no children
            {
                if (current == root)
                {
                    root.Box.Visible = false;
                    root = null;
                }
                else
                {
                    if (isLeftChild == true)
                    {
                        parent.Left.Box.Visible = false;
                        parent.Left = null;
                    }
                    else
                    {
                        parent.Right.Box.Visible = false;
                        parent.Right = null;
                    }
                }
            }
            else if (current.Right == null) // has left child
            {
                if (current == root)
                {
                    current.Box.Visible = false;
                    root = current.Left;
                    root.Parent = null;
                    current = null;
                    root.Show();
                }
                else
                {
                    current.Box.Visible = false;
                    if (isLeftChild == true)
                    {
                        parent.Left = current.Left;
                        current.Left.Parent = parent;
                        current = null;
                        parent.Left.Show();
                    }
                    else
                    {
                        parent.Right = current.Left;
                        current.Left.Parent = parent;
                        current.Left.IsLeftChild = false;
                        current = null;
                        parent.Right.Show();
                    }

                }
            }
            else if (current.Left == null) // has right child
            {
                if (current == root)
                {
                    current.Box.Visible = false;
                    root = current.Right;
                    root.Parent = null;
                    current = null;
                    root.Show();
                }
                else
                {
                    current.Box.Visible = false;
                    if (isLeftChild == true)
                    {
                        parent.Left = current.Right;
                        current.Right.Parent = parent;
                        current.Right.IsLeftChild = true;
                        current = null;
                        parent.Left.Show();
                    }
                    else
                    {
                        parent.Right = current.Right;
                        current.Right.Parent = parent;
                        current = null;
                        parent.Right.Show();
                    }
                }
            }
            else // has both two children
            {
                Node successor = GetSuccessor(current);
                if (current == root)
                {
                    current.Box.Visible = false;
                    root = successor;
                    root.Parent = null;
                    current = null;
                    root.Show();
                }
                else if (isLeftChild == true)
                {
                    current.Box.Visible = false;
                    parent.Left = successor;
                    successor.Parent = parent;
                    successor.IsLeftChild = true;
                    successor.Show();
                }
                else
                {
                    current.Box.Visible = false;
                    parent.Right = successor;
                    successor.Parent = parent;
                    successor.IsLeftChild = false;
                    successor.Show();
                }
            }
            return true;
        }

        // Tìm node kế thừa của node bị xóa
        public Node GetSuccessor(Node node)
        {
            Node parent = node;
            Node successor = node;
            Node current = node.Right;

            while (current != null)
            {
                parent = successor;
                successor = current;
                current = current.Left;
            }

            if (successor != node.Right)
            {
                parent.Left = successor.Right;
                successor.Right.Parent = parent;
                successor.Right.IsLeftChild = true;
                successor.Right = node.Right;
                successor.Right.Parent = successor;
            }
            successor.Left = node.Left;
            successor.Left.Parent = successor;
            return successor;
        }

        // Xóa cây
        public void Reset()
        {
            if (root == null)
                return;
            else
            {
                root.Reset();
                root = null;
            }
        }
        #endregion
    }
}
