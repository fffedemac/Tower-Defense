using UnityEngine;

namespace WaveSystem
{
    [RequireComponent (typeof (WaveManagerUI))]
    public sealed partial class WaveManager : MonoBehaviour
    {
        public static WaveManager Instance {  get; private set; }

        [SerializeField] private EnemySpawner[] _spawners;
        [SerializeField] private WaveManagerUI _waveManagerUI;
        public WaveChecker WaveChecker { get; private set; } = new WaveChecker();

        private void Awake() => Instance = this;

        private void Start() => StartWave();
    }
}