using UnityEditor;
using UnityEngine;

namespace WaveSystem
{
    public sealed partial class EnemySpawnerEditor : Editor
    {
        private SerializedProperty _waveData;
        private SerializedProperty _enemyGroup;

        private void SetData(int group)
        {
            GUILayout.BeginVertical("GroupBox");

            SerializedProperty delayTime = _waveData.GetArrayElementAtIndex(group).FindPropertyRelative("_delayTime");
            SerializedProperty spawnRate = _waveData.GetArrayElementAtIndex(group).FindPropertyRelative("_spawnRate");
            _enemyGroup = _waveData.GetArrayElementAtIndex(group).FindPropertyRelative("_enemies");

            EditorGUILayout.PropertyField(delayTime);
            EditorGUILayout.PropertyField(spawnRate);

            GUILayout.BeginVertical("GroupBox");
            EditorGUILayout.PropertyField(_enemyGroup, true);
            GUILayout.EndVertical();

            if (GUILayout.Button("Delete Group"))
                RemoveEnemyGroup(group);

            GUILayout.EndVertical();
        }

        private void AddEnemyGroup()
        {
            _waveData.arraySize++;
            serializedObject.ApplyModifiedProperties();
        }

        private void RemoveEnemyGroup(int position)
        {
            _waveData.DeleteArrayElementAtIndex(position);
            serializedObject.ApplyModifiedProperties();
        }
    }
}