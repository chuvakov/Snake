namespace SnakeApp.Infrastructure
{
    public interface IGameObject : IDrawable
    {
        /// <summary>
        /// Соприкосновение с точкой
        /// </summary>        
        bool IsHit(IPoint inputPoint);

        /// <summary>
        /// Соприкосновение с фигурой
        /// </summary>        
        bool IsHit(IGameObject figure);
    }
}
