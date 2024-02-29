using System.Collections.Generic;
using UnityEngine;
using Gameplay.Utils;

namespace Entities.Turrets
{
    public partial class TurretBase : Turret
    {
        [SerializeField] private Bullet _currentBullet;

        private Dictionary<string, BulletFactory> _factoryDic = new Dictionary<string, BulletFactory>();
        private Dictionary<string, Pool<Bullet>> _poolDic = new Dictionary<string, Pool<Bullet>>();
        private Pool<Bullet> _currentPool;

        private void Awake()
        {
            SetPoolAndFactory(_currentBullet.name);
        }

        private void SetPoolAndFactory(string key)
        {
            if (!_poolDic.ContainsKey(key))
            {
                _factoryDic.Add(key, new BulletFactory(key));
                _poolDic.Add(key, new Pool<Bullet>(_factoryDic[key].Create, Bullet.Enable, Bullet.Disable));
            }

            _currentPool = _poolDic[key];
        }

        private void SpawnBullet()
        {
            _currentBullet = _currentPool.Get();
            _currentBullet.Initialize(transform.position, transform.rotation, _turretData.Damage, _turretData.StatusEffects ,_currentPool);
        }
    }
}
