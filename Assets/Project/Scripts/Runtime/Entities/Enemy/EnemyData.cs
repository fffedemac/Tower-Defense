using UnityEngine;

namespace Entities.Enemies
{
    [CreateAssetMenu(fileName = "New EnemyData", menuName = "Enemies/New EnemyData")]
    public class EnemyData : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public int MaxHealth { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public int CoinReward { get; private set; }
    }
}
