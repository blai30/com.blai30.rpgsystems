using UnityEditor;
using UnityEngine;

namespace blai30.RPGSystems.Editor
{
    [CustomPropertyDrawer(typeof(DisableIfAttribute))]
    public class DisableIfDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            DisableIfAttribute a = (DisableIfAttribute) attribute;
            SerializedProperty target = property.serializedObject.FindProperty(a.Target);

            bool newState = true;
            bool oldState = GUI.enabled;

            if (target == null)
            {
                Debug.LogWarning("[DisableIfAttribute] Invalid Property Name for Attribute.", property.serializedObject.targetObject);
            }
            else
            {
                newState = target.boolValue != a.DisabledState;
            }

            GUI.enabled = newState;
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = oldState;
        }
    }
}
