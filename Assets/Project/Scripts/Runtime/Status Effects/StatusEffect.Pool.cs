using UnityEngine;
using Gameplay.Utils;

namespace StatusEffects
{
    public sealed partial class StatusEffect : MonoBehaviour
    {
        public Pool<StatusEffect> _pool { get; set; }

        public static void Enable(StatusEffect statusEffect) => statusEffect.gameObject.SetActive(true);
        public static void Disable(StatusEffect statusEffect) => statusEffect.gameObject.SetActive(false);

        private void ReturnToPool()
        {
            if (gameObject.activeSelf)
            {
                _durationTimer = 0;
                transform.parent = null;
                _pool.Store(this);
            }
        }
    }
}
