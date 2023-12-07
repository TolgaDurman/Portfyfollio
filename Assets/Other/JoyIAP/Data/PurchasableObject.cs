using System;
using UnityEngine;
using UnityEngine.Events;

namespace DW_IAP
{
    [CreateAssetMenu(fileName = "PurchasableObject", menuName = "JoyIAP/Purchasable Object")]
    public class PurchasableObject : ScriptableObject, IDisposable
    {
        [SerializeField] private PurchasableData data;
        public PurchasableData Data => data;
        public UnityAction OnPurchased;
        private Purchasable _purchasable;
        public void Init<T>(T purchasable) where T : Purchasable
        {
            _purchasable = purchasable;
            _purchasable.OnPurchaseSuccess += () => OnPurchased?.Invoke();
        }
        public void Purchase()
        {
            _purchasable.Purchase();
        }

        public void Dispose()
        {
            _purchasable.Dispose();
            _purchasable = null;
            OnPurchased = null;
        }
    }
}
