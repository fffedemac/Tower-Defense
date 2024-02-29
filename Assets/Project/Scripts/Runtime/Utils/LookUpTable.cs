using System;
using System.Collections.Generic;

namespace Gameplay.Utils
{
    public class LookUpTable<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> _values = new Dictionary<TKey, TValue>();
        private readonly Func<TKey, TValue> _process;

        public LookUpTable(Func<TKey, TValue> process) => _process = process;

        public TValue Get(TKey key)
        {
            if (!_values.TryGetValue(key, out var value))
            {
                value = _process(key);
                _values[key] = value;
            }

            return value;
        }

        public TValue this[TKey key] => Get(key);
    }
}