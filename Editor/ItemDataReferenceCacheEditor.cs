using blai30.RPGSystems.Inventory;
using UnityEditor;
using UnityEngine;

namespace blai30.RPGSystems.Editor
{
    [CustomEditor(typeof(ItemDataReferenceCache))]
    public class ItemDataReferenceCacheEditor : UnityEditor.Editor
    {
        private ItemDataReferenceCache _itemDataReferenceCache = null;

        public override void OnInspectorGUI()
        {
            _itemDataReferenceCache = (ItemDataReferenceCache) target;
            base.OnInspectorGUI();

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Load References"))
            {
                _itemDataReferenceCache.LoadReferences();
            }

            if (GUILayout.Button("Clear References"))
            {
                _itemDataReferenceCache.ClearReferences();
            }
            GUILayout.EndHorizontal();
        }
    }
}
