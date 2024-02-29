using System.Collections.Generic;

namespace Gameplay.Utils
{
    public class EventManager
    {
        public delegate void Callback(params object[] parameters);

        private static Dictionary<object, HashSet<Callback>> _events = new Dictionary<object, HashSet<Callback>>();

        public static void Subscribe(object eventId, Callback callback)
        {
            if (_events.ContainsKey(eventId))
            {
                if (!_events[eventId].Contains(callback))
                    _events[eventId].Add(callback);
            }
            else _events.Add(eventId, new HashSet<Callback> { callback });
        }

        public static void Unsubscribe(object eventId, Callback callback)
        {
            if (_events.ContainsKey(eventId))
            {
                if (_events[eventId].Contains(callback))
                {
                    _events[eventId].Remove(callback);

                    if (_events[eventId].Count == 0)
                        _events.Remove(eventId);
                }
            }
        }

        public static void Trigger(object eventId, params object[] parameters)
        {
            if (_events.ContainsKey(eventId))
            {
                HashSet<Callback> callbacks = _events[eventId];
                foreach (Callback call in callbacks)
                    call(parameters);
            }
        }

        public static void ClearDic() => _events.Clear();
    }
}