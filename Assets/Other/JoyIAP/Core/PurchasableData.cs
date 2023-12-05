using UnityEngine.Purchasing;

namespace JoyIAP
{
    [System.Serializable]
    public struct PurchasableData
    {
        public string Id;
        public ProductType Type;
        public float Price;
        public ItemTag Tag;
        public PurchasableData(string id, ProductType type,float price, ItemTag tag)
        {
            Id = id;
            Type = type;
            Price = price;
            Tag = tag;
        }
    }
}
