using UnityEngine;

[RequireComponent(typeof(PlayerUI))]
public sealed class Player : MonoBehaviour
{
    [SerializeField] private PlayerUI _playerUI;
    [field: SerializeField] public int Coins { get; private set; }
    private PlayerInputs _inputs;

    private void Awake()
    {
        _inputs = new PlayerInputs();

        Gameplay.Utils.EventManager.Subscribe(LevelEvent.OnEnemyKilled, UpdateMoney);
        _playerUI.UpdateCoins(Coins);
    }

    public void UpdateMoney(params object[] parameters)
    {
        Coins += (int)parameters[0];
        _playerUI.UpdateCoins(Coins);
    }
}
