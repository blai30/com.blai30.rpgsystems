using System.Collections.Generic;
using System.Linq;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEditor;
using UnityEngine;

namespace blai30.RPGSystems
{
    public abstract class IdentifiableReferences<T> : ScriptableObject where T : ScriptableObject, IIdentifiable
    {
#if ODIN_INSPECTOR
        [FolderPath]
#endif
        [SerializeField]
        private string[] foldersToSearchIn = null;

        [SerializeField]
        private List<T> references = null;

        [SerializeField]
        private Dictionary<string, T> stringObjMap = null;

        private bool IsInitialized => stringObjMap != null;

        public T GetById(string itemId)
        {
            EnsureInitialized();
            return stringObjMap[itemId];
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            LoadReferences();
        }

        public void LoadReferences()
        {
            references = FindAssetsByType<T>(foldersToSearchIn);
            EnsureInitialized();
        }

        public void ClearReferences()
        {
            references = new List<T>();
            stringObjMap = new Dictionary<string, T>();
        }

        private static List<TSource> FindAssetsByType<TSource>(params string[] folders) where TSource : ScriptableObject, IIdentifiable
        {
            string type = typeof(TSource).Name;

            // Find asset guids with the type
            if (folders == null || folders.Length <= 0)
            {
                return null;
            }

            var guids = AssetDatabase.FindAssets("t:" + type, folders);

            // Convert asset guids to asset paths
            List<TSource> assets = new List<TSource>();
            foreach (var guid in guids)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guid);
                assets.Add(AssetDatabase.LoadAssetAtPath<TSource>(assetPath));
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

            stringObjMap = new Dictionary<string, T>(references.ToDictionary(item => item.Id));
        }
    }
}
