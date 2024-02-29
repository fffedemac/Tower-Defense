using UnityEngine;
using UnityEditor;

namespace WaveSystem
{
    [CustomEditor(typeof(WaveManager))]
    public sealed partial class WaveManagerEditor : Editor
    {
        private SerializedProperty _spawners;
        private SerializedProperty _maxWaves;
        private SerializedProperty _restTimeBetweenWaves;
        private SerializedProperty _waveManagerUI;

        private void OnEnable()
        {
            serializedObject.Update();

            _spawners = serializedObject.FindProperty("_spawners");
            _maxWaves = serializedObject.FindProperty("_maxWaves");
            _restTimeBetweenWaves = serializedObject.FindProperty("_restTimeBetweenWaves");
            _waveManagerUI = serializedObject.FindProperty("_waveManagerUI");

            serializedObject.ApplyModifiedProperties();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_restTimeBetweenWaves);
            EditorGUILayout.PropertyField(_waveManagerUI);
            GUILayout.Space(15);

            EditorGUILayout.PropertyField(_spawners, true);
            GUILayout.Space(15);

            if (GUILayout.Button("Update"))
                CheckMaxWaves();

            CheckMaxWaves();

            serializedObject.ApplyModifiedProperties();
        }
    }
}
