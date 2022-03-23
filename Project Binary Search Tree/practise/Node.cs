using System;
using System.Drawing;
using System.Windows.Forms;

namespace practise
{
    public class Node
    {
        #region Fields

        int data; // giá trị của node đang giữ
        Node left; // con bên trái của node
        Node right; // con bên phải của node
        Node parent; // cha của node
        bool isLeftChild; // biến kiểm tra node là con bên trái hay phải của node cha
        TextBox box; // nơi biểu diễn giá trị của node

        #endregion

        #region Constructor

        // Khởi tạo một đối tượng có data là value được truyền vào
        public Node(int value)
        {
            // Chủ yếu
            data = value;
            left = null;
            right = null;

            // Hỗ trợ demo
            isLeftChild = false;
            parent = null;

            // Xây dựng 1 số thuộc tính cho Box
            Box = new TextBox();
            Box.Size = new Size(60, 22);
            Box.Text = value.ToString();
            Box.ReadOnly = true;
            Box.TextAlign = HorizontalAlignment.Center;
        }

        public Node() { }

        #endregion

        #region Properties

        public int Data
        {
            get { return data; }
            set { data = value; }
        }

        public Node Left
        {
            get { return left; }
            set { left = value; }
        }

        public Node Right
        {
            get { return right; }
            set { right = value; }
        }

        public bool IsLeftChild
        {
            get { return isLeftChild; }
            set { isLeftChild = value; }
        }

        public Node Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public TextBox Box
        {
            get { return box; }
            set { box = value; }
        }

        #endregion

        #region Methods

        // Trả về số cha của node hiện tại (phục vụ cho việc biểu diễn các TextBox)
        private int GetNumberOfParent()
        {
            int count = 0;
            Node temp = this;
            while (temp.parent != null)
            {
                count++;
                temp = temp.parent;
            }
            return count;
        }

        // Cho biết node hiện tại có nằm bên trái của Root không (phục vụ cho việc biểu diễn các TextBox)
        public bool isLeftOfRoot()
        {
            Node tempNode = this;
            while (tempNode.Parent.Parent != null)
            {
                tempNode = tempNode.Parent;
            }
            return tempNode.isLeftChild;
        }

        // Chèn một node
        public void Insert(Node nodeInsert)
        {
            if (nodeInsert.Data == this.Data) // giá trị cần chèn đã có trong cây
                throw new Exception();
            if (nodeInsert.data > this.data) // nếu giá trị cần chèn lớn hơn node đang xét thì chèn bên phải
            {
                if (this.Right == null) // nếu node con bên phải chưa tồn tại
                {
                    this.Right = nodeInsert;
                    Right.isLeftChild = false;
                    Right.parent = this;

                    #region Thiết lập vị trí cho Box của node vừa chèn
                    if (Right.GetNumberOfParent() == 1)
                        Right.Box.Location = new Point(Right.parent.Box.Location.X + (800 - Right.parent.Box.Location.X) / 2, Right.parent.Box.Location.Y + 50);
                    else if (Right.GetNumberOfParent() == 2)
                    {
                        if (Right.isLeftOfRoot() == false)
                        {
                            Right.Box.Location = new Point(Right.parent.Box.Location.X + (800 - Right.parent.Box.Location.X) / 2, Right.parent.Box.Location.Y + 50);
                        }
                        else
                        {
                            Right.Box.Location = new Point(Right.parent.Box.Location.X + (Right.parent.parent.Box.Location.X - Right.Parent.Box.Location.X) / 2, Right.parent.Box.Location.Y + 50);
                        }
                    }
                    else if (Right.GetNumberOfParent() == 3)
                    {
                        if (Right.isLeftOfRoot() == false)
                        {
                            if (Right.Parent.IsLeftChild == false)
                            {
                                Right.Box.Location = new Point(Right.parent.Box.Location.X + (800 - Right.parent.Box.Location.X) / 2, Right.parent.Box.Location.Y + 50);
                            }
                            else
                            {
                                Right.Box.Location = new Point(Right.parent.Box.Location.X + (Right.parent.parent.Box.Location.X - Right.Parent.Box.Location.X) / 2, Right.parent.Box.Location.Y + 50);
                            }
                        }
                        else
                        {
                            if (Right.Parent.isLeftChild == true)
                            {
                                Right.Box.Location = new Point(Right.parent.Box.Location.X + (Right.parent.parent.Box.Location.X - Right.Parent.Box.Location.X) / 2, Right.parent.Box.Location.Y + 50);
                            }
                            else
                            {
                                Right.Box.Location = new Point(Right.parent.Box.Location.X + (Right.parent.parent.parent.Box.Location.X - Right.Parent.Box.Location.X) / 2, Right.parent.Box.Location.Y + 50);
                            }
                        }
                    }
                    #endregion 
                }
                else // nếu node con bên phải đã tồn tại.
                {
                    Right.Insert(nodeInsert);
                }
            }
            else // nếu giá trị cần chèn nhỏ hơn node đang xét thì chèn bên trái
            {
                if (this.left == null) // nếu node con bên trái chưa tồn tại
                {
                    this.left = nodeInsert;
                    Left.IsLeftChild = true;
                    Left.Parent = this;

                    #region Thiết lập vị trí cho Box của node vừa chèn
                    if (Left.GetNumberOfParent() == 1)
                        Left.Box.Location = new Point(Left.parent.Box.Location.X / 2, Left.parent.Box.Location.Y + 50);
                    else if (Left.GetNumberOfParent() == 2)
                    {
                        if (Left.isLeftOfRoot() == false)
                        {
                            Left.Box.Location = new Point(Left.parent.parent.Box.Location.X + (Left.parent.Box.Location.X - Left.parent.parent.Box.Location.X) / 2, Left.parent.Box.Location.Y + 50);
                        }
                        else // needed
                        {
                            Left.Box.Location = new Point(Left.parent.Box.Location.X / 2, Left.parent.Box.Location.Y + 50);
                        }
                    }
                    else if (Left.GetNumberOfParent() == 3)
                    {
                        if (Left.isLeftOfRoot() == false)
                        {
                            if (Left.Parent.IsLeftChild == false)
                            {
                                Left.Box.Location = new Point(Left.parent.parent.Box.Location.X + (Left.parent.Box.Location.X - Left.parent.parent.Box.Location.X) / 2, Left.parent.Box.Location.Y + 50);
                            }
                            else
                            {
                                Left.Box.Location = new Point(Left.parent.parent.parent.Box.Location.X + (Left.parent.Box.Location.X - Left.parent.parent.Parent.Box.Location.X) / 2, Left.parent.Box.Location.Y + 50);
                            }
                        }
                        else // needed
                        {
                            if (Left.Parent.isLeftChild == true)
                            {
                                Left.Box.Location = new Point(Left.parent.Box.Location.X / 2, Left.parent.Box.Location.Y + 50);
                            }
                            else
                            {
                                Left.Box.Location = new Point(Left.parent.parent.Box.Location.X + (Left.parent.Box.Location.X - Left.Parent.parent.Box.Location.X) / 2, Left.parent.Box.Location.Y + 50);
                            }
                        }
                    }
                    #endregion
                }
                else // nếu node con bên trái đã tồn tại.
                {
                    left.Insert(nodeInsert);
                }
            }

        }

        // Tìm node có giá trị là value
        public Node Find(int value)
        {
            Node current = this;

            while (current != null)
            {
                if (current.data == value)
                    return current;
                else if (value >= current.data)
                {
                    if (current.Right != null)
                        current = current.Right;
                    else
                        break;
                }
                else
                {
                    if (current.Left != null)
                        current = current.Left;
                    else
                        break;
                }

            }
            return null; //Tìm không thấy node cần tìm
        }

        // Biểu diễn các node theo một mảng tăng dần
        public string Display()
        {
            string Output = "";
            if (this.Left != null)
            {
                Output = Output + Left.Display();
            }
            Output += data.ToString() + " ";
            if (this.Right != null)
            {
                Output = Output + Right.Display();
            }
            return Output;
        }

        // Thiết lập vị trí phù hợp của Box
        public void Review()
        {
            if (this.Parent == null) // là node gốc (root)
            {
                this.Box.Location = new Point(365, 110);
                this.Box.Text = this.Data.ToString();
                this.Box.Visible = true;
            }
            else
            {
                if (this.GetNumberOfParent() == 1)
                {
                    if (this.isLeftChild == false)
                    {
                        this.Box.Location = new Point(this.parent.Box.Location.X + (800 - this.parent.Box.Location.X) / 2, this.parent.Box.Location.Y + 50);
                    }
                    else
                    {
                        this.Box.Location = new Point(this.parent.Box.Location.X / 2, this.parent.Box.Location.Y + 50);
                    }
                }
                else if (this.GetNumberOfParent() == 2)
                {
                    if (this.isLeftOfRoot() == false)
                    {
                        if (this.IsLeftChild == false)
                        {
                            this.Box.Location = new Point(this.parent.Box.Location.X + (800 - this.parent.Box.Location.X) / 2, this.parent.Box.Location.Y + 50);
                        }
                        else
                        {
                            this.Box.Location = new Point(this.parent.parent.Box.Location.X + (this.parent.Box.Location.X - this.parent.parent.Box.Location.X) / 2, this.parent.Box.Location.Y + 50);
                        }
                    }
                    else
                    {
                        if (this.IsLeftChild == false)
                        {
                            this.Box.Location = new Point(this.parent.Box.Location.X + (this.parent.parent.Box.Location.X - this.Parent.Box.Location.X) / 2, this.parent.Box.Location.Y + 50);
                        }
                        else
                        {
                            this.Box.Location = new Point(this.parent.Box.Location.X / 2, this.parent.Box.Location.Y + 50);
                        }
                    }
                }
                else if (this.GetNumberOfParent() == 3)
                {
                    if (this.isLeftOfRoot() == false)
                    {
                        if (this.IsLeftChild == false)
                        {
                            if (this.Parent.IsLeftChild == false)
                            {
                                this.Box.Location = new Point(this.parent.Box.Location.X + (800 - this.parent.Box.Location.X) / 2, this.parent.Box.Location.Y + 50);
                            }
                            else
                            {
                                this.Box.Location = new Point(this.parent.Box.Location.X + (this.parent.parent.Box.Location.X - this.Parent.Box.Location.X) / 2, this.parent.Box.Location.Y + 50);
                            }
                        }
                        else
                        {
                            if (this.Parent.isLeftChild == false)
                            {
                                this.Box.Location = new Point(this.parent.parent.Box.Location.X + (this.parent.Box.Location.X - this.parent.parent.Box.Location.X) / 2, this.parent.Box.Location.Y + 50);
                            }
                            else
                            {
                                this.Box.Location = new Point(this.parent.parent.parent.Box.Location.X + (this.parent.Box.Location.X - this.parent.parent.Parent.Box.Location.X) / 2, this.parent.Box.Location.Y + 50);
                            }
                        }
                    }
                    else
                    {
                        if (this.IsLeftChild == false)
                        {
                            if (this.Parent.IsLeftChild == false)
                            {
                                this.Box.Location = new Point(this.parent.Box.Location.X + (this.parent.parent.parent.Box.Location.X - this.Parent.Box.Location.X) / 2, this.parent.Box.Location.Y + 50);
                            }
                            else
                            {
                                this.Box.Location = new Point(this.parent.Box.Location.X + (this.parent.parent.Box.Location.X - this.Parent.Box.Location.X) / 2, this.parent.Box.Location.Y + 50);
                            }
                        }
                        else
                        {
                            if (this.Parent.isLeftChild == false)
                            {
                                this.Box.Location = new Point(this.parent.parent.Box.Location.X + (this.parent.Box.Location.X - this.Parent.parent.Box.Location.X) / 2, this.parent.Box.Location.Y + 50);
                            }
                            else
                            {
                                this.Box.Location = new Point(this.parent.Box.Location.X / 2, this.parent.Box.Location.Y + 50);
                            }
                        }
                    }
                }
                this.Box.Text = this.Data.ToString();
                this.Box.Visible = true;

            }
        }

        // Biểu diễn lại cây khi có sự thay đổi
        public void Show()
        {
            if (this == null)
                return;
            else
            {
                this.Review();
                if (this.Left != null)
                    this.Left.Show();
                if (this.Right != null)
                    this.Right.Show();
            }
        }

        // Trả về giá trị lớn nhất của cây có root là node hiện tại
        public Node GetMax()
        {
            Node current = this;
            if (current.Right == null)
            {
                return current;
            }
            else
            {
                return current.Right.GetMax();
            }
        }

        // Trả về giá trị nhỏ nhất của cây có root là node hiện tại
        public Node GetMin()
        {
            Node current = this;
            if (current.Left == null)
            {
                return current;
            }
            else
            {
                return current.Left.GetMin();
            }
        }

        //Thực hiện xóa cây có root là node hiện tại
        public void Reset()
        {
            if (this == null)
                return;
            else
            {
                this.Box.Visible = false;
                if (this.Left != null)
                    this.Left.Reset();
                if (this.Right != null)
                    this.Right.Reset();
            }
        }

        #endregion
    }
}
