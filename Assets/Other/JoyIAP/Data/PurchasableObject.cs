using System;
using UnityEngine;
using UnityEngine.Events;

namespace JoyIAP
{
    [CreateAssetMenu(fileName = "PurchasableObject", menuName = "JoyIAP/Purchasable Object")]
    public class PurchasableObject : ScriptableObject, IDisposable
    {
        [SerializeField] private PurchasableData data;
        public PurchasableData Data => data;
        public UnityAction OnPurchased;
        private Purchasable Purchasable;
        public void Init<T>(T purchasable) where T : Purchasable
        {
            Purchasable = purchasable;
            Purchasable.OnPurchaseSuccess += () => OnPurchased?.Invoke();
        }
        public void Purchase()
        {
            Purchasable.Purchase();
        }

        public void Dispose()
        {
            Purchasable.Dispose();
            Purchasable = null;
            OnPurchased = null;
        }
    }
}
