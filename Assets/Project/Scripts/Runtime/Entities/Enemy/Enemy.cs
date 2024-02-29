using UnityEngine;

namespace Entities.Enemies
{
    [RequireComponent(typeof(Rigidbody), typeof(EnemyUI))]
    public abstract partial class Enemy : MonoBehaviour
    {
        [SerializeField] protected EnemyData _data;
        [SerializeField] protected EnemyUI _enemyUI;
        [SerializeField] protected Rigidbody _rigidbody;
        protected float _currentSpeed;
        protected int _currentHealth;

        public virtual void Initialize(Vector3 position, Quaternion rotation)
        {
            _rigidbody.velocity = Vector3.zero;

            _currentHealth = _data.MaxHealth;
            _currentSpeed = _data.Speed;
            _enemyUI.InitializeValues(_currentHealth);

            transform.position = position;
            transform.rotation = rotation;
        }

        protected void OnTriggerEnter(Collider other) 
        {
            if (other.gameObject.layer == 6)
            {
                other.GetComponent<IDamageable>()?.GetDamage(_data.Damage);
                ReturnToPool();
            }
        }
    }
}