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
    public struct Vector2
    {
        public int x;
        public int y;

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public partial class Form1 : Form
    {
        Tool activeTool;
        float brushSize = 5;
        Color brushColor = Color.Black;

        public Form1()
        {
            
            InitializeComponent();
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            activeTool = new Pencil(paintingBoard, toolPenBtn, brushSize, brushColor);

            ChangeColor(brushColor);     

            // ** Listeners -------------------------------------------------------------------------------------------------------------------------
            toolPenBtn.Click += (sender, EventArgs) => { toolBtn_Click( sender, EventArgs, new Pencil(paintingBoard, toolPenBtn,  brushSize, brushColor)); };
            toolEreaserBtn.Click += (sender, EventArgs) => { toolBtn_Click(sender, EventArgs, new Ereaser(paintingBoard, toolEreaserBtn,  brushSize, brushColor)); };
            toolLineBtn.Click += (sender, EventArgs) => { toolBtn_Click(sender, EventArgs, new Line(paintingBoard, toolLineBtn, brushSize, brushColor)); };
            toolEllipseBtn.Click += (sender, EventArgs) => { toolBtn_Click(sender, EventArgs, new Ellipse(paintingBoard, toolEllipseBtn, brushSize, brushColor)); };
            toolRectangleBtn.Click += (sender, EventArgs) => { toolBtn_Click(sender, EventArgs, new Rectangle(paintingBoard, toolRectangleBtn, brushSize, brushColor)); };
        }

        private void ChangeColor(Color color)
        {
            brushColor = color;
            activeTool.ChangeColor(brushColor);
        }

        private void ChangeTool(Tool tool)
        {
            activeTool.DisactiveButton();
            activeTool = tool;
        }

        private void paintingBoard_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                activeTool.OnMouseDown(new Vector2(e.X, e.Y));
            }
        }

        private void paintingBoard_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                activeTool.OnMouseMove(new Vector2(e.X, e.Y));
            }
        }

        private void paintingBoard_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                activeTool.OnMouseUp(new Vector2(e.X, e.Y));
            }
        }

        private void toolBtn_Click(object sender, EventArgs e, Tool tool)
        {
            ChangeTool(tool);
        }

        private void SizeBar_Scroll(object sender, ScrollEventArgs e)
        {
            brushSize = (SizeBar.Value + 1.0f) / 10.0f;
            activeTool.ChangeSize(brushSize);
            brushSizeLabel.Text = brushSize.ToString();
        }

        private void colorBtn_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.ShowDialog();
            colorBtn.BackColor = MyDialog.Color;
            ChangeColor(MyDialog.Color);

        }
    }
}
