using UnityEngine.Events;

namespace JoyIAP
{
    public class NonConsumable : Purchasable
    {
        public NonConsumable(PurchasableData data, IAPManager iapManager, UnityAction onPurchaseSuccess = null) : base(data, iapManager, onPurchaseSuccess)
        {

        }
    }
}