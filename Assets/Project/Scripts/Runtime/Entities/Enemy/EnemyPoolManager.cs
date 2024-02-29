using System.Collections.Generic;
using UnityEngine;
using Gameplay.Utils;

namespace Entities.Enemies
{
    public sealed class EnemyPoolManager : MonoBehaviour
    {
        public static EnemyPoolManager Instance;
        [SerializeField] private Enemy[] _enemies;

        private Dictionary<string, EnemyFactory> _factoryDic = new Dictionary<string, EnemyFactory>();
        public Dictionary<string, Pool<Enemy>> _poolDic = new Dictionary<string, Pool<Enemy>>();

        private void Awake() => Instance = this;

        private void Start()
        {
            foreach (Enemy enemy in _enemies)
                SetPoolAndFactory(enemy.gameObject.name);
        }

        public void SetPoolAndFactory(string key)
        {
            if (!_poolDic.ContainsKey(key))
            {
                _factoryDic.Add(key, new EnemyFactory(key));
                _poolDic.Add(key, new Pool<Enemy>(_factoryDic[key].Create, Enemy.Enable, Enemy.Disable));
            }
        }
    }
}
