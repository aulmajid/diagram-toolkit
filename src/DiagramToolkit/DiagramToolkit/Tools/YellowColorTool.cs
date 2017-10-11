using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using DiagramToolkit.Visitors;

namespace DiagramToolkit.Tools
{
    public class YellowColorTool : ToolStripButton, ITool
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

        public YellowColorTool()
        {
            this.Name = "Yellow Color";
            this.ToolTipText = "Yellow Color";
            this.CheckOnClick = true;
            this.BackColor = Color.Yellow;
            this.visitor = new YellowVisitor();
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
