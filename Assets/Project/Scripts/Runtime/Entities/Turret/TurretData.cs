using System.Collections.Generic;
using UnityEngine;
using StatusEffects;

namespace Entities.Turrets
{
    [CreateAssetMenu(fileName = "New TurretData", menuName = "Turret/New TurretData")]
    public sealed class TurretData : ScriptableObject
    {
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float FireRate { get; private set; }
        [field: SerializeField] public float Sight { get; private set; }
        [field: SerializeField] public int Cost { get; private set; }
        [field: SerializeField] public List<StatusEffect> StatusEffects { get; private set; }
    }
}
