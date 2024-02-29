using StatusEffects;
using UnityEngine;

namespace Entities.Enemies
{
    public class Creep : Enemy, IStatusEffectReceptor
    {
        public override void Initialize(Vector3 position, Quaternion rotation)
        {
            base.Initialize(position, rotation);
            Movement();
        }

        private void Movement() => _rigidbody.velocity = transform.forward * _currentSpeed;

        public void GetDamage(int damage)
        {
            _currentHealth -= damage;
            _enemyUI.UpdateHealth(_currentHealth);

            if (_currentHealth <= 0)
            {
                Gameplay.Utils.EventManager.Trigger(LevelEvent.OnEnemyKilled, _data.CoinReward);
                ReturnToPool();
            }
        }

        public void UpdateSpeed(float value)
        {
            _currentSpeed = _data.Speed * value;
            _rigidbody.velocity = transform.forward * _currentSpeed;
        }

        public float GetMaxSpeed() => _data.Speed;
    }
}