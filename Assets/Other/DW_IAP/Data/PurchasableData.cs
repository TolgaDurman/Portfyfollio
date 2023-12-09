using UnityEngine;

namespace DW_IAP
{
    [System.Serializable]
    public struct PurchasableData
    {
        public static PurchasableData Empty => new();
        [field: SerializeField] public string Id { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public string Price { get; private set; }

        public PurchasableData(string id, string description, string price)
        {
            Id = id;
            Description = description;
            Price = price;
        }
    }
}
