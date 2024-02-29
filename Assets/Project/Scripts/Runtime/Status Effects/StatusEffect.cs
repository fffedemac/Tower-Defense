using System.Collections;
using UnityEngine;

namespace StatusEffects
{
    public sealed partial class StatusEffect : MonoBehaviour
    {
        [field: SerializeField] public StatusEffectData EffectData {  get; private set; }
        private float _durationTimer;
        private IStatusEffectReceptor _receptor;

        public void Initialize(GameObject target)
        {
            CheckIfEffectExists(target);

            transform.parent = target.transform;
            _receptor = target.GetComponent<IStatusEffectReceptor>();

            StartCoroutine(ApplyEffect(_receptor));
        }

        private IEnumerator ApplyEffect(IStatusEffectReceptor target)
        {
            WaitForSeconds tickDuration = new WaitForSeconds(EffectData.Tick);

            while (_durationTimer <= EffectData.Duration)
            {
                _durationTimer += EffectData.Tick;
                EffectBehaviour(target, EffectData.PercentageValue);
                yield return tickDuration;
            }

            EffectBehaviour(target, 1);
            ReturnToPool();
        }

        public void StopEffect() 
        {
            StopCoroutine(nameof(ApplyEffect));
            ReturnToPool();
        }

        private void EffectBehaviour(IStatusEffectReceptor target, float percentageValue)
        {
            if (EffectData.Type == EffectType.Slow)
                target.UpdateSpeed(percentageValue);
        }

        private void CheckIfEffectExists(GameObject target)
        {
            StatusEffect[] executingEffects = target.GetComponentsInChildren<StatusEffect>();
            foreach (StatusEffect executingEffect in executingEffects)
            {
                if (executingEffect == this) continue;

                if (executingEffect.EffectData.Type == EffectData.Type)
                    executingEffect.StopEffect();
            }
        }
    }
}
