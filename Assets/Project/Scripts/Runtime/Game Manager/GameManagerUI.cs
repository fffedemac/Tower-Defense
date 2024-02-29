using UnityEngine;

public sealed class GameManagerUI : MonoBehaviour
{
    [SerializeField] private GameObject _levelWinPanel;
    [SerializeField] private GameObject _levelFailedPanel;

    public void ShowLevelStatePanel(GameStates levelState)
    {
        GameObject panel = levelState switch
        {
            GameStates.LevelCompleted => _levelWinPanel,
            GameStates.LevelFailed => _levelFailedPanel,
            _ => _levelFailedPanel,
        };

        panel.SetActive(true);
    }
}
