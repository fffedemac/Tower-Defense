using UnityEngine;
using Entities.Enemies;

namespace Entities.Turrets
{
    public abstract class Turret : MonoBehaviour
    {
        [SerializeField] protected TurretData _turretData;
        [SerializeField] protected GameObject _sightSprite;
        [SerializeField] protected SphereCollider _sightTrigger;
        protected TurretEnemyControl _enemyControl = new TurretEnemyControl();

        protected abstract void StartAttack();
        protected abstract void StopAttack();

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != 7) return;

            _enemyControl.AddEnemy(other.GetComponent<Enemy>());
            if (_enemyControl.EnemiesInSight.Count == 1)
                StartAttack();
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer != 7) return;

            _enemyControl.RemoveEnemy(other.GetComponent<Enemy>());
            if (_enemyControl.EnemiesInSight.Count == 0)
                StopAttack();
        }

        public TurretData GetTurretData() => _turretData;
    }
}