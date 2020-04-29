using UnityEditor;
using UnityEngine;

namespace blai30.RPGSystems.Editor
{
    [CustomPropertyDrawer(typeof(AssetIconAttribute))]
    public class AssetIconDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
        }
    }
}
