namespace SnakeApp.Infrastructure
{
    public interface IMap : IDrawable
    {
        IPoint Food { get; }

        /// <summary>
        /// Соприкосновение с картой
        /// </summary>        
        bool IsHit(IGameObject figure);

        /// <summary>
        /// Сгенерировать еду
        /// </summary>
        void GenerateFood();
    }
}
