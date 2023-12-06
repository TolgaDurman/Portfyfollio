using UnityEngine.Purchasing;

namespace JoyIAP
{
    [System.Serializable]
    public struct PurchasableData
    {
        public string Id;
        public string Description;
        public ProductType Type;
        public float Price;
        public ItemTag Tag;
    }
}