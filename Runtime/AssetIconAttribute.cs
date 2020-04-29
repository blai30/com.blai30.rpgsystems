using System;
using UnityEngine;

namespace blai30.RPGSystems
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class AssetIconAttribute : PropertyAttribute
    {
        public Sprite Sprite;
    }
}
