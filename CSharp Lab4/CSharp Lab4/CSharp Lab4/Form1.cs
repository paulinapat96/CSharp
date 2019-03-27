using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_Lab4
{
    struct Vector2
    {
        public int x;
        public int y;

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    enum Tools { PEN, EREASER, LINE, ELLIPSE, RECTANGLE};

    public partial class Form1 : Form
    {
        Color currentColor;
        Vector2 currentMousePos, startMousePos;
        Button currentActiveButton;
        Tools currentTool;
        Bitmap preview;
        bool isPrevievModeActive;
        float brushSize;


        public Form1()
        {
            InitializeComponent();
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            ChangeColor(Color.Black);
            currentMousePos = new Vector2(0, 0);
            startMousePos = new Vector2(0, 0);
            currentTool = Tools.PEN;
            preview = new Bitmap(paintingBoard.Size.Width, paintingBoard.Size.Height); // new Size(paintingBoard.Size.Width, paintingBoard.Size.Height)
            isPrevievModeActive = false;
            currentActiveButton = toolPenBtn;
            brushSize = 5;
            

            ChangeTool(Tools.PEN);
            paintingBoard.Controls.Clear();

            toolPenBtn.Click += (sender, EventArgs) => { toolBtn_Click( sender, EventArgs, Tools.PEN); };
            toolEreaserBtn.Click += (sender, EventArgs) => { toolBtn_Click(sender, EventArgs, Tools.EREASER); };
            toolLineBtn.Click += (sender, EventArgs) => { toolBtn_Click(sender, EventArgs, Tools.LINE); };
            toolEllipseBtn.Click += (sender, EventArgs) => { toolBtn_Click(sender, EventArgs, Tools.ELLIPSE); };
            toolRectangleBtn.Click += (sender, EventArgs) => { toolBtn_Click(sender, EventArgs, Tools.RECTANGLE); };
        }

        private void ChangeColor(Color color)
        {
            currentColor = color;
            colorBtn.BackColor = currentColor;
        }

        private void ChangeTool(Tools tool)
        {
            currentActiveButton.BackColor = Color.Black;
            switch (tool)
            {
                case Tools.PEN:
                    Cursor.Current = Cursors.Hand;
                    toolPenBtn.BackColor = Color.Green;
                    break;

                case Tools.EREASER:
                    Cursor.Current = Cursors.Hand;
                    toolEreaserBtn.BackColor = Color.Green;
                    break;

                case Tools.LINE:
                    toolLineBtn.BackColor = Color.Green;
                    Cursor.Current = Cursors.Cross;
                    break;

                case Tools.ELLIPSE:
                    toolEllipseBtn.BackColor = Color.Green;
                    Cursor.Current = Cursors.Cross;
                    break;

                case Tools.RECTANGLE:
                    toolRectangleBtn.BackColor = Color.Green;
                    Cursor.Current = Cursors.Cross;
                    break;
            }
            currentTool = tool;
        }

        private void paintingBoard_Paint(object sender, PaintEventArgs e)
        {
            Graphics graph = paintingBoard.CreateGraphics();
            int width, height;
            switch (currentTool)
            {
                case Tools.PEN:
                    graph.DrawEllipse(new Pen(currentColor, brushSize), currentMousePos.x, currentMousePos.y, 1, 1);
                    break;

                case Tools.EREASER:
                    graph.DrawEllipse(new Pen(Color.White, 5 * brushSize), currentMousePos.x, currentMousePos.y, 50, 50);
                    break;

                case Tools.LINE:
                    graph.DrawLine(new Pen(currentColor, brushSize), startMousePos.x, startMousePos.y, currentMousePos.x, currentMousePos.y);
                    break;

                case Tools.ELLIPSE:
                    width = currentMousePos.x - startMousePos.x;
                    height = currentMousePos.y - startMousePos.y;
                    graph.DrawEllipse(new Pen(currentColor, brushSize), startMousePos.x, startMousePos.y, width, height);
                    break;

                case Tools.RECTANGLE:
                    width = currentMousePos.x - startMousePos.x;
                    height = currentMousePos.y - startMousePos.y;
                    if (width < 0)
                    {
                        startMousePos.x = currentMousePos.x;
                        width = Math.Abs(width);
                    }
                    if (height < 0)
                    {
                        startMousePos.y = currentMousePos.y;
                        height = Math.Abs(height);
                    }
                    graph.DrawRectangle(new Pen(currentColor, brushSize), startMousePos.x, startMousePos.y, width, height);
                    break;
            }
        }

        private void paintingBoard_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startMousePos.x = e.X;
                startMousePos.y = e.Y;

                if(currentTool != Tools.PEN && currentTool != Tools.EREASER)
                {
                    isPrevievModeActive = true;
                }
            }
        }

        private void paintingBoard_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                currentMousePos.x = e.X;
                currentMousePos.y = e.Y;

                if(currentTool == Tools.PEN )
                {
                    paintingBoard_Paint(this, null);
                }
                else if(currentTool == Tools.EREASER)
                {
                    paintingBoard_Paint(this, null);
                }
                else if(isPrevievModeActive)
                {
                    //preview
                }
            }
        }

        private void paintingBoard_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentMousePos.x = e.X;
                currentMousePos.y = e.Y;

                if(currentTool != Tools.PEN || currentTool != Tools.EREASER)
                {
                    paintingBoard_Paint(this, null);
                }
                isPrevievModeActive = false;
            }
        }

        private void toolBtn_Click(object sender, EventArgs e, Tools tool)
        {
            ChangeTool(tool);
            currentActiveButton = (Button)sender;
        }

        private void SizeBar_Scroll(object sender, ScrollEventArgs e)
        {
            brushSize = (SizeBar.Value + 1.0f) / 10.0f;
            brushSizeLabel.Text = brushSize.ToString();
        }

        private void colorBtn_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.ShowDialog();
            ChangeColor(MyDialog.Color);

        }
    }
}
