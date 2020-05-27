using System;
using System.Collections.Generic;
using System.Linq;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEditor;
using UnityEngine;

namespace blai30.RPGSystems
{
    [Serializable]
    public abstract class IdentifiableReferences<T> : ScriptableObject, ISerializationCallbackReceiver
        where T : ScriptableObject, IIdentifiable
    {
#if ODIN_INSPECTOR
        [FolderPath]
#endif
        [SerializeField]
        private string[] foldersToSearchIn = null;

        [SerializeField]
        private List<T> references = null;

        private Dictionary<string, T> _stringObjMap = null;

        private bool IsInitialized => _stringObjMap != null;

        public T GetById(string itemId)
        {
            EnsureInitialized();
            return _stringObjMap[itemId];
        }

#if UNITY_EDITOR
        public void LoadReferences()
        {
            references = FindAssetsByType<T>(foldersToSearchIn);
            EnsureInitialized();
        }

        public void ClearReferences()
        {
            references = new List<T>();
            _stringObjMap = new Dictionary<string, T>();
        }

        private static List<TSource> FindAssetsByType<TSource>(params string[] folders)
            where TSource : ScriptableObject, IIdentifiable
        {
            // Find asset guids with the type
            if (folders == null || folders.Length <= 0)
            {
                return null;
            }

            var guids = AssetDatabase.FindAssets("t:" + typeof(TSource).Name, folders);

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

        public void OnBeforeSerialize()
        {
            LoadReferences();
        }

        public void OnAfterDeserialize()
        {
        }

        private void EnsureInitialized()
        {
            if (IsInitialized)
            {
                return;
            }

            _stringObjMap = references.ToDictionary(obj => obj.Id);
        }
    }
}
