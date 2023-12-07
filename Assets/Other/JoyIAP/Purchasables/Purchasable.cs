using System;
using UnityEngine.Events;

namespace JoyIAP
{
    [Serializable]
    public class Purchasable
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