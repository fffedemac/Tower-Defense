using UnityEngine;
using Entities.Enemies;

namespace WaveSystem
{
    [System.Serializable]
    public struct WaveData
    {
        [SerializeField] private int _delayTime;
        [SerializeField] private float _spawnRate;
        [SerializeField] private Enemy[] _enemies;

        public int DelayTime { get { return _delayTime; } }
        public float SpawnRate { get { return _spawnRate; } }
        public Enemy[] Enemies { get { return _enemies; } }
    }
}