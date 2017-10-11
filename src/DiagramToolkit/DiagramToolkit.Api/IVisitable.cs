namespace DiagramToolkit
{
    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
}
