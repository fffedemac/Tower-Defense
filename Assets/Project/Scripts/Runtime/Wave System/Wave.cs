using UnityEngine;

namespace WaveSystem
{
    [System.Serializable]
    public struct Wave
    {
        [SerializeField] private WaveData[] _waveData;

        public WaveData[] WaveData { get { return _waveData; } }
    }
}