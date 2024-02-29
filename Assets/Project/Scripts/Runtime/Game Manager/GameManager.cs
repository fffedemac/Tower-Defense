using UnityEngine;

[RequireComponent (typeof(GameManagerUI))]
public sealed class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameManagerUI _gameManagerUI;

    private void Awake() => Instance = this;

    public void LevelCompleted()
    {
        _gameManagerUI.ShowLevelStatePanel(GameStates.LevelCompleted);
        PauseGame();
    }

    public void LevelFailed()
    {
        _gameManagerUI.ShowLevelStatePanel(GameStates.LevelFailed);
        PauseGame();
    }

    public void PauseGame() => Time.timeScale = 0;
}