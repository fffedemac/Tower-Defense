using System.Collections.Generic;
using UnityEngine;
using Gameplay.Utils;
using StatusEffects;

public class BulletNormal : Bullet
{
    [SerializeField] protected float _lifeTime;
    private float timer;

    public override void Initialize(Vector3 position, Quaternion rotation, int damage, List<StatusEffect> statusEffects, Pool<Bullet> pool)
    {
        base.Initialize(position, rotation, damage, statusEffects, pool);
        _rigidbody.velocity = transform.forward * Speed;
        timer = 0;
    }

    protected virtual void Update()
    {
        timer += Time.deltaTime;

        if (timer >= _lifeTime)
            Reset();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            other.GetComponent<IDamageable>()?.GetDamage(_damage);

            if (other.gameObject.activeSelf)
                _statusEffectDealer.ApplyStatusEffects(other.gameObject);

            Reset();
        }
    }
}
