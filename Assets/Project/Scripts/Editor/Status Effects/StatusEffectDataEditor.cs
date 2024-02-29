using UnityEditor;

[CustomEditor(typeof(StatusEffectData))]
public class StatusEffectDataEditor : Editor
{
    private SerializedProperty modeProperty;
    private SerializedProperty typeProperty;
    private SerializedProperty tickProperty;
    private SerializedProperty durationProperty;
    private SerializedProperty percentageValueProperty;

    private void OnEnable()
    {
        serializedObject.Update();

        modeProperty = serializedObject.FindProperty("_mode");
        typeProperty = serializedObject.FindProperty("_type");
        durationProperty = serializedObject.FindProperty("_duration");
        tickProperty = serializedObject.FindProperty("_tick");
        percentageValueProperty = serializedObject.FindProperty("_percentageValue");

        serializedObject.ApplyModifiedProperties();
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(modeProperty);
        EditorGUILayout.PropertyField(typeProperty);
        EditorGUI.indentLevel++;

        EditorGUILayout.PropertyField(durationProperty);

        if ((EffectMode)modeProperty.enumValueIndex == EffectMode.PerTime)
            EditorGUILayout.PropertyField(tickProperty);
        else
            tickProperty.floatValue = durationProperty.floatValue;

        if (tickProperty.floatValue > durationProperty.floatValue)
            tickProperty.floatValue = durationProperty.floatValue;

        percentageValueProperty.floatValue = EditorGUILayout.Slider("Percentage Value", percentageValueProperty.floatValue, 0, 1);

        EditorGUI.indentLevel--;

        serializedObject.ApplyModifiedProperties();
    }
}

