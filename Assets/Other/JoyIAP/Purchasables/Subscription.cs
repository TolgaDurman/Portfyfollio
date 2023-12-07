using UnityEngine.Events;

namespace JoyIAP
{
    public class Subscription : Purchasable
    {
        public Subscription(PurchasableData data, IAPManager iapManager, UnityAction onPurchaseSuccess = null) : base(data, iapManager, onPurchaseSuccess)
        {

        }
    }
}