using Gameplay.Utils;
using UnityEngine;

namespace StatusEffects
{
    public sealed class StatusEffectFactory : IFactory<StatusEffect>
    {
        private LookUpTable<string, StatusEffect> _lookUpForEffects;
        private string _type;

        public StatusEffectFactory(string type)
        {
            _type = type;

            if (_lookUpForEffects == null)
                _lookUpForEffects = new LookUpTable<string, StatusEffect>(SearchPrefab);
        }

        public StatusEffect Create() => Object.Instantiate(_lookUpForEffects.Get(_type));

        private StatusEffect SearchPrefab(string name) => Resources.Load<StatusEffect>("Prefabs/StatusEffects/" + name);
    }
}
