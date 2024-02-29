namespace Gameplay.Utils
{
    public interface IFactory<T>
    {
        T Create();
    }
}