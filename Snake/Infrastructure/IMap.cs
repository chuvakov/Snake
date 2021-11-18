namespace SnakeApp.Infrastructure
{
    public interface IMap : IDrawable
    {
        IPoint Food { get; }

        bool IsHit(IFigure figure);

        void GenerateFood();
    }
}
