using System.Collections.Generic;
using UnityEngine;
using Gameplay.Utils;

namespace StatusEffects
{
    public sealed class StatusEffectDealer
    {
        private List<StatusEffect> _statusEffects = new List<StatusEffect>();
        private Pool<StatusEffect> _currentStatusEffectPool;
        private StatusEffect _spawnedStatusEffect;

        public StatusEffectDealer(List<StatusEffect> statusEffects)
        {
            _statusEffects = statusEffects;
        }

        public void ApplyStatusEffects(GameObject target)
        {
            if (_statusEffects.Count > 0)
            {
                for (int i = 0; i < _statusEffects.Count; i++)
                {
                    _currentStatusEffectPool = StatusEffectPoolManager.Instance._poolDic[_statusEffects[i].gameObject.name];
                    _spawnedStatusEffect = _currentStatusEffectPool.Get();
                    _spawnedStatusEffect._pool = _currentStatusEffectPool;
                    _spawnedStatusEffect.Initialize(target);
                }
            }
        }
    }
}
