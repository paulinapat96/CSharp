using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_Lab4
{
    class Rectangle : Tool
    {
        Vector2 startMousePos;
        public Rectangle(Panel board, Button button, float size, Color color)
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
            Vector2 size;
            size.x = _currentMousePos.x - _currentMousePos.x;
            size.y = _currentMousePos.y - _currentMousePos.y;
            if (size.x < 0)
            {
                startMousePos.x = _currentMousePos.x;
                size.x = Math.Abs(size.x);
            }
            if (size.y < 0)
            {
                startMousePos.y = _currentMousePos.y;
                size.y = Math.Abs(size.y);
            }
             Graphics _graph = _board.CreateGraphics();
            _graph.DrawRectangle(new Pen(_brushColor, _brushSize), startMousePos.x, startMousePos.y, size.x, size.y);
        }
    }
}
