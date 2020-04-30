using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEditor;

namespace blai30.RPGSystems
{
    public static class RpgDatabase
    {
        public static IEnumerable GetAllScriptableObjects(Type type)
        {
            string[] guids = AssetDatabase.FindAssets($"t:{type.Name}");
            IEnumerable<string> select = guids.Select(guid => AssetDatabase.GUIDToAssetPath(guid));
            IEnumerable<ValueDropdownItem> result = select.Select(path => new ValueDropdownItem(path, AssetDatabase.LoadAssetAtPath(path, type)));

            return result;
        }
    }
}
