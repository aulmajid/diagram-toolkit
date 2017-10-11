using DiagramToolkit.Shapes;
using System;
using System.Diagnostics;

namespace DiagramToolkit.Visitors
{
    public class PinkVisitor : IVisitor
    {
        System.Drawing.Color color = System.Drawing.Color.DeepPink;

        public void Visit(LineSegment lineSegment)
        {
            lineSegment.CurrentColor = this.color;
            Debug.WriteLine("Line Segment : " + lineSegment.ID + ", Color : " + this.color.Name);
        }

        public void Visit(Rectangle rectangle)
        {
            rectangle.CurrentColor = this.color;
            Debug.WriteLine("Rectangle : " + rectangle.ID + ", Color : " + this.color.Name);
        }

        public void Visit(Text text)
        {
            throw new NotImplementedException();
        }

        public void Visit(ICanvas canvas)
        {
            canvas.SetBackgroundColor(this.color);
            Debug.WriteLine("Canvas : " + canvas.Name + ", Color : " + this.color.Name);
        }
    }
}