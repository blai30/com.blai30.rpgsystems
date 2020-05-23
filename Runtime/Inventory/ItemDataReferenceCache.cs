using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR
#endif

namespace blai30.RPGSystems.Inventory
{
    [CreateAssetMenu]
    public class ItemDataReferenceCache : ScriptableObject
    {
        [SerializeField] private List<ItemData> items;
        [SerializeField] private string[] foldersToSearchIn;

        public ItemData GetItemDataReference(string itemId)
        {
            foreach (ItemData item in items)
            {
                if (item.Id == itemId)
                {
                    return item;
                }
            }

            return null;
        }

#if UNITY_EDITOR
        [ContextMenu("Load References")]
        public void LoadReferences()
        {
            items = FindAssetsByType<ItemData>(foldersToSearchIn);
        }

        [ContextMenu("Clear References")]
        public void ClearReferences()
        {
            items.Clear();
        }

        public static List<T> FindAssetsByType<T>(params string[] folders) where T : Object
        {
            string type = typeof(T).Name;

            // Find asset guids with the type
            string[] guids;
            if (folders == null || folders.Length <= 0)
            {
                guids = AssetDatabase.FindAssets("t:" + type);
            }
            else
            {
                guids = AssetDatabase.FindAssets("t:" + type, folders);
            }

            // Convert asset guids to asset paths
            List<T> assets = new List<T>();
            foreach (var guid in guids)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guid);
                assets.Add(AssetDatabase.LoadAssetAtPath<T>(assetPath));
            }

            return assets;
        }
#endif
    }
}
