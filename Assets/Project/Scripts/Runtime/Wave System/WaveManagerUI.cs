using System.Collections;
using UnityEngine;
using TMPro;

namespace WaveSystem
{
    public class WaveManagerUI : MonoBehaviour
    {
        [SerializeField] private GameObject _nextWavePanel;
        [SerializeField] private TMP_Text _nextWaveText;

        public void StartCountdown(int currentWave, int totalWaves, int countdown)
        {
            StartCoroutine(Countdown(currentWave, totalWaves, countdown));
        }

        private IEnumerator Countdown (int currentWave, int totalWaves, int countdown)
        {
            _nextWavePanel.SetActive(true);

            while (countdown > 0)
            {
                _nextWaveText.text = "Wave (" + (currentWave + 1) + "/" + totalWaves + ") in: " + countdown;
                yield return new WaitForSeconds(1);
                countdown--;
            }

            _nextWavePanel.SetActive(false);
        }
    }
}
