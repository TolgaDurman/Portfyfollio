using System;
using UnityEngine.Events;

namespace DW_IAP
{
    [Serializable]
    public abstract class Purchasable : IDisposable
    {
        private IAPManager IAPManager;
        public PurchasableData Data;
        public UnityAction OnPurchaseSuccess;
        public Purchasable(PurchasableData data, IAPManager iapManager, UnityAction onPurchaseSuccess = null)
        {
            Data = data;
            IAPManager = iapManager;
            OnPurchaseSuccess = onPurchaseSuccess;
        }
        public void Purchase()
        {
            IAPManager.Purchase(this);
        }

        public void Dispose()
        {
            OnPurchaseSuccess = null;
            IAPManager = null;
        }
    }
}