using DiagramToolkit.Shapes;

namespace DiagramToolkit
{
    public interface IVisitor
    {
        void Visit(LineSegment lineSegment);
        void Visit(Rectangle rectangle);
        void Visit(Text text);
        void Visit(ICanvas canvas);
    }
}
