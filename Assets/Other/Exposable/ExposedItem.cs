using UnityEngine;
namespace Exposable
{
    [System.Serializable]
    public abstract class ExposedItem : ScriptableObject
    {
        public abstract void Execute();
    }
}
