using System;
using UnityEngine;

namespace blai30.RPGSystems
{
    /// <summary>
    /// Will disable the field based on parameters and a named target variable in the same script.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class DisableIfAttribute : PropertyAttribute
    {
        public string Target;
        public bool DisabledState;

        public DisableIfAttribute(string targetName, bool state)
        {
            Target = targetName;
            DisabledState = state;
        }
    }
}
