using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace blai30.RPGSystems.Inventory
{
    [CreateAssetMenu]
    public class ItemDataReferenceCache : ScriptableObject
    {
        [SerializeField]
        private List<ItemData> itemsCache;

        [SerializeField]
        private string[] foldersToSearchIn;

        private Dictionary<string, ItemData> _idObjMap;

        public ItemData GetItemData(string itemId)
        {
            return _idObjMap[itemId];
        }

#if UNITY_EDITOR
        [ContextMenu("Load References")]
        public void LoadReferences()
        {
            itemsCache = FindAssetsByType<ItemData>(foldersToSearchIn);
            _idObjMap = itemsCache.ToDictionary(item => item.Id);
        }

        [ContextMenu("Clear References")]
        public void ClearReferences()
        {
            itemsCache.Clear();
            _idObjMap.Clear();
        }

        private static List<T> FindAssetsByType<T>(params string[] folders) where T : Object
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
