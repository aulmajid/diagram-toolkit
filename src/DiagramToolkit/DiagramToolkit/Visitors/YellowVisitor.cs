using DiagramToolkit.Shapes;
using System;
using System.Diagnostics;

namespace DiagramToolkit.Visitors
{
    public class YellowVisitor : IVisitor
    {
        System.Drawing.Color color = System.Drawing.Color.Yellow;

        public void Visit(LineSegment lineSegment)
        {
            lineSegment.CurrentColor = this.color;
            Debug.WriteLine("Line Segment : " + lineSegment.ToString() + ", Color : " + this.color.Name);
        }

        public void Visit(Rectangle rectangle)
        {
            rectangle.CurrentColor = this.color;
            Debug.WriteLine("Rectangle : " + rectangle.ToString() + ", Color : " + this.color.Name);
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
