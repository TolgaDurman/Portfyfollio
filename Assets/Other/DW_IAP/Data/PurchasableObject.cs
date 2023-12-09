using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Purchasing;

namespace DW_IAP
{
    [CreateAssetMenu(fileName = "PurchasableObject", menuName = "JoyIAP/Purchasable Object")]
    public sealed class PurchasableObject : ScriptableObject, IDisposable
    {
        [SerializeField] private ProductType _type;
        public ProductType Type { get => _type;}
        [SerializeField, ReadOnly] private PurchasableData _metaData;
        public PurchaseEvents Events { get; private set; }
        public PurchasableData Data => _metaData;


        private IAPManager _manager;

        public void Init(IAPManager manager, PurchasableData purchasableData, PurchaseEvents events)
        {
            _manager = manager;
            _metaData = purchasableData;
            Events = events;
        }
        public void Purchase()
        {
            _manager.Purchase(this);
        }

        public void Dispose()
        {
            _manager = null;
            _metaData = new PurchasableData();
            Events = null;
        }
    }
}
