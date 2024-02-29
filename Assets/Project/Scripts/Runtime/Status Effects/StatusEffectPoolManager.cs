using System.Collections.Generic;
using UnityEngine;
using Gameplay.Utils;

namespace StatusEffects
{
    public sealed class StatusEffectPoolManager : MonoBehaviour
    {
        public static StatusEffectPoolManager Instance;
        [SerializeField] private StatusEffect[] _effects;

        private Dictionary<string, StatusEffectFactory> _factoryDic = new Dictionary<string, StatusEffectFactory>();
        public Dictionary<string, Pool<StatusEffect>> _poolDic = new Dictionary<string, Pool<StatusEffect>>();

        private void Awake() => Instance = this;

        private void Start()
        {
            foreach (StatusEffect effect in _effects)
                SetPoolAndFactory(effect.gameObject.name);
        }

        public void SetPoolAndFactory(string key)
        {
            if (!_poolDic.ContainsKey(key))
            {
                _factoryDic.Add(key, new StatusEffectFactory(key));
                _poolDic.Add(key, new Pool<StatusEffect>(_factoryDic[key].Create, StatusEffect.Enable, StatusEffect.Disable));
            }
        }
    }
}
