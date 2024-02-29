using UnityEditor;
using UnityEngine;

namespace WaveSystem
{
    [CustomEditor(typeof(EnemySpawner))]
    public sealed partial class EnemySpawnerEditor : Editor
    {
        private SerializedProperty _waves;

        private void OnEnable()
        {
            _waves = serializedObject.FindProperty("_waves");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            VisualizeWaves();
            serializedObject.ApplyModifiedProperties();
        }

        private void VisualizeWaves()
        {
            for (int i = 0; i < _waves.arraySize; i++)
            {
                SetWave(i);
                GUILayout.Space(15);
            }

            GUILayout.Space(20);
            if (GUILayout.Button("Add Wave"))
                AddWave();
        }

        private void SetWave(int wave)
        {
            GUILayout.BeginVertical("GroupBox");
            GUILayout.BeginHorizontal();

            GUILayout.Label("Wave: " + (wave + 1), EditorStyles.boldLabel);
            if (GUILayout.Button("Delete Wave"))
                RemoveWave(wave);

            GUILayout.EndHorizontal();
            GUILayout.Space(10);

            _waveData = _waves.GetArrayElementAtIndex(wave).FindPropertyRelative("_waveData");
            for (int i = 0; i < _waveData.arraySize; i++)
            {
                SetData(i);
                GUILayout.Space(5);
            }

            GUILayout.Space(5);
            if (GUILayout.Button("Add Enemy Group"))
                AddEnemyGroup();
                
            GUILayout.EndVertical();
        }


        private void AddWave()
        {
            _waves.arraySize++;
            serializedObject.ApplyModifiedProperties();
        }

        private void RemoveWave(int position)
        {
            _waves.DeleteArrayElementAtIndex(position);
            serializedObject.ApplyModifiedProperties();
        }
    }
}