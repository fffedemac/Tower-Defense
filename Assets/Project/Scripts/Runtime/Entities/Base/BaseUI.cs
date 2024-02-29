using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Entities.Base
{
    public class BaseUI : MonoBehaviour
    {
        [SerializeField] private Slider _hpSlider;
        [SerializeField] private TMP_Text _hpText;

        public void InitializeValues(int maxHP)
        {
            _hpSlider.maxValue = maxHP;
            _hpSlider.value = maxHP;
            _hpText.text = maxHP + "/" + maxHP;
        }

        public void UpdateHealth(int currentHP, int maxHP)
        {
            _hpSlider.value = currentHP;
            _hpText.text = currentHP + "/" + maxHP;
        }
    }
}