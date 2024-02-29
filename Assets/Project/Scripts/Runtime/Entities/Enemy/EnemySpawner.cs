using System.Collections;
using UnityEngine;
using Gameplay.Utils;
using Entities.Enemies;

namespace WaveSystem
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Wave[] _waves;
        public Wave[] Waves => _waves;

        private Enemy _spawnedEnemy;
        private Pool<Enemy> _currentPool;

        public void StartSpawning(int wave) => StartCoroutine(Spawn(wave));

        private IEnumerator Spawn(int wave)
        {
            foreach (WaveData data in _waves[wave].WaveData)
            {
                WaveManager.Instance.WaveChecker.AddEnemies(data.Enemies);
                yield return new WaitForSeconds(data.DelayTime);

                foreach (Enemy enemy in data.Enemies)
                {
                    if (enemy == null) continue;

                    _currentPool = EnemyPoolManager.Instance._poolDic[enemy.gameObject.name];

                    _spawnedEnemy = _currentPool.Get();
                    _spawnedEnemy._pool = _currentPool;
                    _spawnedEnemy.Initialize(transform.position, transform.rotation);

                    yield return new WaitForSeconds(data.SpawnRate);
                }
            }
        }
    }
}
