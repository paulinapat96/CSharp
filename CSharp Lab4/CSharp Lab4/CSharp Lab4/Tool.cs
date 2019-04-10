using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_Lab4
{
    public class Tool
    {
        protected Graphics _graph;
        protected Panel _board;
        protected Button _actionButton;
        protected Vector2 _currentMousePos;
        protected float _brushSize;
        protected Color _brushColor;


        public virtual void Paint()
        {
            //throw new NotImplementedException();
        }

        public virtual void OnMouseUp(Vector2 mousePos)
        {
           // throw new NotImplementedException();
        }

        public virtual void OnMouseMove(Vector2 mousePos)
        {
           // throw new NotImplementedException();
        }

        public virtual void OnMouseDown(Vector2 mousePos)
        {
           // throw new NotImplementedException();
        }

        public void ChangeColor(Color brushColor)
        {
            _brushColor = brushColor;
        }

        public void ChangeSize(float brushSize)
        {
            _brushSize = brushSize;
        }

        public void DisactiveButton()
        {
            _actionButton.BackColor = Color.Black;
        }
    }
}
