using UnityEditor;

namespace WaveSystem
{
    public sealed partial class WaveManagerEditor : Editor
    {
        private int _maxWavesTemp;

        private void CheckMaxWaves()
        {
            _maxWaves.intValue = 0;

            for (int i = 0; i < _spawners.arraySize; i++)
            {
                EnemySpawner temp = _spawners.GetArrayElementAtIndex(i).objectReferenceValue as EnemySpawner;
                _maxWavesTemp = temp.Waves.Length;

                if (_maxWavesTemp > _maxWaves.intValue)
                    _maxWaves.intValue = _maxWavesTemp;
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
