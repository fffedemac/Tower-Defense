using Entities.Enemies;

namespace WaveSystem
{
    public sealed class WaveChecker
    {
        private int _enemiesCount;

        public WaveChecker()
        {
            Gameplay.Utils.EventManager.Subscribe(LevelEvent.OnEnemyReturnToPool, RemoveEnemy);
        }

        public void AddEnemies(Enemy[] enemies)
        {
            foreach (Enemy enemy in enemies)
                _enemiesCount++;
        }

        private void RemoveEnemy(params object[] parameters)
        {
            _enemiesCount--;

            if (_enemiesCount == 0)
                WaveManager.Instance.StartWave();
        }
    }
}