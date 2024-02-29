using System;
using System.Collections.Generic;

namespace Gameplay.Utils
{
    public sealed class Pool<T>
    {
        private readonly Stack<T> _pool;
        private readonly Func<T> _factoryMethod;
        private readonly Action<T> _enable;
        private readonly Action<T> _disable;

        public Pool(Func<T> factoryMethod, Action<T> enable, Action<T> disable)
        {
            _pool = new Stack<T>();
            _factoryMethod = factoryMethod;
            _enable = enable;
            _disable = disable;
        }

        public T Get()
        {
            T obj = (_pool.Count > 0) ? _pool.Pop() : _factoryMethod();
            _enable(obj);

            return obj;
        }

        public void Store(T obj)
        {
            _pool.Push(obj);
            _disable(obj);
        }
    }
}