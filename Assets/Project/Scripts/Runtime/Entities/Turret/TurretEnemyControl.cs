using System.Collections.Generic;
using Entities.Enemies;

namespace Entities.Turrets
{
    public sealed class TurretEnemyControl
    {
        public List<Enemy> EnemiesInSight { get; private set; } = new List<Enemy>();
        public Enemy CurrentTarget { get; set; }

        public TurretEnemyControl()
        {
            Gameplay.Utils.EventManager.Subscribe(LevelEvent.OnEnemyReturnToPool, RemoveEnemy);
        }

        public void AddEnemy(Enemy enemy)
        {
            if (EnemiesInSight.Contains(enemy)) return;
            
            EnemiesInSight.Add(enemy);

            if (EnemiesInSight.Count == 1)
                CurrentTarget = enemy;
        }

        public void RemoveEnemy(params object[] parameters)
        {
            Enemy target = (Enemy)parameters[0];
            if (!EnemiesInSight.Contains(target)) return;

            EnemiesInSight.Remove(target);

            if (target == CurrentTarget)
            {
                if (EnemiesInSight.Count > 0)
                    CurrentTarget = EnemiesInSight[0];
                else
                    CurrentTarget = null;
            }
        }
    }
}