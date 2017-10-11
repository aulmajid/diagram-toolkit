using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using DiagramToolkit.Visitors;

namespace DiagramToolkit.Tools
{
    public class PinkColorTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private DrawingObject selectedObject;
        private IVisitor visitor;

        public Cursor Cursor
        {
            get
            {
                return Cursors.Arrow;
            }
        }

        public ICanvas TargetCanvas
        {
            get
            {
                return this.canvas;
            }

            set
            {
                this.canvas = value;
            }
        }

        public PinkColorTool()
        {
            this.Name = "Pink Color";
            this.ToolTipText = "Pink Color";
            this.CheckOnClick = true;
            this.BackColor = Color.Pink;
            this.visitor = new PinkVisitor();
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {      
            if (e.Button == MouseButtons.Left && canvas != null)
            {
                selectedObject = canvas.SelectObjectAt(e.X, e.Y);
                canvas.DeselectAllObjects();
                if (selectedObject != null)
                {
                    selectedObject.Accept(visitor);
                }
            }
           
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {
            canvas.Accept(visitor);
        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {
            
        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {
            
        }

        public void ToolHotKeysDown(object sender, Keys e)
        {
            
        }
    }
}
