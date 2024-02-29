using System.Collections.Generic;
using UnityEngine;
using Gameplay.Utils;
using StatusEffects;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected Rigidbody _rigidbody;
    [field: SerializeField] public float Speed { get; private set; }
    protected Pool<Bullet> _pool;
    protected int _damage;

    protected StatusEffectDealer _statusEffectDealer;

    public static void Enable(Bullet bullet) => bullet.gameObject.SetActive(true);
    public static void Disable(Bullet bullet) => bullet.gameObject.SetActive(false);

    public virtual void Initialize(Vector3 position, Quaternion rotation, int damage, List<StatusEffect> statusEffects, Pool<Bullet> pool)
    {
        transform.position = position;
        transform.rotation = rotation;
        _damage = damage;
        _statusEffectDealer = new StatusEffectDealer(statusEffects);
        _pool = pool;
    }

    protected void Reset()
    {
        if (gameObject.activeSelf)
        {
            _rigidbody.velocity = Vector3.zero;
            _pool.Store(this);
        }
    }
}
