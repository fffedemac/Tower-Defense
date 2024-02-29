using UnityEngine;
using UnityEditor;

namespace Entities.Turrets
{
    [CustomEditor(typeof(Turret))]
    public class TurretEditor : Editor
    {
        private SerializedProperty _turretData;
        private TurretData _dataReference;

        private SerializedProperty _sightSprite;
        private GameObject _spriteReference;

        private SerializedProperty _sightTrigger;
        private SphereCollider _triggerReference;

        protected virtual void OnEnable()
        {
            serializedObject.Update();

            _turretData = serializedObject.FindProperty("_turretData");
            _sightSprite = serializedObject.FindProperty("_sightSprite");
            _sightTrigger = serializedObject.FindProperty("_sightTrigger");

            _dataReference = _turretData.objectReferenceValue as TurretData;
            _spriteReference = _sightSprite.objectReferenceValue as GameObject;
            _triggerReference = _sightTrigger.objectReferenceValue as SphereCollider;

            _spriteReference.transform.localScale = new Vector3(_dataReference.Sight, _dataReference.Sight, 1);
            _triggerReference.radius = 4.5f * _dataReference.Sight;

            serializedObject.ApplyModifiedProperties();
        }
    }
}
