using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace practise
{
    public partial class Form1 : Form
    {
        Tree myTree = new Tree();
        public static Graphics g;  // Đối tượng graphic dùng để vẽ lên form
        Pen myPen = new Pen(Color.Purple, 1); // dùng để vẽ đường thẳng
        static Image image = new Bitmap(Properties.Resources.bg);
        TextureBrush tBrush = new TextureBrush(image);

        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics(); // khởi tạo đối tượng graphic
            g.SmoothingMode = SmoothingMode.AntiAlias; // tùy chọn smooth cho đường thẳng
        }

        private void Form1_Load(object sender, EventArgs e) { }

        // Hàm vẽ đường nối liền hai điểm p1 p2
        public void DrawShapeLine(Point p1, Point p2)
        {
            Point[] points = { p1, p2 };
            //g.Clear(Color.White);
            g.DrawLines(myPen, points);
        }

        /// <summary>
        /// Vẽ đường thẳng nối liền Node hiện tại và các Node xung quanh 
        /// </summary>
        /// <param name="current">Node hiện tại</param>
        private void DrawEdges(Node current)
        {
            /*if (current.Left != null)
            {
                DrawShapeLine(new Point(current.Box.Location.X, current.Box.Location.Y), new Point(current.Left.Box.Location.X, current.Left.Box.Location.Y));
            }

            if (current.Right != null)
            {
                DrawShapeLine(new Point(current.Box.Location.X, current.Box.Location.Y), new Point(current.Right.Box.Location.X, current.Right.Box.Location.Y));
            }*/

            if (current.Parent != null)
            {
                DrawShapeLine(new Point(current.Box.Location.X+30, current.Box.Location.Y), new Point(current.Parent.Box.Location.X+30, current.Parent.Box.Location.Y+19));
            }
        }

        private void Insertbtn_Click(object sender, EventArgs e)
        {
            if (Inserttxb.Text == string.Empty)
            {
                MessageBox.Show("Hãy nhập vào một giá trị", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                int tempValue;
                Node tempNode;
                try
                {

                    tempValue = Int32.Parse(Inserttxb.Text);
                }
                catch
                {
                    MessageBox.Show("Hãy nhập vào một số nguyên", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Inserttxb.Clear();
                    return;
                }
                try
                {
                    tempNode = new Node(tempValue);
                    myTree.Insert(tempNode);
                }
                catch
                {
                    MessageBox.Show("Giá trị trùng lặp!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Inserttxb.Clear();
                    return;
                }
                this.Controls.Add(tempNode.Box);
                DrawEdges(tempNode);
                Inserttxb.Clear();
                this.Update();
            }
        }

        private void Findbtn_Click(object sender, EventArgs e)
        {
            if (myTree.Root == null)
            {
                MessageBox.Show("Cây rỗng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Findtxb.Text == string.Empty)
            {
                MessageBox.Show("Hãy nhập vào một giá trị", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                int value;
                try
                {
                    value = Int32.Parse(Findtxb.Text);
                }
                catch
                {
                    MessageBox.Show("Hãy nhập vào một số nguyên", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Findtxb.Clear();
                    return;
                }
                Node Success = myTree.Find(value);
                if (Success != null)
                {
                    Color tempColor = Success.Box.BackColor;
                    Success.Box.BackColor = Color.Green;
                    MessageBox.Show($"{value} có ở trong tree", "Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Success.Box.BackColor = tempColor;
                    Findtxb.Clear();
                    return;
                }
                else
                {
                    MessageBox.Show($"{value} không có ở trong tree", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Findtxb.Clear();
                    return;
                }
            }
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            if (myTree.Root == null)
            {
                MessageBox.Show("Cây rỗng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Deletetxb.Text == string.Empty)
            {
                MessageBox.Show("Hãy nhập vào một giá trị", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                int tempValue;
                try
                {

                    tempValue = Int32.Parse(Deletetxb.Text);
                }
                catch
                {
                    MessageBox.Show("Hãy nhập vào một số nguyên", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Deletetxb.Clear();
                    return;
                }
                if (myTree.Remove(tempValue) == true)
                {
                    Deletetxb.Clear();
                    ReDraw();
                    MessageBox.Show($"{tempValue} đã xóa", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show($"{tempValue} không tồn tại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Deletetxb.Clear();
                    return;
                }
            }
        }

        /// <summary>
        /// Duyệt lần lượt từng node trong cây để vẽ lines
        /// </summary>
        /// <param name="current">Node hiện tại đang xét</param>
        private void DrawLines(Node current)
        {
            DrawEdges(current);
            if (current.Left != null) DrawLines(current.Left);
            if (current.Right != null) DrawLines(current.Right);
        }

        /// <summary>
        /// Vẽ lại các lines sau khi delete 1 node
        /// </summary>
        private void ReDraw()
        {
            g.Clear(Color.White);
            //g.FillRectangle(tBrush, this.DisplayRectangle);
            //Vẽ lại các lines
            Node current = myTree.Root;
            DrawLines(current);
        }

        private void Maxbtn_Click(object sender, EventArgs e)
        {
            if (myTree.Root == null)
            {
                MessageBox.Show("Cây rỗng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Color tempColor = myTree.GetMax().Box.BackColor;
                myTree.GetMax().Box.BackColor = Color.Green;
                //textBox18.Text = myTree.GetMax().Data.ToString();
                MessageBox.Show("Giá trị lớn nhất là: " + myTree.GetMax().Data.ToString(), "Max", MessageBoxButtons.OK, MessageBoxIcon.Information);
                myTree.GetMax().Box.BackColor = tempColor;
            }
        }

        private void Minbtn_Click(object sender, EventArgs e)
        {
            if (myTree.Root == null)
            {
                MessageBox.Show("Cây rỗng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Color tempColor = myTree.GetMin().Box.BackColor;
                myTree.GetMin().Box.BackColor = Color.Green;
                MessageBox.Show("Giá trị nhỏ nhất là: " + myTree.GetMin().Data.ToString(), "Min", MessageBoxButtons.OK, MessageBoxIcon.Information);
                myTree.GetMin().Box.BackColor = tempColor;
                //textBox19.Text = myTree.GetMin().Data.ToString();
            }
        }

        private void Displaybtn_Click(object sender, EventArgs e)
        {
            if (myTree.Root != null)
            {
                MessageBox.Show(myTree.Display(), "Display", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cây rỗng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Resetbtn_Click(object sender, EventArgs e)
        {
            if (myTree.Root == null)
            {
                MessageBox.Show("Cây rỗng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                myTree.Reset();
                g.Clear(Color.White);
                MessageBox.Show("Đã xóa cây", "Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
