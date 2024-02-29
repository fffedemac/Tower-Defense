using UnityEngine;
using UnityEngine.UI;

namespace Entities.Enemies
{
    public class EnemyUI : MonoBehaviour
    {
        [SerializeField] private Slider _hpSlider;

        public void InitializeValues(int maxHP)
        {
            _hpSlider.maxValue = maxHP;
            _hpSlider.value = maxHP;
        }

        public void UpdateHealth(int currentHP) => _hpSlider.value = currentHP;
    }
}