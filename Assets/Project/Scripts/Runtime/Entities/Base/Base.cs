using UnityEngine;

namespace Entities.Base
{
    [RequireComponent(typeof(BaseUI))]
    public class Base : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _maxHP;
        private int _currentHP;

        [SerializeField] private BaseUI _baseUI;

        private void Awake()
        {
            _currentHP = _maxHP;
            _baseUI.InitializeValues(_maxHP);
        }

        public void GetDamage(int damage)
        {
            _currentHP -= damage;
            _baseUI.UpdateHealth(_currentHP, _maxHP);

            if (_currentHP <= 0)
                GameManager.Instance.LevelFailed();
        }
    }
}
