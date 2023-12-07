using UnityEngine.Events;

namespace DW_IAP
{
    public sealed class Subscription : Purchasable
    {
        public Subscription(PurchasableData data, IAPManager iapManager, UnityAction onPurchaseSuccess = null) : base(data, iapManager, onPurchaseSuccess)
        {

        }
    }
}