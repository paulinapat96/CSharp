using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_Lab4
{
    class Line : Tool
    {
        Vector2 startMousePos;
        public Line(Panel board, Button button, float size, Color color)
        {
            _board = board;
            _actionButton = button;
            _actionButton.BackColor = Color.Green;

            _brushSize = size;
            _brushColor = color;
        }

        public override void OnMouseDown(Vector2 mousePos)
        {
            _currentMousePos = mousePos;
            startMousePos = mousePos;
        }

        public override void OnMouseMove(Vector2 mousePos)
        {
            _currentMousePos = mousePos;
        }

        public override void OnMouseUp(Vector2 mousePos)
        {
            _currentMousePos = mousePos;
            Paint();
        }

        public override void Paint()
        {
            Graphics _graph = _board.CreateGraphics();
            _graph.DrawLine(new Pen(_brushColor, _brushSize), startMousePos.x, startMousePos.y, _currentMousePos.x, _currentMousePos.y);

        }
    }
}
