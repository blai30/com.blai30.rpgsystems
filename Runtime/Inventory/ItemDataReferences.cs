using System.Collections.Generic;
using System.Linq;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEditor;
using UnityEngine;

namespace blai30.RPGSystems.Inventory
{
    [CreateAssetMenu]
    public class ItemDataReferences : ScriptableObject
    {
#if ODIN_INSPECTOR
        [FolderPath]
#endif
        [SerializeField]
        private string[] foldersToSearchIn;

        [SerializeField]
        private List<ItemData> references;

        [SerializeField]
        private Dictionary<string, ItemData> stringObjMap;

        public bool IsInitialized => stringObjMap != null;

        public ItemData GetById(string itemId)
        {
            EnsureInitialized();
            return stringObjMap[itemId];
        }

#if UNITY_EDITOR
        [ContextMenu("Load References")]
        public void LoadReferences()
        {
            references = FindAssetsByType<ItemData>(foldersToSearchIn);
            EnsureInitialized();
        }

        [ContextMenu("Clear References")]
        public void ClearReferences()
        {
            references = new List<ItemData>();
            stringObjMap = new Dictionary<string, ItemData>();
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

        private void EnsureInitialized()
        {
            if (IsInitialized)
            {
                return;
            }

            stringObjMap = new Dictionary<string, ItemData>(references.ToDictionary(item => item.Id));
            Debug.LogWarning($"{nameof(ItemDataReferences)} was initialized lazily because it wasn't initialized before use!");
        }
    }
}
