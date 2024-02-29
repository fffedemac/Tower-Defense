using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsText;

    public void UpdateCoins(int coins) => _coinsText.text = "Coins: " + coins;
}
