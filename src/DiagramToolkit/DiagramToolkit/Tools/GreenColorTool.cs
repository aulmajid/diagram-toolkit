using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using DiagramToolkit.Visitors;

namespace DiagramToolkit.Tools
{
    public class GreenColorTool : ToolStripButton, ITool
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

        public GreenColorTool()
        {
            this.Name = "Green Color";
            this.ToolTipText = "Green Color";
            this.CheckOnClick = true;
            this.BackColor = Color.Green;
            this.visitor = new GreenVisitor();
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

        private void InitializeComponent()
        {
            // 
            // GreenColorTool
            // 
            this.Click += new System.EventHandler(this.GreenColorTool_Click);

        }

        private void GreenColorTool_Click(object sender, System.EventArgs e)
        {

        }
    }
}
