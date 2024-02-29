using UnityEngine;
using Gameplay.Utils;

namespace Entities.Enemies
{
    public abstract partial class Enemy : MonoBehaviour
    {
        public Pool<Enemy> _pool { get; set; }

        public static void Enable(Enemy enemy) => enemy.gameObject.SetActive(true);
        public static void Disable(Enemy enemy) => enemy.gameObject.SetActive(false);

        protected void ReturnToPool()
        {
            EventManager.Trigger(LevelEvent.OnEnemyReturnToPool, this);

            if (gameObject.activeSelf)
                _pool.Store(this);
        }
    }
}