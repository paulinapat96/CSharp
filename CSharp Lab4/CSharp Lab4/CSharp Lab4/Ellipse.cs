using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_Lab4
{
    class Ellipse : Tool
    {
        Vector2 startMousePos;
        public Ellipse(Panel board, Button button, float size, Color color)
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
            Vector2 size;
            size.x = _currentMousePos.x - startMousePos.x;
            size.y = _currentMousePos.y - startMousePos.y;
            _graph.DrawEllipse(new Pen(_brushColor, _brushSize), startMousePos.x, startMousePos.y, size.x, size.y);
        }
    }
}
