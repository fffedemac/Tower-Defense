using System.Collections;
using UnityEngine;
using Gameplay.Utils;

namespace Entities.Turrets
{
    public partial class TurretBase : Turret
    {
        protected Quaternion _targetRotation;
        protected Coroutine AttackCoroutine;

        protected override void StartAttack()
        {
            if (AttackCoroutine == null)
                AttackCoroutine = StartCoroutine(Attack(_currentPool));
            else
            {
                StopAttack();
                AttackCoroutine = StartCoroutine(Attack(_currentPool));
            }
        }

        protected override void StopAttack() => StopCoroutine(AttackCoroutine);

        protected virtual IEnumerator Attack(Pool<Bullet> bulletPool)
        {
            WaitForSeconds waitTime = new WaitForSeconds(_turretData.FireRate);
            Rigidbody targetRigidbody = _enemyControl.CurrentTarget.GetComponent<Rigidbody>();

            while (true)
            {
                if (_enemyControl.CurrentTarget == null) break;

                Vector3 predictedTargetPosition = Vector3Extensions.PredictPosition(
                    transform.position,
                    _enemyControl.CurrentTarget.transform.position,
                    targetRigidbody.velocity,
                    _currentBullet.Speed);

                _targetRotation = Quaternion.LookRotation(predictedTargetPosition - transform.position, Vector3.up);
                _targetRotation.eulerAngles = new Vector3(0f, _targetRotation.eulerAngles.y, 0f);
                transform.rotation = Quaternion.identity * _targetRotation;

                SpawnBullet();

                yield return waitTime;
            }
        }
    }
}
