using System.Collections;
using UnityEngine;

namespace WaveSystem
{
    public sealed partial class WaveManager : MonoBehaviour
    {
        [SerializeField] private int _restTimeBetweenWaves;
        [SerializeField] private int _maxWaves;
        private int _currentWave;

        public void StartWave()
        {
            if (_currentWave >= _maxWaves)
            {
                GameManager.Instance.LevelCompleted();
                return;
            }
            
            StartCoroutine(SendWave());
        }

        private IEnumerator SendWave()
        {
            _waveManagerUI.StartCountdown(_currentWave, _maxWaves, _restTimeBetweenWaves);
            yield return new WaitForSeconds(_restTimeBetweenWaves);

            foreach (EnemySpawner spawner in _spawners)
            {
                if (_currentWave < spawner.Waves.Length)
                    spawner.StartSpawning(_currentWave);
            }
            
            _currentWave++;
        }
    }
}