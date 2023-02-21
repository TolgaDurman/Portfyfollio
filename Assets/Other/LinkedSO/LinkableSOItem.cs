using UnityEngine;
namespace LinkedSO
{
    [System.Serializable]
    public abstract class LinkableSOItem : ScriptableObject
    {
        public abstract void Execute();
    }
}
