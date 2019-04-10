using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CSharp_Lab4
{
     class Pencil : Tool
    {
        public Pencil(Panel board, Button button, float size, Color color)
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
        }

        public override void OnMouseMove(Vector2 mousePos)
        {
            _currentMousePos = mousePos;
            Paint();
        }

        public override void OnMouseUp(Vector2 mousePos)
        {
            _currentMousePos = mousePos;
        }

        public override void Paint()
        {
            Graphics _graph = _board.CreateGraphics();
            _graph.DrawEllipse(new Pen(_brushColor, _brushSize), _currentMousePos.x, _currentMousePos.y, 1, 1);
        }
    }
}
