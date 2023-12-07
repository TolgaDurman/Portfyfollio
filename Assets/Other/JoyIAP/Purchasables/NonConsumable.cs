using UnityEngine.Events;

namespace DW_IAP
{
    public sealed class NonConsumable : Purchasable
    {
        public NonConsumable(PurchasableData data, IAPManager iapManager, UnityAction onPurchaseSuccess = null) : base(data, iapManager, onPurchaseSuccess)
        {

        }
    }
}