namespace SnakeApp.Infrastructure
{
    public interface IFigure : IDrawable
    {
        bool IsHit(IPoint inputPoint);
        bool IsHit(IFigure figure);
    }
}
